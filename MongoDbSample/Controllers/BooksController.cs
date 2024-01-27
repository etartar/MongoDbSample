using Microsoft.AspNetCore.Mvc;
using MongoDbSample.Entities;
using MongoDbSample.Repositories;
using MongoDbSample.Requests;

namespace MongoDbSample.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BooksController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        IEnumerable<Book> books = await _bookRepository.GetAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook([FromRoute] string id)
    {
        Book book = await _bookRepository.GetAsync(id);

        if (book is null)
            return BadRequest("Book not found.");

        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(CreateBookRequest request)
    {
        await _bookRepository.CreateAsync(new Book
        {
            Name = request.Name,
            Category = request.Category,
            Author = request.Author,
            Price = request.Price,
        });

        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBook(UpdateBookRequest request)
    {
        Book book = await _bookRepository.GetAsync(request.Id);

        if (book is null)
            return BadRequest("Book not found.");

        book.Name = request.Name;
        book.Category = request.Category;
        book.Author = request.Author;
        book.Price = request.Price;

        await _bookRepository.UpdateAsync(request.Id, book);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook([FromRoute] string id)
    {
        Book book = await _bookRepository.GetAsync(id);

        if (book is null)
            return BadRequest("Book not found.");

        await _bookRepository.DeleteAsync(id);

        return NoContent();
    }
}
