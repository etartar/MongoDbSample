using MongoDbSample.Entities;
using MongoDbSample.Repositories.Base;

namespace MongoDbSample.Repositories;

public interface IBookRepository : IBaseRepository<Book>
{
}
