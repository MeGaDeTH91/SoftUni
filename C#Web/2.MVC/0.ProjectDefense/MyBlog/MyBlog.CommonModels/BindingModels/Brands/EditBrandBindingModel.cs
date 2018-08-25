namespace MyBlog.CommonModels.BindingModels.Brands
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class EditBrandBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.BrandConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.BrandConstraints.NameMaxLength)]
        public string BrandName { get; set; }

        [Required]
        [MinLength(ValidationConstants.BrandConstraints.DescriptionMinLength)]
        public string BrandDescription { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [DataType(DataType.ImageUrl, ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        public string BrandImageURL { get; set; }
        
        [Required]
        [DataType(DataType.Url, ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        public string AdditionalInfoURL { get; set; }
    }
}
