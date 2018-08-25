namespace MyBlog.CommonModels.BindingModels.Reviews
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class AddReviewTypeBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.ReviewTypeConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.ReviewTypeConstraints.NameMaxLength)]
        [Display(Name = CommonConstants.ReviewTypeDisplay)]
        public string ReviewTypeName { get; set; }
    }
}
