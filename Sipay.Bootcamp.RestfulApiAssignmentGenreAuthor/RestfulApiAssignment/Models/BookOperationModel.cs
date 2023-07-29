using System.Diagnostics.Contracts;

namespace RestfulApiAssignment.Models
{
    public class BookOperationModel
    {
        public class UpdateBookInputModel
        {
            public string Title { get; set; }
            public string Author { get; set; }
        }

        public class BookOutputModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
        }
        public class GetByIdInputModel
        {
            public int Id { get; set; }
        }
        public class DeleteBookInputModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
        }
    }
}
