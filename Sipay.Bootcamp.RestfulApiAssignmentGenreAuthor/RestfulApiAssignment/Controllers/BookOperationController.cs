using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestfulApiAssignment.Books;
using static RestfulApiAssignment.Models.BookOperationModel;

namespace RestfulApiAssignment.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookOperationController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookOperationController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound("Book not found");
            }

            var outputModel = new BookOutputModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author
            };

            return Ok(outputModel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, UpdateBookInputModel inputModel)
        {
            var existingBook = _bookService.GetBookById(id);
            if (existingBook == null)
            {
                return NotFound("Book not found");
            }

            existingBook.Title = inputModel.Title;
            existingBook.Author = inputModel.Author;

            _bookService.UpdateBook(existingBook);

            var outputModel = new BookOutputModel
            {
                Id = existingBook.Id,
                Title = existingBook.Title,
                Author = existingBook.Author
            };

            return Ok(outputModel);
        }
    }
}