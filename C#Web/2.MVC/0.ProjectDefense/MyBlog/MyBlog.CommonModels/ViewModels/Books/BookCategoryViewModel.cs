namespace MyBlog.CommonModels.ViewModels.Books
{
    using System.Collections.Generic;

    public class BookCategoryViewModel
    {
        public string BookCategoryName { get; set; }

        public ICollection<BookConciseViewModel> Books { get; set; }
    }
}
