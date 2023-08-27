using Microsoft.AspNetCore.Mvc;
using Summaries.Data;
using Summaries.Data.Models;

namespace Summaries.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController: ControllerBase
    {
        private IBookService bookService;
        public BooksController(IBookService service)
        {
            bookService = service;
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook([FromBody]Book book)
        {
            bookService.AddBook(book);
            return Ok();
        }
        [HttpGet("[action]")]
        public IActionResult GetBooks()
        {
            var allBooks = bookService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpPut("UpdateBook/{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            bookService.UpdateBook(id, book);
            return Ok(book);
        }

        [HttpDelete("DeleteBook/{id}")]
        public IActionResult DeleteBook(int id)
        {
            bookService.DeleteBook(id);
            return Ok();
        }

        [HttpGet("SingleBook/{id}")]
        public IActionResult GetBookById(int id)
        {
           var book = bookService.GetBookById(id);
           return Ok(book);
        }
    }


}