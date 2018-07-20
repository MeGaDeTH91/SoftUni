using MyLibrary.Models;
using System;

namespace MyLibrary.Web.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public string Author { get; set; }

        public static Func<Book, BookViewModel> MapFromBook
        {
            get
            {
                return book => new BookViewModel()
                {
                    Author = book.Author.Name,
                    AuthorId = book.AuthorId,
                    BookId = book.Id,
                    Title = book.Title
                };
            }
        }
    }
}
