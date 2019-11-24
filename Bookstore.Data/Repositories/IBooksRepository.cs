using System;
using System.Collections.Generic;
using Bookstore.Data.Entities;

namespace Bookstore.Data.Repositories
{
    public interface IBooksRepository
    {
        IEnumerable<Book> GetAll();

        Book Get(Guid id);

        Book Create(Book book);

        void Update(Guid id, Book bookIn);

        void Remove(Book bookIn);

        void Remove(Guid id);
    }
}