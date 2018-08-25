namespace MyBlog.CommonModels.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class AddArtistTypeBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.ArtistTypeConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.ArtistTypeConstraints.NameMaxLength)]
        public string ArtistTypeName { get; set; }
    }
}
