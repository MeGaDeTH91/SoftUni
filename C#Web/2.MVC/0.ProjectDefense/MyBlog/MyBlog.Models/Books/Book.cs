namespace MyBlog.Models.Books
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Models.Users;
    using MyBlog.Common;

    public class Book
    {
        public Book()
        {
            this.PhotoURL = "https://www.tonywrighton.com/wp-content/uploads/A-Good-Lifetime-Habit-Read-More-Books-to-Expand-Your-Sense-of-Life---.jpg";

            this.AddedToFavoritesBy = new List<UserBooks>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.BookConstraints.TitleMinLength)]
        [MaxLength(ValidationConstants.BookConstraints.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public int BookAuthorId { get; set; }
        public BookAuthor BookAuthor { get; set; }

        [Required]
        [MinLength(ValidationConstants.BookConstraints.DescriptionMinLength)]
        public string Description { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [DataType(DataType.ImageUrl, ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        public string PhotoURL { get; set; }
        
        [Required]
        [DataType(DataType.Url, ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        public string AdditionalInfoURL { get; set; }
        
        [Required]
        public int BookCategoryId { get; set; }

        public BookCategory BookCategory { get; set; }
        
        public ICollection<UserBooks> AddedToFavoritesBy { get; set; }
    }
}
