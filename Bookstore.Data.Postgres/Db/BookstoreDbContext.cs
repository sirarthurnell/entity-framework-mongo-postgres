using Bookstore.Data.Entities;
using Bookstore.Data.Postgres.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Data.Postgres.Db
{
    public class BookstoreDbContext : DbContext
    {
        private readonly IBookstoreDatabaseSettings _settings;

        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options) {}

        public virtual DbSet<Book> Books { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseNpgsql(_settings.ConnectionString);
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {}
    }
}