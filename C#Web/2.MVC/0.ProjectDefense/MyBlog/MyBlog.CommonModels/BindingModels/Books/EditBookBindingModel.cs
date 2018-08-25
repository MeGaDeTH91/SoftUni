namespace MyBlog.CommonModels.BindingModels.Books
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class EditBookBindingModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [MinLength(ValidationConstants.BookConstraints.DescriptionMinLength)]
        public string Description { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [DataType(DataType.ImageUrl, ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        public string PhotoURL { get; set; }

        [Required]
        [DataType(DataType.Url, ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        public string AdditionalInfoURL { get; set; }
    }
}
