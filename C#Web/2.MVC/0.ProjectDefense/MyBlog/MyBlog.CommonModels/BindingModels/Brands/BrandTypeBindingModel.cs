namespace MyBlog.CommonModels.BindingModels.Brands
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class BrandTypeBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.BrandTypeConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.BrandTypeConstraints.NameMaxLength)]
        [Display(Name = CommonConstants.TypeNameDisplay)]
        public string TypeName { get; set; }
    }
}
