namespace SimpleMvc.App.BindingModels
{
    using SimpleMvc.Common;
    using System.ComponentModel.DataAnnotations;

    public class UploadTubeBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.TubeConstraints.TitleMinLength)]
        [MaxLength(ValidationConstants.TubeConstraints.TitleMaxLength)]
        public string Title { get; set; }
        
        [Required]
        [MinLength(ValidationConstants.TubeConstraints.AuthorNameMinLength)]
        [MaxLength(ValidationConstants.TubeConstraints.AuthorNameMaxLength)]
        public string Author { get; set; }

        [Required]
        public string YoutubeLink { get; set; }

        public string Description { get; set; }
    }
}
