namespace BookApp.Server.Features.Books
{
    using BookApp.Server.Features.Books.Models;
    using System.Threading.Tasks;

    public interface IBookService
    {
        Task<BookInfoServiceModel> GetBy(int id);

        Task<int> Create(string title, string description, string imageUrl, string authorName, double price);
    }
}