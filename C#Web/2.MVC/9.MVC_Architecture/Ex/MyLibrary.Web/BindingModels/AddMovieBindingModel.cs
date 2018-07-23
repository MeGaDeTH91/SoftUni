namespace MyLibrary.Web.BindingModels
{
    using MyLibrary.Common;
    using System.ComponentModel.DataAnnotations;

    public class AddMovieBindingModel
    {        
        [Required]
        [MinLength(ValidationConstants.MovieConstants.TitleMinLength)]
        [MaxLength(ValidationConstants.MovieConstants.TitleMaxLength)]
        public string Title { get; set; }

        public string Description { get; set; }
        
        [Required]
        public string Director { get; set; }

        public string PosterImage { get; set; }
    }
}
