namespace MyBlog.CommonModels.BindingModels.Articles
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class AddArticleBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.ReviewConstraints.TitleMinLength)]
        [MaxLength(ValidationConstants.ReviewConstraints.TitleMaxLength)]
        public string Title { get; set; }

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

        [Required]
        [MinLength(ValidationConstants.ArticleCategoryConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.ArticleCategoryConstraints.NameMaxLength)]
        [Display(Name = CommonConstants.CategoryNameDisplay)]
        public string ArticleCategoryName { get; set; }
    }
}
