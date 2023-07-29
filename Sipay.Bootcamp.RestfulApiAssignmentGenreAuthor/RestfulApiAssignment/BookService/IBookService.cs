using RestfulApiAssignment.Models;

namespace RestfulApiAssignment.Books
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        object GetBookById(int id);
        void UpdateBook(object existingBook);
    }
}
