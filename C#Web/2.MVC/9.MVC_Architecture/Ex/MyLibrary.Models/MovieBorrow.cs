namespace MyLibrary.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class MovieBorrow
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        [Required]
        public int BorrowerId { get; set; }

        public Borrower Borrower { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
