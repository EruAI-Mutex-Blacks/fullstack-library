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
            throw new NotImplementedException();
        }
    }
}