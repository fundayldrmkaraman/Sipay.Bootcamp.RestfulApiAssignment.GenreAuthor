using Microsoft.EntityFrameworkCore;
using RestfulApiAssignment.Models;

namespace RestfulApiAssignment.DbContext
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }
        public DbSet<BookOperationModel> BookOperationModels { get; set; }
    }
}
