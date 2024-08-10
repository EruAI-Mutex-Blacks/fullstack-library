using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Abstract
{
    public interface IBookBorrowActivityRepository
    {
        IQueryable<BookBorrowActivity> BookBorrowActivities { get; }

        void GetBookBorrowActivities();
        void GetBookBorrowActivityById(int id);
        void CreateBookBorrowActivity(BookBorrowActivity bookBorrowActivity);
        void UpdateBookBorrowActivity(BookBorrowActivity bookBorrowActivity);
        void DeleteBookBorrowActivity(BookBorrowActivity bookBorrowActivity);
    }
}