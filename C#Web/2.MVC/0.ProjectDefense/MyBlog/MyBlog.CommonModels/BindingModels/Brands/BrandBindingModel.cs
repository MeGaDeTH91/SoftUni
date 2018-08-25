namespace MyBlog.CommonModels.BindingModels.Brands
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class BrandBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.BrandConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.BrandConstraints.NameMaxLength)]
        [Display(Name = CommonConstants.BrandNameDisplay)]
        public string BrandName { get; set; }

        [Required]
        [MinLength(ValidationConstants.BrandConstraints.DescriptionMinLength)]
        [Display(Name = CommonConstants.BrandDescriptionDisplay)]
        public string BrandDescription { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [DataType(DataType.ImageUrl, ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [Display(Name = CommonConstants.PhotoUrlDisplay)]
        public string BrandImageURL { get; set; }

        [DataType(DataType.Url, ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        [Display(Name = CommonConstants.AdditionalInfoDisplay)]
        public string AdditionalInfoURL { get; set; }

        [Required]
        [MinLength(ValidationConstants.BrandTypeConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.BrandTypeConstraints.NameMaxLength)]
        [Display(Name = CommonConstants.BrandTypeDisplay)]
        public string BrandTypeStr { get; set; }
    }
}
