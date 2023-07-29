namespace RestfulApiAssignment.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }

    }
    public class UpdateBook
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
    }
}
