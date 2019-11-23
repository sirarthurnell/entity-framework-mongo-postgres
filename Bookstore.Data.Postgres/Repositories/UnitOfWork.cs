using Bookstore.Data.Postgres.Configuration;
using Bookstore.Data.Postgres.Db;
using Bookstore.Data.Repositories;

namespace Bookstore.Data.Postgres.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IBookstoreDatabaseSettings _settings;
        private readonly BookstoreDbContext _context;
        private readonly IBooksRepository _booksRepository;
        
        public UnitOfWork(IBookstoreDatabaseSettings settings)
        {
            _settings = settings;
            _context = new BookstoreDbContext(_settings);
            _booksRepository = new BooksRepository(_context);
        }
        
        public IBooksRepository BooksRepository => _booksRepository;

        public void Complete() 
        {
            _context.SaveChanges();
        }
    }
}