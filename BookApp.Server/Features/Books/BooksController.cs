namespace BookApp.Server.Features.Books
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BookModel>> GetBy(int id)
        {
            return new BookModel()
            {
                Title = "Clean Code",
                Description = "Every year, countless hours and significant resources are lost because of poorly written code. But it doesn’t have to be that way. Noted software expert Robert C. Martin presents a revolutionary paradigm with Clean Code: A Handbook of Agile Software Craftsmanship . ",
                AuthorName = "Robert C. Martin",
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/81jRujEs6uL.jpg",
                Price = 30
            };
        }
    }
}