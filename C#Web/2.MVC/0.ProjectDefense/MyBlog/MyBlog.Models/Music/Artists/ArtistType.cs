namespace MyBlog.Models.Music.Artists
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class ArtistType
    {
        public ArtistType()
        {
            this.Artists = new List<Artist>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.ArtistTypeConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.ArtistTypeConstraints.NameMaxLength)]
        public string ArtistTypeName { get; set; }

        public ICollection<Artist> Artists { get; set; }
    }
}
