using RestfulApiAssignment.Models;

namespace RestfulApiAssignment.GenreService
{
    public interface IGenreService
    {
        List<Genre> GetAllGenres();
        Genre GetGenreById(int id);
        void CreateGenre(Genre genre);
        void UpdateGenre(int id, Genre genre);
        void DeleteGenre(int id);
    }
}
