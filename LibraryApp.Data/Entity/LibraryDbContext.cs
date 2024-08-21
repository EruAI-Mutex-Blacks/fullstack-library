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
        public DbSet<Message> Messages => Set<Message>();

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Book 1", PublishDate = DateTime.UtcNow.AddDays(-130), IsBorrowed = false, IsPublished = true },
                new Book { Id = 2, Title = "Book 2", PublishDate = DateTime.UtcNow.AddDays(-13), IsBorrowed = false, IsPublished = true },
                new Book { Id = 3, Title = "Book 3", PublishDate = DateTime.UtcNow.AddDays(-159), IsBorrowed = false, IsPublished = true }
            );

            modelBuilder.Entity<BookAuthor>().HasData(
                new BookAuthor { Id = 1, BookId = 1, UserId = 3 },
                new BookAuthor { Id = 2, BookId = 2, UserId = 3 },
                new BookAuthor { Id = 3, BookId = 3, UserId = 3 }
            );

            modelBuilder.Entity<BookBorrowActivity>().HasData(
                new BookBorrowActivity { Id = 1, BookId = 1, UserId = 1, BorrowDate = DateTime.UtcNow.AddDays(-7), ReturnDate = DateTime.UtcNow.AddDays(-1) },
                new BookBorrowActivity { Id = 2, BookId = 2, UserId = 2, BorrowDate = DateTime.UtcNow.AddDays(-14), ReturnDate = DateTime.UtcNow.AddDays(-7) },
                new BookBorrowActivity { Id = 3, BookId = 3, UserId = 3, BorrowDate = DateTime.UtcNow.AddDays(-21), ReturnDate = DateTime.UtcNow.AddDays(-14) }
            );

            modelBuilder.Entity<Page>().HasData(
                new Page { Id = 1, BookId = 1, Content = "Page 1 Content" },
                new Page { Id = 2, BookId = 1, Content = "Page 2 Content" },
                new Page { Id = 3, BookId = 2, Content = "Page 1 Content" }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "pendingUser" },
                new Role { Id = 2, Name = "member" },
                new Role { Id = 3, Name = "author" },
                new Role { Id = 4, Name = "staff" },
                new Role { Id = 5, Name = "manager" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "User 1", Surname = "surname1", Username = "sr1", Password = "123", BirthDate = DateTime.UtcNow.AddDays(-11344), Gender = 'M', RoleId = 1, IsPunished = false, FineAmount = 0 },
                new User { Id = 2, Name = "User 2", Surname = "surname2", Username = "sr12", Password = "123", BirthDate = DateTime.UtcNow.AddDays(-14341), Gender = 'W', RoleId = 2, IsPunished = false, FineAmount = 0 },
                new User { Id = 3, Name = "User 3", Surname = "surname3", Username = "sr123", Password = "123", BirthDate = DateTime.UtcNow.AddDays(-14665), Gender = 'W', RoleId = 3, IsPunished = false, FineAmount = 0 }
            );

            modelBuilder.Entity<Message>().HasData(
                new Message { Id = 1, SenderId = 1, ReceiverId = 2, Title = "Title test 1", Details = "Selam, nasılsın? Bir konu hakkında soru soracaktım", IsReceiverRead = false },
                new Message { Id = 2, SenderId = 1, ReceiverId = 3, Title = "Title test 2", Details = "iş nasıl gidiyor", IsReceiverRead = false },
                new Message { Id = 3, SenderId = 2, ReceiverId = 1, Title = "Title test 3", Details = "yeni tshirt aldım", IsReceiverRead = false },
                new Message { Id = 4, SenderId = 2, ReceiverId = 3, Title = "Title test 4", Details = "çalışın ulan! anca dedikodu", IsReceiverRead = false },
                new Message { Id = 5, SenderId = 3, ReceiverId = 2, Title = "Title test 5", Details = "Sakin ol patron", IsReceiverRead = false }
            );
        }
    }
}