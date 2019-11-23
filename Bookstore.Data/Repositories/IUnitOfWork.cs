using System;

namespace Bookstore.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBooksRepository BooksRepository { get; }
        void Complete();
    }
}