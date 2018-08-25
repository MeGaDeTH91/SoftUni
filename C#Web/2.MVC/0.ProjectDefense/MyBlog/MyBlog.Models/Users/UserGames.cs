namespace MyBlog.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Models.Games;

    public class UserGames
    {
        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int GameId { get; set; }

        public Game Game { get; set; }

        [Required]
        public DateTime AddedToFavouritesOn { get; set; }
    }
}
