namespace MyBlog.CommonModels.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class ArtistBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.ArtistConstraints.FullNameMinLength)]
        [MaxLength(ValidationConstants.ArtistConstraints.FullNameMaxLength)]
        public string FullName { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [DataType(DataType.ImageUrl, ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        public string PhotoURL { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        [DataType(DataType.Url, ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        public string HighLightVideoURL { get; set; }

        [DataType(DataType.Url, ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        public string AdditionalInfoURL { get; set; }

        [Required]
        [MinLength(ValidationConstants.ArtistConstraints.DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public string Artist { get; set; }
    }
}
