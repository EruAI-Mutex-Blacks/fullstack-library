using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Abstract
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }

        void GetBooks();
        Book? GetBookById(int id);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}