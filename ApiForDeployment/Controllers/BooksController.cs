using ApiForDeployment.Models;
using ApiForDeployment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiForDeployment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(BookService bookService)
        : ControllerBase
    {
        private readonly BookService _bookService = bookService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            await _bookService.CreateAsync(book);
            return Ok(book.Id);
        }
    }
}
