namespace MyBlog.CommonModels.BindingModels.Music.Artists
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class AddArtistTypeBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.ArtistTypeConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.ArtistTypeConstraints.NameMaxLength)]
        [Display(Name = CommonConstants.ArtistTypeDisplay)]
        public string ArtistTypeName { get; set; }
    }
}
