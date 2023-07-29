using Moq;
using RestfulApiAssignment.Books;
using RestfulApiAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GenreBookTests
{
    public class BookServiceTests
    {
        private readonly List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", Author = "Author 1" },
            new Book { Id = 2, Title = "Book 2", Author = "Author 2" },
            new Book { Id = 3, Title = "Book 3", Author = "Author 1" }
        };

        [Fact]
        public void GetAllBooks_ShouldReturnAllBooks()
        {
           var mockBookService = new Mock<IBookService>();
            mockBookService.Setup(service => service.GetAllBooks()).Returns(_books);

            var bookService = mockBookService.Object;
            var result = bookService.GetAllBooks();

            Assert.Equal(_books.Count, result.Count);
            Assert.Equal(_books, result);
        }

        [Fact]
        public void GetBookById_ValidId_ShouldReturnCorrectBook()
        {
            var bookId = 2;
            var book = _books.FirstOrDefault(b => b.Id == bookId);

            var mockBookService = new Mock<IBookService>();
            mockBookService.Setup(service => service.GetBookById(bookId)).Returns(book);

            var bookService = mockBookService.Object;

            var result = bookService.GetBookById(bookId);

            Assert.NotNull(result);
            Assert.Equal(bookId, result.Id);
        }

        [Fact]
        public void GetBookById_InvalidId_ShouldReturnNull()
        {
            var bookId = 100;

            var mockBookService = new Mock<IBookService>();
            mockBookService.Setup(service => service.GetBookById(bookId)).Returns((Book)null);

            var bookService = mockBookService.Object;

            var result = bookService.GetBookById(bookId);

            Assert.Null(result);
        }

        [Fact]
        public void CreateBook_ValidBook_ShouldAddToBookList()
        {
            var newBook = new Book { Id = 4, Title = "New Book", Author = "New Author" };

            var mockBookService = new Mock<IBookService>();
            mockBookService.Setup(service => service.CreateBook(newBook));

            var bookService = mockBookService.Object;

            bookService.CreateBook(newBook);

            Assert.Contains(newBook, _books);
        }

        [Fact]
        public void UpdateBook_ValidBook_ShouldUpdateBookDetails()
        {
            var bookId = 2;
            var updatedBook = new Book { Id = bookId, Title = "Updated Book", Author = "Updated Author" };

            var mockBookService = new Mock<IBookService>();
            mockBookService.Setup(service => service.UpdateBook(bookId, updatedBook));

            var bookService = mockBookService.Object;

            bookService.UpdateBook(bookId, updatedBook);

            var book = _books.FirstOrDefault(b => b.Id == bookId);
            Assert.NotNull(book);
            Assert.Equal(updatedBook.Title, book.Title);
            Assert.Equal(updatedBook.Author, book.Author);
        }

        [Fact]
        public void DeleteBook_ValidId_ShouldRemoveBookFromList()
        {
            var bookId = 3;

            var mockBookService = new Mock<IBookService>();
            mockBookService.Setup(service => service.DeleteBook(bookId));

            var bookService = mockBookService.Object;

            bookService.DeleteBook(bookId);

            var book = _books.FirstOrDefault(b => b.Id == bookId);
            Assert.Null(book);
        }
    }
}
