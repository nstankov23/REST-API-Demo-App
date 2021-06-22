namespace BookApp.Server.Features.Books
{
    using BookApp.Server.Features.Books.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using static Infrastructure.WebConstants;

    public class BooksController : ApiController
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<BookListingServiceModel>> GetAll()
        {
            var books = await this.bookService.GetAll();

            return books;
        }

        [HttpGet]
        [Route(Id)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookInfoServiceModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookInfoServiceModel>> GetBy(int id)
        {
            var book = await this.bookService.GetBy(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        [HttpDelete]
        [Route(Id)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await this.bookService.Delete(id);

            if (!deleted)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}