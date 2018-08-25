namespace MyBlog.CommonModels.BindingModels.Music.Instruments
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class AddInstrumentBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.InstrumentConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.InstrumentConstraints.NameMaxLength)]
        [Display(Name = CommonConstants.InstrumentModelNameDisplay)]
        public string ModelName { get; set; }
        
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

        [Required]
        public int InstrumentTypeId { get; set; }
        public IEnumerable<SelectListItem> AllInstrumentTypes { get; set; }
    }
}
