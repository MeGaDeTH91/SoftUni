namespace MyBlog.CommonModels.BindingModels.Music.Songs
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class AddSongGenreBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.SongGenreConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.SongGenreConstraints.NameMaxLength)]
        [Display(Name = CommonConstants.SongGenreDisplay)]
        public string GenreName { get; set; }
    }
}
