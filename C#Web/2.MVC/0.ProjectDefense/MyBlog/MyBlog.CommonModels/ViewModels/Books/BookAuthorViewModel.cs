namespace MyBlog.CommonModels.ViewModels.Books
{
    using System.Collections.Generic;

    public class BookAuthorViewModel
    {
        public string FullName { get; set; }
        
        public string PhotoURL { get; set; }
        
        public string HighLightVideoURL { get; set; }

        public string AdditionalInfoURL { get; set; }
        
        public string Description { get; set; }

        public int BookAuthorGenreId { get; set; }

        public BookAuthorGenreViewModel BookAuthorGenre { get; set; }

        public ICollection<BookConciseViewModel> Books { get; set; }
    }
}
