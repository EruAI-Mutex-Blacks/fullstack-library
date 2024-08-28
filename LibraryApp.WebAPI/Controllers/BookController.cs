using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fullstack_library.DTO;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fullstack_library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;
        private readonly IPageRepository _pageRepo;
        private readonly IBookBorrowActivityRepository _bookBorrowRepo;
        private readonly IUserRepository _userRepo;
        private readonly IBookPublishRequestRepository _bookPublishReqsRepo;

        public BookController(IBookRepository bookRepo, IBookBorrowActivityRepository bookBorrowRepo, IUserRepository userRepo, IBookPublishRequestRepository bookPublishRequestRepository, IPageRepository pageRepository)
        {
            _bookRepo = bookRepo;
            _bookBorrowRepo = bookBorrowRepo;
            _userRepo = userRepo;
            _bookPublishReqsRepo = bookPublishRequestRepository;
            _pageRepo = pageRepository;
        }

        [HttpPut("SetPublishing")]
        [Authorize(Policy = "ManagerPolicy")]
        public async Task<IActionResult> SetPublishing(PublishBookDTO publishBookDTO)
        {
            var request = _bookPublishReqsRepo.Requests.Include(bpr => bpr.Book).FirstOrDefault(bpr => bpr.Id == publishBookDTO.RequestId);
            if (request == null) return NotFound(new { Message = "Request not found.f" });

            if (publishBookDTO.IsApproved)
            {
                request.Book.IsPublished = true;
                request.Book.PublishDate = DateTime.Now;
                await _bookRepo.UpdateBookAsync(request.Book);
            }

            request.IsPending = false;
            await _bookPublishReqsRepo.UpdateRequestAsync(request);

            return Ok(new { message = publishBookDTO.IsApproved ? "Request approved." : "Request rejected." });
        }

        [HttpGet("BookPublishRequests")]
        [Authorize(Policy = "ManagerPolicy")]
        public async Task<IActionResult> BookPublishRequests()
        {
            var BookPublishRequests = await _bookPublishReqsRepo.Requests.Where(bpr => bpr.IsPending).Include(bpr => bpr.Book).ThenInclude(b => b.BookAuthors).ThenInclude(ba => ba.User).ToListAsync();
            return Ok(BookPublishRequests.Select(bpr => new BookPublishReqDTO
            {
                Authors = bpr.Book.BookAuthors.Select(ba => ba.User.Name).ToList(),
                BookName = bpr.Book.Title,
                BookId = bpr.Book.Id,
                Id = bpr.Id,
                RequestDate = bpr.RequestDate,
            }));
        }

        [HttpPost("RequestPublishment")]
        [Authorize(Policy = "AuthorPolicy")]
        public async Task<IActionResult> RequestPublishment([FromBody] int bookId)
        {
            var book = await _bookRepo.GetBookByIdAsync(bookId);
            if (book == null) return NotFound(new { Message = "Book not found." });
            if (book.IsPublished) return BadRequest(new { Message = "Your book is already published." });
            if (_bookPublishReqsRepo.Requests.Any(bpr => bpr.IsPending && bpr.BookId == bookId))
                return BadRequest(new { Message = "Your request is still active." });

            await _bookPublishReqsRepo.CreateRequestAsync(new BookPublishRequest()
            {
                BookId = bookId,
                IsPending = true,
                RequestDate = DateTime.Now,
            });
            return Ok(new { Message = "Request has sent" });
        }

        [HttpGet("SearchBook")]
        [Authorize(Policy = "MemberOrHigherPolicy")]
        public async Task<IActionResult> SearchBook([FromQuery] string? bookName)
        {
            var books = await _bookRepo.Books.Where(b => b.Title.Contains(bookName ?? "") && b.IsPublished).Take(20).Select(b => new BookDTO
            {
                Id = b.Id,
                Title = b.Title,
                IsBorrowed = b.IsBorrowed,
                Authors = b.BookAuthors.Select(ba => ba.User.Name).ToList(),
                PublishDate = b.PublishDate,
            }).ToListAsync();
            return Ok(books);
        }

        [HttpGet("BorrowedBooks")]
        [Authorize(Policy = "MemberOrHigherPolicy")]
        public async Task<IActionResult> BorrowedBooks([FromQuery] int userId)
        {
            var borrowedBookDTOS = await _bookBorrowRepo.BookBorrowActivities.Where(bba => bba.UserId == userId && bba.IsApproved && !bba.IsReturned).Include(bba => bba.Book).Select(bba => new BookBorrowActivityDTO
            {
                BorrowDate = bba.BorrowDate,
                ReturnDate = bba.ReturnDate,
                BookDTO = new BookDTO
                {
                    Id = bba.BookId,
                    Authors = bba.Book.BookAuthors.Select(ba => ba.User.Name).ToList(),
                    Title = bba.Book.Title,
                    IsBorrowed = bba.Book.IsBorrowed,
                    PublishDate = bba.Book.PublishDate,
                },
            }).ToListAsync();

            return Ok(borrowedBookDTOS);
        }

        [HttpGet("BorrowRequests")]
        [Authorize(Policy = "StaffOrManagerPolicy")]
        public async Task<IActionResult> BorrowRequests()
        {
            var borrowedBookDTOS = await _bookBorrowRepo.BookBorrowActivities.Where(bba => !bba.IsApproved).Include(bba => bba.Book).Include(bba => bba.User).Select(bba => new BookBorrowActivityDTO
            {
                Id = bba.Id,
                RequestorName = bba.User.Name + " " + bba.User.Surname,
                BorrowDate = bba.BorrowDate,
                ReturnDate = bba.ReturnDate,
                BookDTO = new BookDTO
                {
                    Title = bba.Book.Title,
                },
            }).ToListAsync();

            return Ok(borrowedBookDTOS);
        }

        [HttpPost("SetBorrowRequest")]
        [Authorize(Policy = "StaffOrManagerPolicy")]
        public async Task<IActionResult> SetBorrowRequest(SetBorrowRequestDTO setBorrowRequestDTO)
        {
            var bookBorrowActivity = _bookBorrowRepo.BookBorrowActivities.Include(bba => bba.Book).FirstOrDefault(bba => bba.Id == setBorrowRequestDTO.Id);
            if (bookBorrowActivity == null) return NotFound(new { Message = "Borrow request not found." });

            if (setBorrowRequestDTO.IsApproved)
            {
                bookBorrowActivity.IsApproved = true;
                bookBorrowActivity.Book.IsBorrowed = true;
                await _bookBorrowRepo.UpdateBookBorrowActivityAsync(bookBorrowActivity);

                //delete other waiting requests for same book
                var sameBookRequests = _bookBorrowRepo.BookBorrowActivities.Where(bba => !bba.IsApproved && bba.BookId == bookBorrowActivity.BookId && bba.Id != bookBorrowActivity.Id).ToList();
                await _bookBorrowRepo.DeleteBookBorrowActivitiesAsync(sameBookRequests);
            }
            else
                await _bookBorrowRepo.DeleteBookBorrowActivityAsync(bookBorrowActivity);


            return Ok(new { Message = setBorrowRequestDTO.IsApproved ? "Request approved." : "Request rejected" });
        }

        [HttpPost("BorrowBook")]
        [Authorize(Policy = "MemberOrHigherPolicy")]
        public async Task<IActionResult> BorrowBook(BorrowBookDTO borrowBookDTO)
        {
            var user = await _userRepo.GetUserByIdAsync(borrowBookDTO.UserId);
            if (user == null) return NotFound(new { Message = "User could not found" });
            var book = await _bookRepo.GetBookByIdAsync(borrowBookDTO.BookId);
            if (book == null) return NotFound(new { Message = "Book could not found" });
            if (book.IsBorrowed) return BadRequest(new { Message = "Book already borrowed" });
            if (_bookBorrowRepo.BookBorrowActivities.Any(bba => !bba.IsApproved && bba.UserId == borrowBookDTO.UserId)) return BadRequest(new { Message = "You already requested one book. Please wait for approval before you request more." });

            BookBorrowActivity bba = new()
            {
                BookId = borrowBookDTO.BookId,
                UserId = borrowBookDTO.UserId,
                BorrowDate = DateTime.Now,
                IsApproved = false,
                ReturnDate = DateTime.Now.AddDays(14),
            };
            await _bookBorrowRepo.CreateBookBorrowActivityAsync(bba);
            return Ok(new { Message = "Borrow request has sent to staff. Please wait for approval." });
        }

        [HttpGet("GetBook")]
        [Authorize(Policy = "MemberOrHigherPolicy")]
        public async Task<IActionResult> GetBook([FromQuery] int bookId)
        {
            var book = await _bookRepo.Books.Include(b => b.Pages).Include(b => b.BookBorrowActivities).Include(b => b.BookAuthors).FirstOrDefaultAsync(b => b.Id == bookId);
            if (book == null) return NotFound(new { Message = "Book not found" });
            return Ok(new ReadBookDTO
            {
                BorrowedById = book.BookBorrowActivities.FirstOrDefault(bba => bba.IsApproved && !bba.IsReturned)?.UserId ?? 0,
                Title = book.Title,
                AuthorIds = book.BookAuthors.Select(ba => ba.UserId).ToList(),
                Pages = book.Pages.Select(p => new PageDTO
                {
                    Content = p.Content,
                    PageNumber = p.PageNumber,
                }).ToList(),
            });
        }

        //FIXME very slow after some use of updating name of book etc.
        [HttpGet("GetBooksByAuthor")]
        [Authorize(Policy = "AuthorPolicy")]
        public async Task<IActionResult> GetBooksByAuthor([FromQuery] int userId)
        {
            if (!_userRepo.Users.Any(u => u.Id == userId)) return NotFound(new { Message = "User not found." });
            var books = await _bookRepo.Books
            .AsNoTracking()
            .Where(b => b.BookAuthors.Any(ba => ba.UserId == userId))
            .ToListAsync();

            var MyBookDTOS = books.Select(b => new MyBooksDTO
            {
                BookId = b.Id,
                BookName = b.Title,
                PublishDate = b.PublishDate,
                Status = b.IsPublished ? "Published" : b.BookPublishRequests.Any(bpr => bpr.IsPending) ? "Waiting for approval" : "Can send request",
            });

            return Ok(MyBookDTOS);
        }

        [HttpPost("WritePage")]
        [Authorize(Policy = "AuthorPolicy")]
        public async Task<IActionResult> WritePage([FromBody] PageDTO pageDTO)
        {
            var book = _bookRepo.Books.Include(b => b.Pages).FirstOrDefault(b => b.Id == pageDTO.BookId);
            if (book == null) return NotFound(new { Message = "Book not found." });
            if (book.IsPublished) return BadRequest(new { Message = "Cannot add page to published book" });
            if (book.Pages.Any(p => p.PageNumber == pageDTO.PageNumber)) return BadRequest(new { Message = "There is a page with that number." });

            await _pageRepo.CreatePageAsync(new Page
            {
                BookId = pageDTO.BookId,
                Content = pageDTO.Content,
                PageNumber = pageDTO.PageNumber,
            });

            return Ok(new { Message = "Page saved." });
        }

        [HttpPost("CreateBook")]
        [Authorize(Policy = "AuthorPolicy")]
        public async Task<IActionResult> CreateBook([FromBody] int authorId)
        {
            if (!_userRepo.Users.Any(u => u.Id == authorId)) return NotFound(new { Message = "User not found." });
            await _bookRepo.CreateBookAsync(new Book
            {
                IsBorrowed = false,
                IsPublished = false,
                PublishDate = new DateTime(1000, 1, 1),
                Title = "New Book",
                BookAuthors = [
                    new BookAuthor(){
                        UserId = authorId,
                    }
                ]
            });
            return Ok(new { Message = "Book created" });
        }

        [HttpPut("UpdateBookName")]
        [Authorize(Policy = "AuthorPolicy")]
        public async Task<IActionResult> UpdateBookName(MyBooksDTO myBooksDTO)
        {
            var book = _bookRepo.Books.FirstOrDefault(b => b.Id == myBooksDTO.BookId);
            if (book == null) return NotFound(new { Message = "Book not found." });

            book.Title = myBooksDTO.BookName;
            await _bookRepo.UpdateBookAsync(book);
            return Ok(new { Message = "Book Updated" });
        }

        [HttpPut("ReturnBook")]
        [Authorize(Policy = "MemberOrHigherPolicy")]
        public async Task<IActionResult> ReturnBook([FromBody] int bookId)
        {
            var book = _bookRepo.Books.Include(b => b.BookBorrowActivities).FirstOrDefault(b => b.Id == bookId);
            if (book == null) return NotFound(new { Message = "Book not found." });

            var bba = book.BookBorrowActivities.FirstOrDefault(bba => !bba.IsReturned);
            if (bba == null) return BadRequest(new { Message = "Borrow activity not found." });

            book.IsBorrowed = false;
            bba.IsReturned = true;
            await _bookRepo.UpdateBookAsync(book);
            await _bookBorrowRepo.UpdateBookBorrowActivityAsync(bba);
            return Ok(new { Message = "Book returned." });
        }
    }
}