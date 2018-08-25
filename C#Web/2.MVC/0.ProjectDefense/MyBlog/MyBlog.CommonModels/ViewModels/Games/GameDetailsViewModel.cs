namespace MyBlog.CommonModels.ViewModels.Games
{
    using System.Collections.Generic;
    using MyBlog.CommonModels.ViewModels.Brands;
    using MyBlog.Models.Users;

    public class GameDetailsViewModel
    {        
        public string GameName { get; set; }
        
        public int BrandId { get; set; }

        public BrandConciseViewModel Brand { get; set; }
        
        public string PhotoURL { get; set; }
        
        public string HighLightVideoURL { get; set; }
        
        public string AdditionalInfoURL { get; set; }
        
        public string Description { get; set; }
        
        public int GameTypeId { get; set; }

        public GameTypeViewModel GameType { get; set; }

        public ICollection<UserGames> AddedToFavoritesBy { get; set; }
    }
}
