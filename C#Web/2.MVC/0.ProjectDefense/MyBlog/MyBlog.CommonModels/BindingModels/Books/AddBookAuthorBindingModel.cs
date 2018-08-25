namespace MyBlog.CommonModels.BindingModels.Books
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class AddBookAuthorBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.BookAuthorConstraints.FullNameMinLength)]
        [MaxLength(ValidationConstants.BookAuthorConstraints.FullNameMaxLength)]
        public string FullName { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [DataType(DataType.ImageUrl, ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        public string PhotoURL { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        [DataType(DataType.Url, ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        public string HighLightVideoURL { get; set; }

        [DataType(DataType.Url, ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        public string AdditionalInfoURL { get; set; }

        [Required]
        [MinLength(ValidationConstants.BookAuthorConstraints.DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public string BookAuthorGenreStr { get; set; }
    }
}
