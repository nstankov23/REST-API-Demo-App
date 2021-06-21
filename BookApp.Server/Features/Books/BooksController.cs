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
            return await this.bookService.GetBy(id);
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
    }
}