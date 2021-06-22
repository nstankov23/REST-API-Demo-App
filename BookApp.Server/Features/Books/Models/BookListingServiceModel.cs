namespace BookApp.Server.Features.Books.Models
{
    public class BookListingServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public double Price { get; set; }
    }
}