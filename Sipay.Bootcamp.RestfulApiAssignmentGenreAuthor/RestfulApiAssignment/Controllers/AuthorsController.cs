using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulApiAssignment.AuthorService;
using RestfulApiAssignment.Models;

namespace RestfulApiAssignment.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            var authors = _authorService.GetAllAuthors();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound("Author not found");
            }

            return Ok(author);
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] Author author)
        {
            if (author == null)
            {
                return BadRequest("Invalid author data");
            }

            _authorService.CreateAuthor(author);

            return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, author);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] Author updatedAuthor)
        {
            if (updatedAuthor == null)
            {
                return BadRequest("Invalid author data");
            }

            _authorService.UpdateAuthor(id, updatedAuthor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            _authorService.DeleteAuthor(id);

            return NoContent();
        }
    }
}
