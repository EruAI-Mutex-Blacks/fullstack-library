
namespace LibraryApp.Data.Entity
{
    public class BookBorrowActivity
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime GivenDate { get; set; }
        public DateTime TakeBackDate { get; set; }

        public Book Book { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}