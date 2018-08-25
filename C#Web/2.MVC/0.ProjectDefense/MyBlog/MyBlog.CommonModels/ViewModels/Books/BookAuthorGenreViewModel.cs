namespace MyBlog.CommonModels.ViewModels.Books
{
    using System.Collections.Generic;

    public class BookAuthorGenreViewModel
    {
        public string AuthorGenreName { get; set; }

        public ICollection<BookAuthorViewModel> Authors { get; set; }
    }
}
