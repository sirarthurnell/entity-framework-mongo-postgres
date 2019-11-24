using System;
using System.Collections.Generic;
using System.Linq;
using Bookstore.Data.Entities;
using Bookstore.Data.Postgres.Db;
using Bookstore.Data.Repositories;

namespace Bookstore.Data.Postgres.Repositories
{
    class BooksRepository : IBooksRepository
    {
        private readonly BookstoreDbContext _context;

        public BooksRepository(BookstoreDbContext context)
        {
            _context = context;
        }        

        public Book Create(Book book)
        {
            _context.Books.Add(book);
            return book;
        }

        public Book Get(Guid id)
        {
            return _context.Books.FirstOrDefault(book => book.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public void Remove(Book bookIn)
        {
            Remove(bookIn.Id);
        }

        public void Remove(Guid id)
        {
            var bookToRemove = Get(id);
            if (bookToRemove != null)
            {
                _context.Books.Remove(bookToRemove);
            }
        }

        public void Update(Guid id, Book bookIn)
        {
            var bookToUpdate = Get(id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Author = bookIn.Author;
                bookToUpdate.BookName = bookIn.BookName;
                bookToUpdate.Category = bookIn.Category;
                bookToUpdate.Price = bookIn.Price;
            }
        }
    }
}