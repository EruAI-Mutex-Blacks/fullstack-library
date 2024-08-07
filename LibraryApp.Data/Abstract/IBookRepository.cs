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

        void CreateBook(Book book);
    }
}