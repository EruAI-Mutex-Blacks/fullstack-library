using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data.Entity
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books => Set<Book>();
        public DbSet<BookAuthor> BookAuthors => Set<BookAuthor>();
        public DbSet<BookBorrowActivity> BookBorrowActivities => Set<BookBorrowActivity>();
        public DbSet<Page> Pages => Set<Page>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<User> Users => Set<User>();

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }
    }
}