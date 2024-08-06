namespace LibraryApp.Data.Entity
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }

        public Role Role { get; set; } = null!;
        public List<BookAuthor> BookAuthors { get; set; } = new();
        public List<BookBorrowActivity> BookActivities { get; set; } = new();
    }
}