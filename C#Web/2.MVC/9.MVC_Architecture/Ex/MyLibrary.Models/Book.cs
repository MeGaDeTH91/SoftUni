namespace MyLibrary.Models
{
    using System.Collections.Generic;
    using MyLibrary.Common;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        private const string DefaultBookStatus = "At home";

        public Book()
        {
            this.Borrowers = new List<BookBorrow>();

            this.Status = DefaultBookStatus;

            this.IsBorrowed = false;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.BookConstants.TitleMinLength)]
        [MaxLength(ValidationConstants.BookConstants.TitleMaxLength)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public string CoverImage { get; set; }

        public bool IsBorrowed { get; set; }

        public string Status { get; set; }

        public ICollection<BookBorrow> Borrowers { get; set; }
    }
}
