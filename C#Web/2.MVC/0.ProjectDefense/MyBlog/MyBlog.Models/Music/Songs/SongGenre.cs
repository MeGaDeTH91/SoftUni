namespace MyBlog.Models.Music.Songs
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class SongGenre
    {
        public SongGenre()
        {
            this.Songs = new List<Song>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.SongGenreConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.SongGenreConstraints.NameMaxLength)]
        public string GenreName { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
