namespace MyLibrary.Models
{
    using MyLibrary.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Author
    {
        public Author()
        {
            this.Books = new List<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.AuthorConstants.NameMinLength)]
        [MaxLength(ValidationConstants.AuthorConstants.NameMaxLength)]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
