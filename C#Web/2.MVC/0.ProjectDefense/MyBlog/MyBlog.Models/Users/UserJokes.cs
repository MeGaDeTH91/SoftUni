namespace MyBlog.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Models.Fun;

    public class UserJokes
    {
        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int JokeId { get; set; }

        public Joke Joke { get; set; }

        [Required]
        public DateTime AddedToFavouritesOn { get; set; }
    }
}
