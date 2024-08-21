using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fullstack_library.DTO;
using LibraryApp.Data.Abstract;
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

        public BookController(IBookRepository bookRepo, IBookBorrowActivityRepository bookBorrowRepo)
        {
            _bookRepo = bookRepo;
            _bookBorrowRepo = bookBorrowRepo;
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
            //TODO check role if not manager than return unauthorized
            if (bookId == null) return BadRequest(new { message = "Invalid book id" });
            var book = _bookRepo.GetBookById(bookId.Value);
            if (book == null) return NotFound(new { message = "Book could not found" }); //return notfound status code
            _bookRepo.DeleteBook(book);
            return Ok(new { message = "Book has been rejected" });
        }

        [HttpGet("SearchBook")]
        public IActionResult SearchBook([FromQuery] string? bookName)
        {
            var books = _bookRepo.GetBooks().Where(b => b.Title.Contains(bookName ?? "") && b.IsPublished).Take(10).Select(b => new BookDTO
            {
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
            var borrowedBookDTOS = _bookBorrowRepo.BookBorrowActivities.Where(bba => bba.UserId == userId).Include(bba => bba.Book).Select(bba => new BookBorrowActivityDTO
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
    }
}