namespace MyBlog.CommonModels.ViewModels.Music.Songs
{
    using System.Collections.Generic;
    using MyBlog.CommonModels.ViewModels.Music.Artists;
    using MyBlog.Models.Users;

    public class SongDetailsViewModel
    {
        public string SongName { get; set; }
        
        public int ArtistId { get; set; }
        public ArtistConciseViewModel Artist { get; set; }
        
        public string PhotoURL { get; set; }
        
        public string HighLightVideoURL { get; set; }
        
        public string AdditionalInfoURL { get; set; }
        
        public string Description { get; set; }
        
        public int SongGenreId { get; set; }
        public SongGenreViewModel SongGenre { get; set; }

        public ICollection<UserSongs> AddedToFavoritesBy { get; set; }
    }
}
