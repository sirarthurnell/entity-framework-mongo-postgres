using Bookstore.Data.MongoDb.Configuration;
using Bookstore.Data.MongoDb.Db;
using Bookstore.Data.MongoDb.Mappers;
using Bookstore.Data.Repositories;

namespace Bookstore.Data.MongoDb.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        static UnitOfWork()
        {
            var bookMapper = new BookMapper();
            bookMapper.Init();
        }

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

        public void Complete() {}
        
        public void Dispose() {}
    }
}