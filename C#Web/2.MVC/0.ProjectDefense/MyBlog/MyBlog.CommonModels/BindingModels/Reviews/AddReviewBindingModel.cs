namespace MyBlog.CommonModels.BindingModels.Reviews
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using MyBlog.Common;

    public class AddReviewBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.ReviewConstraints.TitleMinLength)]
        [MaxLength(ValidationConstants.ReviewConstraints.TitleMaxLength)]
        public string Title { get; set; }

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
        [MinLength(ValidationConstants.ReviewConstraints.ContentMinLength)]
        public string Content { get; set; }

        [Required]
        public int ReviewTypeId { get; set; }
        public IEnumerable<SelectListItem> AllReviewTypes { get; set; }
    }
}
