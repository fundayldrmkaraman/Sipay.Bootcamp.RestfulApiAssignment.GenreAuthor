using RestfulApiAssignment.Models;


namespace RestfulApiAssignment.Books
{
    public class BookService : IBookService
    {
        public List<Book> GetAllBooks()
        {
            return new List<Book>
            {
               new Book { Id = 1, Title = "Sefiller", Author = "Victor Hugo" },
               new Book { Id = 2, Title = "Beyaz Diş", Author = "Jack London" },
               new Book { Id = 3, Title= "Araba Sevdası", Author= "Recaizade Mahmut Ekrem"},
               new Book { Id = 4, Title= "Vadideki Zambak", Author= "Honoré de Balzac"}
            };
        }

        public object GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(object existingBook)
        {
            throw new NotImplementedException();
        }
    }
}
