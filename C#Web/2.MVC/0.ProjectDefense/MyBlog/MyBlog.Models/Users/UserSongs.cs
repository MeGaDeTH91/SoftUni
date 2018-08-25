namespace MyBlog.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Models.Music.Songs;

    public class UserSongs
    {
        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int SongId { get; set; }

        public Song Song { get; set; }

        [Required]
        public DateTime AddedToFavouritesOn { get; set; }
    }
}
