namespace MyLibrary.Models
{
    using MyLibrary.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Borrower
    {
        public Borrower()
        {
            this.BorrowedBooks = new List<BookBorrow>();
            this.BorrowedMovies = new List<MovieBorrow>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.BorrowerConstants.NameMinLength)]
        [MaxLength(ValidationConstants.BorrowerConstants.NameMaxLength)]
        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<BookBorrow> BorrowedBooks { get; set; }

        public ICollection<MovieBorrow> BorrowedMovies { get; set; }
    }
}
