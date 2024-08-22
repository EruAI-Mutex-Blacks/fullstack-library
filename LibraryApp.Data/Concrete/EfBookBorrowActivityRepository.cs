using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Concrete
{
    public class EfBookBorrowActivityRepository : IBookBorrowActivityRepository
    {
        public IQueryable<BookBorrowActivity> BookBorrowActivities => _context.BookBorrowActivities;
        private LibraryDbContext _context;

        public EfBookBorrowActivityRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public void CreateBookBorrowActivity(BookBorrowActivity bookBorrowActivity)
        {
            _context.BookBorrowActivities.Add(bookBorrowActivity);
            _context.SaveChanges();
        }

        public void UpdateBookBorrowActivity(BookBorrowActivity bookBorrowActivity)
        {
            _context.BookBorrowActivities.Update(bookBorrowActivity);
            _context.SaveChanges();
        }

        public void DeleteBookBorrowActivity(BookBorrowActivity bookBorrowActivity)
        {
            _context.BookBorrowActivities.Remove(bookBorrowActivity);
            _context.SaveChanges();

        }
    }
}