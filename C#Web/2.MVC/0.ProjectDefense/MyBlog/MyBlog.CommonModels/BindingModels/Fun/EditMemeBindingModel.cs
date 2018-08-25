namespace MyBlog.CommonModels.BindingModels.Fun
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class EditMemeBindingModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MemeConstraints.TitleMinLength)]
        [MaxLength(ValidationConstants.MemeConstraints.TitleMaxLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [DataType(DataType.ImageUrl, ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        public string PhotoURL { get; set; }
    }
}
