namespace MyBlog.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Models.Fun;

    public class UserMemes
    {
        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int MemeId { get; set; }

        public Meme Meme { get; set; }

        [Required]
        public DateTime AddedToFavouritesOn { get; set; }
    }
}
