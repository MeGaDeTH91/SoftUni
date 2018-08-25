namespace MyBlog.CommonModels.BindingModels.Games
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class AddGameTypeBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.GameTypeConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.GameTypeConstraints.NameMaxLength)]
        [Display(Name = CommonConstants.GameTypeDisplay)]
        public string GameTypeName { get; set; }
    }
}
