namespace BookApp.Server.Features.Books
{
    using BookApp.Server.Data;
    using BookApp.Server.Data.Models;
    using BookApp.Server.Features.Books.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public class BookService : IBookService
    {
        private readonly AppDbContext data;

        public BookService(AppDbContext data)
        {
            this.data = data;
        }

        public async Task<int> Create(string title, string description, string imageUrl, string authorName, double price)
        {
            var book = new Book()
            {
                Title = title,
                Description = description,
                ImageUrl = imageUrl,
                AuthorName = authorName,
                Price = price
            };

            this.data.Add(book);

            await this.data.SaveChangesAsync();

            return book.Id;
        }

        public async Task<BookInfoServiceModel> GetBy(int id)
        {
            var book = await this.data
                .Books
                .Where(b => b.Id == id)
                .Select(b => new BookInfoServiceModel
                {
                    Title = b.Title,
                    Description = b.Description,
                    ImageUrl = b.ImageUrl,
                    AuthorName = b.AuthorName,
                    Price = b.Price
                })
                .FirstOrDefaultAsync();

            return book;
        }
    }
}