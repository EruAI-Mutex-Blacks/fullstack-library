using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Concrete
{
    public class EfBookRepository : IBookRepository
    {
        public IQueryable<Book> Books => _context.Books;
        private LibraryDbContext _context;

        public EfBookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public void CreateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}