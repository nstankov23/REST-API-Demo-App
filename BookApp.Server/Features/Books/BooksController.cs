namespace BookApp.Server.Features.Books
{
    using BookApp.Server.Features.Books.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult<BookInfoServiceModel>> GetBy(int id)
        {
            var book = await this.bookService.GetBy(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateBookRequestModel request)
        {
            var bookId = await this.bookService.Create(
                request.Title,
                request.Description,
                request.ImageUrl,
                request.AuthorName,
                request.Price);

            return Created(nameof(this.Create), bookId);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateBookRequestModel request)
        {
            var updated = await this.bookService.Update(
                request.Id,
                request.Title,
                request.Description,
                request.ImageUrl,
                request.AuthorName,
                request.Price);

            if (!updated)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}