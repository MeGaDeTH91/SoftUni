namespace MyBlog.CommonModels.BindingModels.Music.Songs
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using MyBlog.Common;

    public class AddSongBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.SongConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.SongConstraints.NameMaxLength)]
        [Display(Name = CommonConstants.SongNameDisplay)]
        public string SongName { get; set; }

        [Required]
        public int ArtistId { get; set; }
        public IEnumerable<SelectListItem> AllArtists { get; set; }

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

        [Required]
        public int SongGenreId { get; set; }
        public IEnumerable<SelectListItem> AllSongGenres { get; set; }
    }
}
