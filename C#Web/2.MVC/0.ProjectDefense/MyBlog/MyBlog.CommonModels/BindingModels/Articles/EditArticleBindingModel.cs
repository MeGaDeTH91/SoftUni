namespace MyBlog.CommonModels.BindingModels.Articles
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class EditArticleBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [DataType(DataType.ImageUrl, ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [Display(Name = CommonConstants.PhotoUrlDisplay)]
        public string PhotoURL { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        [DataType(DataType.Url, ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        [Display(Name = CommonConstants.VideoUrlDisplay)]
        public string HighLightVideoURL { get; set; }

        [Required]
        [MinLength(ValidationConstants.ReviewConstraints.ContentMinLength)]
        public string Content { get; set; }
    }
}
