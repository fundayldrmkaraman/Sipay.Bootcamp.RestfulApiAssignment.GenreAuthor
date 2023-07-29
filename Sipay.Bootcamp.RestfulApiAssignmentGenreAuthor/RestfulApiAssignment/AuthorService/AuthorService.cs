using RestfulApiAssignment.Models;

namespace RestfulApiAssignment.AuthorService
{
    public class AuthorService:IAuthorService
    {
        private readonly List<Author> _authors = new List<Author>();

        public AuthorService()
        {
            _authors.Add(new Author { Id = 1, Name = "John Doe" });
            _authors.Add(new Author { Id = 2, Name = "Jane Smith" });
        }
        public List<Author> GetAllAuthors()
        {
            return _authors;
        }
        public Author GetAuthorById(int id)
        {
            return _authors.FirstOrDefault(a => a.Id == id);
        }
        public void CreateAuthor(Author author)
        {
            author.Id = _authors.Max(a => a.Id) + 1;
            _authors.Add(author);
        }
        public void UpdateAuthor(int id, Author updatedAuthor)
        {
            var existingAuthor = _authors.FirstOrDefault(a => a.Id == id);
            if (existingAuthor != null)
            {
                existingAuthor.Name = updatedAuthor.Name;
            }
        }
        public void DeleteAuthor(int id)
        {
            var authorToDelete = _authors.FirstOrDefault(a => a.Id == id);
            if (authorToDelete != null)
            {
                _authors.Remove(authorToDelete);
            }
        }
    }
}
