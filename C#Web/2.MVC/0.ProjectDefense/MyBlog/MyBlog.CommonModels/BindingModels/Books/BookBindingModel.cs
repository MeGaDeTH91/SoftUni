namespace MyBlog.CommonModels.BindingModels.Books
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class BookBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.BookConstraints.TitleMinLength)]
        [MaxLength(ValidationConstants.BookConstraints.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [Display(Name = CommonConstants.BookAuthorDisplay)]
        public string BookAuthorStr { get; set; }

        [Required]
        [MinLength(ValidationConstants.BookConstraints.DescriptionMinLength)]
        public string Description { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [DataType(DataType.ImageUrl, ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [Display(Name = CommonConstants.PhotoUrlDisplay)]
        public string PhotoURL { get; set; }

        [Required]
        [DataType(DataType.Url, ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        [Display(Name = CommonConstants.AdditionalInfoDisplay)]
        public string AdditionalInfoURL { get; set; }

        [Required]
        [MinLength(ValidationConstants.BookCategoryConstraints.CategoryNameMinLength)]
        [MaxLength(ValidationConstants.BookCategoryConstraints.CategoryNameMaxLength)]
        [Display(Name = CommonConstants.BookCategoryDisplay)]
        public string BookCategoryStr { get; set; }
    }
}
