namespace MyBlog.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Models.Music.Artists;

    public class UserArtists
    {
        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

        [Required]
        public DateTime AddedToFavouritesOn { get; set; }
    }
}
