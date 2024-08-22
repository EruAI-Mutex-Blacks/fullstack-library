using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Concrete
{
    public class EfBookAuthorRepository : IBookAuthorRepository
    {
        public IQueryable<BookAuthor> BookAuthors => _context.BookAuthors;
        private readonly LibraryDbContext _context;

        public EfBookAuthorRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public void CreateBookAuthor(BookAuthor bookAuthor)
        {
            _context.BookAuthors.Add(bookAuthor);
            _context.SaveChanges();
        }

        public IEnumerable<BookAuthor> GetBookAuthors()
        {
            return _context.BookAuthors.ToList();
        }

        public BookAuthor? GetBookAuthorById(int id)
        {
            return _context.BookAuthors.FirstOrDefault(ba => ba.Id == id);
        }

        public void UpdateBookAuthor(BookAuthor bookAuthor)
        {
            _context.BookAuthors.Update(bookAuthor);
            _context.SaveChanges();
        }

        public void DeleteBookAuthor(BookAuthor bookAuthor)
        {
            _context.BookAuthors.Remove(bookAuthor);
            _context.SaveChanges();
        }
    }
}