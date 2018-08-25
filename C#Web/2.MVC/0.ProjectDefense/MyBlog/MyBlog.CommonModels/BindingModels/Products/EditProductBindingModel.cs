namespace MyBlog.CommonModels.BindingModels.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using MyBlog.Common;

    public class EditProductBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = CommonConstants.ProductPriceColumnFormat)]
        public decimal Price { get; set; }

        [Required]
        public int BrandId { get; set; }
        public IEnumerable<SelectListItem> AllBrands { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [DataType(DataType.ImageUrl, ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [Display(Name = CommonConstants.PhotoUrlDisplay)]
        public string PhotoURL { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        [DataType(DataType.Url, ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        [Display(Name = CommonConstants.VideoUrlDisplay)]
        public string HighLightVideoURL { get; set; }

        [Required]
        [DataType(DataType.Url, ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        [Display(Name = CommonConstants.AdditionalInfoDisplay)]
        public string AdditionalInfoURL { get; set; }

        [Required]
        [MinLength(ValidationConstants.InstrumentConstraints.DescriptionMinLength)]
        public string Description { get; set; }
    }
}
