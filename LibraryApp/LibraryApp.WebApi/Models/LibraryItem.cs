namespace LibraryApp.WebApi.Models
{
    public class LibraryItem
    {
        public int Id { get; set; }
        public int Task { get; set; }
        public bool IsCompleted { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
