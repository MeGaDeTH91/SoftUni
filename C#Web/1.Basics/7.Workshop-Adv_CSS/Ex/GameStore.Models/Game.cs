namespace GameStore.Models
{
    using GameStore.GameStoreApplication.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        public Game()
        {
            this.Users = new HashSet<UserGame>();
            this.ShoppingCartUsers = new HashSet<ShoppingCart>();
            this.ImageURL = "https://media.contentapi.ea.com/content/dam/masseffect/en-us/migrated-images/2016/07/en-us-featured-image.jpg";
        }

        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.GameConstraints.TitleMinLength)]
        [MaxLength(ValidationConstants.GameConstraints.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ValidationConstants.GameConstraints.VideoLength)]
        [MaxLength(ValidationConstants.GameConstraints.VideoLength)]
        public string Trailer { get; set; }

        public double Size { get; set; }

        public decimal Price { get; set; }

        [StringLength(ValidationConstants.GameConstraints.StringMaxLength)]
        public string ImageURL { get; set; }

        [Required]
        [MinLength(ValidationConstants.GameConstraints.DescriptionMinLength)]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ICollection<UserGame> Users { get; set; }

        public ICollection<ShoppingCart> ShoppingCartUsers { get; set; }
    }
}
