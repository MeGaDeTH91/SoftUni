namespace MyBlog.CommonModels.BindingModels.Books
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class AddBookAuthorGenreBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.BookAuthorGenreConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.BookAuthorGenreConstraints.NameMaxLength)]
        public string AuthorGenreName { get; set; }
    }
}
