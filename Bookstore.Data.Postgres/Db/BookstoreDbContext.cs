using Bookstore.Data.Entities;
using Bookstore.Data.Postgres.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Data.Postgres.Db
{
    class BookstoreDbContext : DbContext
    {
        private readonly IBookstoreDatabaseSettings _settings;

        public BookstoreDbContext(IBookstoreDatabaseSettings settings)
        {
            _settings = settings;
        }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_settings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {}
    }
}