namespace MyBlog.CommonModels.ViewModels.Music.Artists
{
    using System.Collections.Generic;
    using MyBlog.CommonModels.ViewModels.Music.Songs;
    using MyBlog.Models.Users;

    public class ArtistDetailsViewModel
    {
        public string FullName { get; set; }
        
        public string PhotoURL { get; set; }
        
        public string HighLightVideoURL { get; set; }
        
        public string AdditionalInfoURL { get; set; }
        
        public string Description { get; set; }
        
        public int ArtistTypeId { get; set; }

        public ArtistTypeViewModel ArtistType { get; set; }
        
        public ICollection<UserArtists> AddedToFavoritesBy { get; set; }

        public ICollection<SongConciseViewModel> Songs { get; set; }
    }
}
