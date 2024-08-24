using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fullstack_library.DTO;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fullstack_library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;
        private readonly IBookBorrowActivityRepository _bookBorrowRepo;
        private readonly IUserRepository _userRepo;
        private readonly IBookPublishRequestRepository _bookPublishReqsRepo;

        public BookController(IBookRepository bookRepo, IBookBorrowActivityRepository bookBorrowRepo, IUserRepository userRepo, IBookPublishRequestRepository bookPublishRequestRepository)
        {
            _bookRepo = bookRepo;
            _bookBorrowRepo = bookBorrowRepo;
            _userRepo = userRepo;
            _bookPublishReqsRepo = bookPublishRequestRepository;
        }

        [HttpPut("ApprovePublishing/{bookId}")]
        public IActionResult ApprovePublishingBook(int? bookId)
        {
            //TODO check role if not manager than return unauthorized
            if (bookId == null) return BadRequest(new { message = "Invalid book id" });
            var book = _bookRepo.GetBookById(bookId.Value);
            if (book == null) return NotFound(new { message = "Book could not found" }); //return notfound status code
            book.IsPublished = true;
            _bookRepo.UpdateBook(book);
            return Ok(new { message = "Book has been approved" });
        }


        //TODO dont delete maybe handle rejection on frontend only or make a bookcreation table and remove it from there only or wait a bool query string in setpublishingbook and update it according to query string.
        [HttpDelete("RejectPublishing/{bookId}")]
        public IActionResult RejectPublishingBook(int? bookId)
        {
            //make ispending false for both operations
            //TODO check role if not manager than return unauthorized
            if (bookId == null) return BadRequest(new { message = "Invalid book id" });
            var book = _bookRepo.GetBookById(bookId.Value);
            if (book == null) return NotFound(new { message = "Book could not found" }); //return notfound status code
            _bookRepo.DeleteBook(book);
            return Ok(new { message = "Book has been rejected" });
        }

        [HttpGet("BookPublishRequests")]
        public IActionResult BookPublishRequests()
        {
            var BookPublishRequests = _bookPublishReqsRepo.Requests.Where(bpr => bpr.IsPending).Include(bpr => bpr.Book).ThenInclude(b => b.BookAuthors).ThenInclude(ba => ba.User);
            return Ok(BookPublishRequests.Select(bpr => new BookPublishReqDTO
            {
                Authors = bpr.Book.BookAuthors.Select(ba => ba.User.Name).ToList(),
                BookName = bpr.Book.Title,
                Id = bpr.Id,
                RequestDate = bpr.RequestDate,
            }));
        }

        [HttpGet("SearchBook")]
        public IActionResult SearchBook([FromQuery] string? bookName)
        {
            var books = _bookRepo.GetBooks().Where(b => b.Title.Contains(bookName ?? "") && b.IsPublished).Take(10).Select(b => new BookDTO
            {
                Id = b.Id,
                Title = b.Title,
                IsBorrowed = b.IsBorrowed,
                Authors = b.BookAuthors.Select(ba => ba.User.Name).ToList(),
                PublishDate = b.PublishDate,
            });
            return Ok(books);
        }

        [HttpGet("BorrowedBooks")]
        public IActionResult BorrowedBooks([FromQuery] int userId)
        {
            var borrowedBookDTOS = _bookBorrowRepo.BookBorrowActivities.Where(bba => bba.UserId == userId && bba.IsApproved).Include(bba => bba.Book).Select(bba => new BookBorrowActivityDTO
            {
                BorrowDate = bba.BorrowDate,
                ReturnDate = bba.ReturnDate,
                BookDTO = new BookDTO
                {
                    Authors = bba.Book.BookAuthors.Select(ba => ba.User.Name).ToList(),
                    Title = bba.Book.Title,
                    IsBorrowed = bba.Book.IsBorrowed,
                    PublishDate = bba.Book.PublishDate,
                },
            });

            return Ok(borrowedBookDTOS);
        }

        [HttpGet("BorrowRequests")]
        public IActionResult BorrowRequests()
        {
            var borrowedBookDTOS = _bookBorrowRepo.BookBorrowActivities.Where(bba => !bba.IsApproved).Include(bba => bba.Book).Include(bba => bba.User).Select(bba => new BookBorrowActivityDTO
            {
                Id = bba.Id,
                RequestorName = bba.User.Name + " " + bba.User.Surname,
                BorrowDate = bba.BorrowDate,
                ReturnDate = bba.ReturnDate,
                BookDTO = new BookDTO
                {
                    Title = bba.Book.Title,
                },
            });

            return Ok(borrowedBookDTOS);
        }

        [HttpPost("SetBorrowRequest")]
        public async Task<IActionResult> SetBorrowRequest(SetBorrowRequestDTO setBorrowRequestDTO)
        {
            var bookBorrowActivity = _bookBorrowRepo.BookBorrowActivities.Include(bba => bba.Book).FirstOrDefault(bba => bba.Id == setBorrowRequestDTO.Id);
            if (bookBorrowActivity == null) return NotFound();

            if (setBorrowRequestDTO.IsApproved)
            {
                bookBorrowActivity.IsApproved = true;
                bookBorrowActivity.Book.IsBorrowed = true;
                await _bookBorrowRepo.UpdateBookBorrowActivity(bookBorrowActivity);

                //delete other waiting requests for same book
                var sameBookRequests = _bookBorrowRepo.BookBorrowActivities.Where(bba => !bba.IsApproved && bba.BookId == bookBorrowActivity.BookId && bba.Id != bookBorrowActivity.Id).ToList();
                await _bookBorrowRepo.DeleteBookBorrowActivities(sameBookRequests);
            }
            else
                await _bookBorrowRepo.DeleteBookBorrowActivity(bookBorrowActivity);


            return Ok(new { Message = "Operation done!" });
        }

        [HttpPost("BorrowBook")]
        public IActionResult BorrowBook(BorrowBookDTO borrowBookDTO)
        {
            var user = _userRepo.GetUserById(borrowBookDTO.UserId);
            if (user == null) return NotFound(new { Message = "User could not found" });
            var book = _bookRepo.GetBookById(borrowBookDTO.BookId);
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
            _bookBorrowRepo.CreateBookBorrowActivity(bba);
            return Ok(new { Message = "Borrow request has been sent to staff. Please wait for approval." });
        }

        [HttpGet("GetBook")]
        public IActionResult GetBook([FromQuery] int bookId)
        {
            var book = _bookRepo.Books.Include(b => b.Pages).Include(b => b.BookBorrowActivities).FirstOrDefault(b => b.Id == bookId);
            if (book == null) return NotFound(new { Message = "Book not found" });
            return Ok(new ReadBookDTO
            {
                BorrowedById = book.BookBorrowActivities.FirstOrDefault(bba => bba.IsApproved && !bba.IsReturned)?.UserId ?? 0,
                Title = book.Title,
                Pages = book.Pages.Select(p => new PageDTO
                {
                    Content = p.Content,
                    PageNumber = p.PageNumber,
                }).ToList(),
            });
        }
    }
}