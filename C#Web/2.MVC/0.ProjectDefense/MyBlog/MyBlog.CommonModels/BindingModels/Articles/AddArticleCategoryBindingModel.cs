namespace MyBlog.CommonModels.BindingModels.Articles
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class AddArticleCategoryBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.ArticleCategoryConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.ArticleCategoryConstraints.NameMaxLength)]
        [Display(Name = CommonConstants.CategoryNameDisplay)]
        public string CategoryName { get; set; }
    }
}
