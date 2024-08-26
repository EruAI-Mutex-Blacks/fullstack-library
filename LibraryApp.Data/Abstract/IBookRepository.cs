using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Abstract
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; } //veriler db den cekilmeden sorgu yap�l�yor get kullan�lmas�ndaki amac

        IQueryable<Book> GetBooks();
        Book? GetBookById(int id);
        void CreateBook(Book book);
        Task UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}