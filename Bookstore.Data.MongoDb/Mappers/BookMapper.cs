using Bookstore.Data.Entities;
using Bookstore.Data.MongoDb.Conventions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Bookstore.Data.MongoDb.Mappers
{
    class BookMapper : IMapper
    {
        public void Init()
        {
            var pack = new ConventionPack { new GuidAsStringRepresentationConvention() };
            ConventionRegistry.Register("GuidAsString", pack, t => t == typeof(Book));

            BsonClassMap.RegisterClassMap<Book>(cm =>
            {
                cm.AutoMap();
                // cm.MapIdMember(book => book.Id)
                //     .SetIdGenerator(StringObjectIdGenerator.Instance)
                //     .SetSerializer(new StringSerializer(BsonType.ObjectId));

                cm.MapMember(book => book.BookName).SetElementName("Name");
            });
        }
    }
}