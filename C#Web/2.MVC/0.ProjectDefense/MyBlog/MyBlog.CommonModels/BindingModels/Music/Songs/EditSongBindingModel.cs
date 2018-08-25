namespace MyBlog.CommonModels.BindingModels.Music.Songs
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class EditSongBindingModel
    {
        [Required]
        public int Id { get; set; }

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
        [MinLength(ValidationConstants.SongConstraints.DescriptionMinLength)]
        public string Description { get; set; }
    }
}
