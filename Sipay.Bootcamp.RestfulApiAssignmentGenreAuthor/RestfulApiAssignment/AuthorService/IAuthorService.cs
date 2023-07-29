using RestfulApiAssignment.Models;

namespace RestfulApiAssignment.AuthorService
{
    public interface IAuthorService
    {
        List<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        void CreateAuthor(Author author);
        void UpdateAuthor(int id, Author author);
        void DeleteAuthor(int id);
    }
}
