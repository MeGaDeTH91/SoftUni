namespace MyBlog.Models.Music.Songs
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;
    using MyBlog.Models.Users;
    using MyBlog.Models.Music.Artists;

    public class Song
    {
        public Song()
        {
            this.AddedToFavoritesBy = new List<UserSongs>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.SongConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.SongConstraints.NameMaxLength)]
        public string SongName { get; set; }

        [Required]
        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [DataType(DataType.ImageUrl, ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        public string PhotoURL { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        [DataType(DataType.Url, ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        public string HighLightVideoURL { get; set; }

        [Required]
        [DataType(DataType.Url, ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        public string AdditionalInfoURL { get; set; }

        [Required]
        [MinLength(ValidationConstants.SongConstraints.DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public int SongGenreId { get; set; }

        public SongGenre SongGenre { get; set; }
        
        public ICollection<UserSongs> AddedToFavoritesBy { get; set; }
    }
}
