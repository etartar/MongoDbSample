using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbSample.Entities;

public class Book : IMongoEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("price")]
    public decimal Price { get; set; }

    [BsonElement("category")]
    public string Category { get; set; }

    [BsonElement("author")]
    public string Author { get; set; }
}
