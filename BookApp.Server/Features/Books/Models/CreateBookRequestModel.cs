namespace BookApp.Server.Features.Books.Models
{
    public class CreateBookRequestModel
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string AuthorName { get; set; }

        public double Price { get; set; }
    }
}