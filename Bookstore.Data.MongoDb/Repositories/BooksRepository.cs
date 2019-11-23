using System.Collections.Generic;
using Bookstore.Data.Entities;
using Bookstore.Data.MongoDb.Db;
using Bookstore.Data.Repositories;
using MongoDB.Driver;

namespace Bookstore.Data.MongoDb.Repositories
{
    class BooksRepository : IBooksRepository
    {
        private readonly IMongoCollection<Book> _books;

        public BooksRepository(BookstoreDbContext context)
        {
            _books = context.Books;
        }        

        public Book Create(Book book)
        {
            _books.InsertOneAsync(book);
            return book;
        }

        public Book Get(string id)
        {
            return _books
                .Find<Book>(book => book.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Book> GetAll()
        {
            return _books
                .Find<Book>(book => true)
                .ToList();
        }

        public void Remove(Book bookIn)
        {
            Remove(bookIn.Id);
        }

        public void Remove(string id)
        {
            _books.DeleteOne(book => book.Id == id);
        }

        public void Update(string id, Book bookIn)
        {
            _books.ReplaceOne(book => book.Id == id, bookIn);
        }
    }
}