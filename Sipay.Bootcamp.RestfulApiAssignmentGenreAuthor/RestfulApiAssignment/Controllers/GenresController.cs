using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulApiAssignment.DbContext;
using RestfulApiAssignment.GenreService;
using RestfulApiAssignment.Models;

namespace RestfulApiAssignment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        public readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpGet]
        public IActionResult GetAllGenres()
        {
            var genres = _genreService.GetAllGenres();
            return Ok(genres);
        }
        [HttpGet("{id}")]
        public IActionResult GetGenreById(int id)
        {
            var genre = _genreService.GetGenreById(id);
            if (genre == null)
            {
                return NotFound("Genre not found");
            }

            return Ok(genre);
        }
        [HttpPost]
        public IActionResult CreateGenre([FromBody] Genre genre)
        {
            if (genre == null)
            {
                return BadRequest("Invalid genre data");
            }

            _genreService.CreateGenre(genre);

            return CreatedAtAction(nameof(GetGenreById), new { id = genre.Id }, genre);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] Genre updatedGenre)
        {
            if (updatedGenre == null)
            {
                return BadRequest("Invalid genre data");
            }

            _genreService.UpdateGenre(id, updatedGenre);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            _genreService.DeleteGenre(id);
            return NoContent();
        }
    }
}
