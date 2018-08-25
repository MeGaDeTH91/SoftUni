namespace MyBlog.CommonModels.BindingModels.Products
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class AddProductTypeBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.ProductTypeConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.ProductTypeConstraints.NameMaxLength)]
        [Display(Name = CommonConstants.TypeNameDisplay)]
        public string TypeName { get; set; }

    }
}
