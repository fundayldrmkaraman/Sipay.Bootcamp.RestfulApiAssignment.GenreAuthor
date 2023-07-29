using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestfulApiAssignment.Models; 
using RestfulApiAssignment.Books;

namespace BookLibrary.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        public readonly IBookService _bookService;
        public BookController(IBookService bookService)
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

            var outputModel = new Book
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author
            };

            return Ok(outputModel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, UpdateBook inputModel)
        {
            var existingBook = _bookService.GetBookById(id);
            if (existingBook == null)
            {
                return NotFound("Book not found");
            }

            existingBook.Title = inputModel.Title;
            existingBook.Author = inputModel.Author;

            _bookService.UpdateBook(existingBook);

            var outputModel = new Book
            {
                Id = existingBook.Id,
                Title = existingBook.Title,
                Author = existingBook.Author
            };
            return Ok(outputModel);
        }
    }
}

