using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestfulApiAssignment.BookValidation;
using RestfulApiAssignment.Books;
using static RestfulApiAssignment.Models.BookOperationModel;

namespace RestfulApiAssignment.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById([FromRoute] GetByIdInputModel inputModel)
        {
            var validator = new GetByIdInputModelValidator();
            var validationResult = validator.Validate(inputModel);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var book = _bookService.GetBookById(inputModel.Id);
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
        public IActionResult UpdateBook([FromRoute] int id, [FromBody] UpdateBookInputModel inputModel)
        {
            var validator = new UpdateBookInputModelValidator();
            var validationResult = validator.Validate(inputModel);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

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

        [HttpDelete("{id}")]
        public IActionResult DeleteBook([FromRoute] DeleteBookInputModel inputModel)
        {
            var validator = new DeleteBookInputModelValidator();
            var validationResult = validator.Validate(inputModel);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var book = _bookService.GetBookById(inputModel.Id);
            if (book == null)
            {
                return NotFound("Book not found");
            }

            _bookService.DeleteBook(inputModel.Id);

            return NoContent();
        }
    }
}
