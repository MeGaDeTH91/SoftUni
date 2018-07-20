namespace MyLibrary.Models
{
    using System.Collections.Generic;

    public class Book
    {
        public Book()
        {
            this.Borrowers = new List<BookBorrow>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public string CoverImage { get; set; }

        public ICollection<BookBorrow> Borrowers { get; set; }
    }
}
