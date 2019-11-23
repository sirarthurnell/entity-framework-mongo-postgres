using Bookstore.Data.Entities;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Bookstore.Data.MongoDb.Mappers
{
    class BookMapper : IMapper
    {
        public void Init()
        {
            BsonClassMap.RegisterClassMap<Book>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(book => book.Id).SetIdGenerator(ObjectIdGenerator.Instance);
                cm.MapMember(book => book.BookName).SetElementName("Name");
            });
        }
    }
}