namespace LibraryApp.Data.Entity
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }= string.Empty;
        public string Author { get; set; } = string.Empty;
        public bool IsPublished { get; set; }        
        public DateTime PublishDate { get; set; }
        public bool IsBorrowed { get; set; }        

        public List<Page> Pages { get; set; } = new();
        public List<BookAuthor> BookAuthors { get; set; } = new();
        public List<BookBorrowActivity> BookBorrowActivities { get; set; } = new();
    }
}