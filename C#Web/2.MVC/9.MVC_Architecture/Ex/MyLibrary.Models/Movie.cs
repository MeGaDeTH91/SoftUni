namespace MyLibrary.Models
{
    using System.Collections.Generic;
    using MyLibrary.Common;
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        private const string DefaultBookStatus = "At home";

        public Movie()
        {
            this.Borrowers = new List<MovieBorrow>();

            this.Status = DefaultBookStatus;

            this.IsBorrowed = false;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MovieConstants.TitleMinLength)]
        [MaxLength(ValidationConstants.MovieConstants.TitleMaxLength)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int DirectorId { get; set; }

        public Director Director { get; set; }

        public string PosterImage { get; set; }

        public bool IsBorrowed { get; set; }

        public string Status { get; set; }

        public ICollection<MovieBorrow> Borrowers { get; set; }
    }
}
