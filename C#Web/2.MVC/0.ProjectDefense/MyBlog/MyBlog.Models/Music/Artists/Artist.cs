namespace MyBlog.Models.Music.Artists
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;
    using MyBlog.Models.Users;
    using MyBlog.Models.Music.Songs;

    public class Artist
    {
        public Artist()
        {
            this.Songs = new List<Song>();

            this.AddedToFavoritesBy = new List<UserArtists>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.ArtistConstraints.FullNameMinLength)]
        [MaxLength(ValidationConstants.ArtistConstraints.FullNameMaxLength)]
        public string FullName { get; set; }

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
        [MinLength(ValidationConstants.ArtistConstraints.DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public int ArtistTypeId { get; set; }

        public ArtistType ArtistType { get; set; }

        public ICollection<Song> Songs { get; set; }
        
        public ICollection<UserArtists> AddedToFavoritesBy { get; set; }
    }
}
