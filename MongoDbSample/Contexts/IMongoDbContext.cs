using MongoDB.Driver;

namespace MongoDbSample.Contexts;

public interface IMongoDbContext
{
    IMongoCollection<T> GetCollection<T>(string name);
}