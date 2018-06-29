namespace SimpleMvc.Models
{
    using SimpleMvc.Common;
    using System.ComponentModel.DataAnnotations;

    public class Tube
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.TubeConstraints.TitleMinLength)]
        [MaxLength(ValidationConstants.TubeConstraints.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ValidationConstants.TubeConstraints.AuthorNameMinLength)]
        [MaxLength(ValidationConstants.TubeConstraints.AuthorNameMaxLength)]
        public string Author { get; set; }

        public string Description { get; set; }

        [Required]
        [MinLength(ValidationConstants.TubeConstraints.YouTubeIdLength)]
        [MaxLength(ValidationConstants.TubeConstraints.YouTubeIdLength)]
        public string YouTubeId { get; set; }

        public int Views { get; set; }

        [Required]
        public int UploaderId { get; set; }

        public User Uploader { get; set; }
    }
}
