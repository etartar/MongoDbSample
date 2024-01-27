namespace MongoDbSample.Requests;

public class CreateBookRequest
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public string Author { get; set; }
}
