namespace MyBlog.Models.Games
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;
    using MyBlog.Models.Users;
    using MyBlog.Models.Brands;

    public class Game
    {
        public Game()
        {
            this.AddedToFavoritesBy = new List<UserGames>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.GameConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.GameConstraints.NameMaxLength)]
        public string GameName { get; set; }

        [Required]
        public int BrandId { get; set; }

        public Brand Brand { get; set; }

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
        public string Description { get; set; }

        [Required]
        public int GameTypeId { get; set; }

        public GameType GameType { get; set; }
        
        public ICollection<UserGames> AddedToFavoritesBy { get; set; }
    }
}
