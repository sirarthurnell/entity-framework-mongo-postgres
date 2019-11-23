using System;
using Bookstore.Data.Postgres.Db;
using Bookstore.Data.Repositories;

namespace Bookstore.Data.Postgres.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookstoreDbContext _context;
        private readonly IBooksRepository _booksRepository;
        private bool disposed = false;

        public UnitOfWork(BookstoreDbContext context)
        {
            _context = context;
            _booksRepository = new BooksRepository(_context);
        }

        public IBooksRepository BooksRepository => _booksRepository;

        public void Complete()
        {
            _context.SaveChanges();
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}