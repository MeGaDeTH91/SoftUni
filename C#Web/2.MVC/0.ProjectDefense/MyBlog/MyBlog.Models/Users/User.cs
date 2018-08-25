namespace MyBlog.Models.Users
{
    using Microsoft.AspNetCore.Identity;
    using MyBlog.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        public User()
        {
            this.FavouriteArticles = new List<UserArticles>();

            this.FavouriteArtists = new List<UserArtists>();

            this.FavouriteBooks = new List<UserBooks>();
            
            this.FavouriteBrands = new List<UserBrands>();

            this.FavouriteJokes = new List<UserJokes>();

            this.FavouriteMemes = new List<UserMemes>();

            this.FavouriteGames = new List<UserGames>();
            
            this.FavouriteInstruments = new List<UserInstruments>();

            this.FavouriteSongs = new List<UserSongs>();

            this.BoughtProducts = new List<UserProducts>();

            this.FavouriteReviews = new List<UserReviews>();

            this.IsBanned = false;
        }

        [Required]
        [MinLength(ValidationConstants.UserConstraints.FullNameMinLength)]
        [MaxLength(ValidationConstants.UserConstraints.FullNameMaxLength)]
        public string FullName { get; set; }

        public bool IsBanned { get; set; }

        public ICollection<UserArticles> FavouriteArticles { get; set; }

        public ICollection<UserBooks> FavouriteBooks { get; set; }

        public ICollection<UserBrands> FavouriteBrands { get; set; }

        public ICollection<UserJokes> FavouriteJokes { get; set; }

        public ICollection<UserMemes> FavouriteMemes { get; set; }

        public ICollection<UserGames> FavouriteGames { get; set; }

        public ICollection<UserArtists> FavouriteArtists { get; set; }

        public ICollection<UserInstruments> FavouriteInstruments { get; set; }

        public ICollection<UserSongs> FavouriteSongs { get; set; }
        
        public ICollection<UserProducts> BoughtProducts { get; set; }

        public ICollection<UserReviews> FavouriteReviews { get; set; }
    }
}
