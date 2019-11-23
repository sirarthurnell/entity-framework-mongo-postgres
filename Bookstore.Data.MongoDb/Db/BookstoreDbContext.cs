using Bookstore.Data.Entities;
using Bookstore.Data.MongoDb.Configuration;
using MongoDB.Driver;

namespace Bookstore.Data.MongoDb.Db
{
    class BookstoreDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly IBookstoreDatabaseSettings _settings;

        public BookstoreDbContext(IBookstoreDatabaseSettings settings)
        {
            _settings = settings;

            var client = new MongoClient(_settings.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(_settings.DatabaseName);
        }

        public IMongoCollection<Book> Books
        {
            get
            {
                return _database.GetCollection<Book>(_settings.BooksCollectionName);
            }
        }
    }
}