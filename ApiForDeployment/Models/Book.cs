using MongoDB.Bson.Serialization.Attributes;

namespace ApiForDeployment.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? PublishedYear { get; set; }
    }
}
