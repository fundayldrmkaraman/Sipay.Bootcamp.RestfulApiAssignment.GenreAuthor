using RestfulApiAssignment.Models;

namespace RestfulApiAssignment.GenreService
{
    public class GenreService:IGenreService
    {
        public readonly List<Genre> _genres = new List<Genre>();
        public GenreService()
        {
            _genres.Add(new Genre { Id = 1, Name = "Fiction" });
            _genres.Add(new Genre { Id = 2, Name = "Fantasy" });
        }
        public List<Genre> GetAllGenres()
        {
            return _genres;
        }
        public Genre GetGenreById(int id)
        {
            return _genres.FirstOrDefault(g => g.Id == id);
        }
        public void CreateGenre(Genre genre)
        {
            genre.Id = _genres.Max(g => g.Id) + 1;
            _genres.Add(genre);
        }
        public void UpdateGenre(int id, Genre updatedGenre)
        {
            var existingGenre = _genres.FirstOrDefault(g => g.Id == id);
            if (existingGenre != null)
            {
                existingGenre.Name = updatedGenre.Name;
            }
        }
        public void DeleteGenre(int id)
        {
            var genreToDelete = _genres.FirstOrDefault(g => g.Id == id);
            if (genreToDelete != null)
            {
                _genres.Remove(genreToDelete);
            }
        }
    }
}
