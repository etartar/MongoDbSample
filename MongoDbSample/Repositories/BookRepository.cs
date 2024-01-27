using MongoDbSample.Contexts;
using MongoDbSample.Entities;
using MongoDbSample.Repositories.Base;

namespace MongoDbSample.Repositories;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    public BookRepository(IMongoDbContext mongoContext) : base(mongoContext)
    {
    }
}
