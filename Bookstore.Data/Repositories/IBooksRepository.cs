using System.Collections.Generic;
using Bookstore.Data.Entities;

namespace Bookstore.Data.Repositories
{
    public interface IBooksRepository
    {
        IEnumerable<Book> GetAll();

        Book Get(string id);

        Book Create(Book book);

        void Update(string id, Book bookIn);

        void Remove(Book bookIn);

        void Remove(string id);
    }
}