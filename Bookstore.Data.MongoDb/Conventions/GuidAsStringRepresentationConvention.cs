using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;

namespace Bookstore.Data.MongoDb.Conventions
{
    public class GuidAsStringRepresentationConvention : ConventionBase, IMemberMapConvention
    {
        public void Apply(BsonMemberMap memberMap)
        {
            if (memberMap.MemberType == typeof(Guid))
            {
                var serializer = memberMap.GetSerializer();
                var representationConfigurableSerializer = serializer as IRepresentationConfigurable;
                if (representationConfigurableSerializer != null)
                {
                    var reconfiguredSerializer = representationConfigurableSerializer.WithRepresentation(BsonType.String);
                    memberMap.SetSerializer(reconfiguredSerializer);
                }
            }
        }
    }
}

