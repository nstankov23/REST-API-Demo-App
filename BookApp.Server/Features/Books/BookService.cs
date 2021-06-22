namespace BookApp.Server.Features.Books
{
    using BookApp.Server.Data;
    using BookApp.Server.Data.Models;
    using BookApp.Server.Features.Books.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
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

        public async Task<bool> Update(int id, string title, string description, string imageUrl, string authorName, double price)
        {
            var book = await this.data
                .Books
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return false;
            }

            book.Title = title;
            book.Description = description;
            book.ImageUrl = imageUrl;
            book.AuthorName = authorName;
            book.Price = price;

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var book = await this.data
                .Books
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return false;
            }

            this.data.Books.Remove(book);

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<BookListingServiceModel>> GetAll()
        {
            var books = await this.data
                .Books
                .Select(b => new BookListingServiceModel
                {
                    Title = b.Title,
                    ImageUrl = b.ImageUrl,
                    Price = b.Price,
                })
                .ToListAsync();

            return books;
        }
    }
}