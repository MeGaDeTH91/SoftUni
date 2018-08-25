namespace MyBlog.CommonModels.BindingModels.Fun
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class AddJokeBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.JokeConstraints.TitleMinLength)]
        [MaxLength(ValidationConstants.JokeConstraints.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ValidationConstants.JokeConstraints.ContentMinLength)]
        public string Content { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [DataType(DataType.ImageUrl, ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [Display(Name = CommonConstants.PhotoUrlDisplay)]
        public string PhotoURL { get; set; }
    }
}
