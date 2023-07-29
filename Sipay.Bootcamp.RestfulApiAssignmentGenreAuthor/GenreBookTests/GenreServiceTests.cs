using Moq;
using RestfulApiAssignment.GenreService;
using RestfulApiAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GenreBookTests
{
    public class GenreServiceTests
    {
        private readonly List<Genre> _genres = new List<Genre>
        {
            new Genre { Id = 1, Name = "Fiction" },
            new Genre { Id = 2, Name = "Fantasy" },
            new Genre { Id = 3, Name = "Mystery" }
        };

        [Fact]
        public void GetAllGenres_ShouldReturnAllGenres()
        {
            var mockGenreService = new Mock<IGenreService>();
            mockGenreService.Setup(service => service.GetAllGenres()).Returns(_genres);

            var genreService = mockGenreService.Object;

            var result = genreService.GetAllGenres();

            Assert.Equal(_genres.Count, result.Count);
            Assert.Equal(_genres, result);
        }

        [Fact]
        public void GetGenreById_ValidId_ShouldReturnCorrectGenre()
        {
            var genreId = 2;
            var genre = _genres.FirstOrDefault(g => g.Id == genreId);

            var mockGenreService = new Mock<IGenreService>();
            mockGenreService.Setup(service => service.GetGenreById(genreId)).Returns(genre);

            var genreService = mockGenreService.Object;

            var result = genreService.GetGenreById(genreId);

            Assert.NotNull(result);
            Assert.Equal(genreId, result.Id);
        }

        [Fact]
        public void GetGenreById_InvalidId_ShouldReturnNull()
        {
            var genreId = 100;

            var mockGenreService = new Mock<IGenreService>();
            mockGenreService.Setup(service => service.GetGenreById(genreId)).Returns((Genre)null);

            var genreService = mockGenreService.Object;

            var result = genreService.GetGenreById(genreId);

            Assert.Null(result);
        }

        [Fact]
        public void CreateGenre_ValidGenre_ShouldAddToGenreList()
        {
            var newGenre = new Genre { Id = 4, Name = "Science Fiction" };

            var mockGenreService = new Mock<IGenreService>();
            mockGenreService.Setup(service => service.CreateGenre(newGenre));

            var genreService = mockGenreService.Object;

            genreService.CreateGenre(newGenre);

            Assert.Contains(newGenre, _genres);
        }

        [Fact]
        public void UpdateGenre_ValidGenre_ShouldUpdateGenreName()
        {
            var genreId = 2;
            var updatedGenre = new Genre { Id = genreId, Name = "Updated Genre" };

            var mockGenreService = new Mock<IGenreService>();
            mockGenreService.Setup(service => service.UpdateGenre(genreId, updatedGenre));

            var genreService = mockGenreService.Object;

            genreService.UpdateGenre(genreId, updatedGenre);

            var genre = _genres.FirstOrDefault(g => g.Id == genreId);
            Assert.NotNull(genre);
            Assert.Equal(updatedGenre.Name, genre.Name);
        }

        [Fact]
        public void DeleteGenre_ValidId_ShouldRemoveGenreFromList()
        {
            var genreId = 3;

            var mockGenreService = new Mock<IGenreService>();
            mockGenreService.Setup(service => service.DeleteGenre(genreId));

            var genreService = mockGenreService.Object;

            genreService.DeleteGenre(genreId);

            var genre = _genres.FirstOrDefault(g => g.Id == genreId);
            Assert.Null(genre);
        }
    }
}
