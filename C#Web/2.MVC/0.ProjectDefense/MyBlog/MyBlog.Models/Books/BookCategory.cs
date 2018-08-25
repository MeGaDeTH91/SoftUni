namespace MyBlog.Models.Books
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class BookCategory
    {
        public BookCategory()
        {
            this.Books = new List<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.BookCategoryConstraints.CategoryNameMinLength)]
        [MaxLength(ValidationConstants.BookCategoryConstraints.CategoryNameMaxLength)]
        public string BookCategoryName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
