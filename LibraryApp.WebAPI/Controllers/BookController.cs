using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace fullstack_library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public BookController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        [HttpPut("ApprovePublishing/{bookId}")]
        public IActionResult ApprovePublishingBook(int? bookId)
        {
            //TODO check role if not manager than return unauthorized
            if (bookId == null) return BadRequest("Invalid book id");
            var book = _bookRepo.GetBookById(bookId.Value);
            if (book == null) return NotFound("Book could not found"); //return notfound status code
            book.IsPublished = true;
            _bookRepo.UpdateBook(book);
            return Ok("Book has been approved");
        }


        //TODO dont delete maybe handle rejection on frontend only or make a bookcreation table and remove it from there only or wait a bool query string in setpublishingbook and update it according to query string.
        [HttpDelete("RejectPublishing/{bookId}")]
        public IActionResult RejectPublishingBook(int? bookId)
        {
            //TODO check role if not manager than return unauthorized
            if (bookId == null) return BadRequest("Invalid book id");
            var book = _bookRepo.GetBookById(bookId.Value);
            if (book == null) return NotFound("Book could not found"); //return notfound status code
            _bookRepo.DeleteBook(book);
            return Ok("Book has been rejected");
        }
    }
}