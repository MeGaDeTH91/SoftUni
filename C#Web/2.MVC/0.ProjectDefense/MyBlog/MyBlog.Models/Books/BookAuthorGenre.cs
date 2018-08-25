namespace MyBlog.Models.Books
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class BookAuthorGenre
    {
        public BookAuthorGenre()
        {
            this.Authors = new List<BookAuthor>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.BookAuthorGenreConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.BookAuthorGenreConstraints.NameMaxLength)]
        public string AuthorGenreName { get; set; }

        public ICollection<BookAuthor> Authors { get; set; }
    }
}
