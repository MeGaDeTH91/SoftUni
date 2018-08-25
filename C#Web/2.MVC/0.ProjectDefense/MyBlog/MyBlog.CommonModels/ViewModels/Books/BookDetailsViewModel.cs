namespace MyBlog.CommonModels.ViewModels.Books
{
    using MyBlog.Models.Users;
    using System.Collections.Generic;

    public class BookDetailsViewModel
    {
        public string Title { get; set; }

        public int BookAuthorId { get; set; }
        public BookAuthorViewModel BookAuthor { get; set; }

        public string Description { get; set; }

        public string PhotoURL { get; set; }

        public string AdditionalInfoURL { get; set; }

        public int BookCategoryId { get; set; }

        public BookCategoryViewModel BookCategory { get; set; }

        public ICollection<UserBooks> AddedToFavoritesBy { get; set; }
    }
}
