namespace MyBlog.CommonModels.BindingModels.Games
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;
    using MyBlog.Models.Users;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class AddGameBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.GameNameMessage)]
        [MinLength(ValidationConstants.GameConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.GameConstraints.NameMaxLength)]
        [Display(Name = CommonConstants.GameNameDisplay)]
        public string GameName { get; set; }

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
        public string Description { get; set; }

        [Required]
        public int GameTypeId { get; set; }

        public IEnumerable<SelectListItem> AllGameTypes { get; set; }
    }
}
