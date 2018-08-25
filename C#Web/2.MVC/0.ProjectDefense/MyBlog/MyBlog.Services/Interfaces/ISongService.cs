namespace MyBlog.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MyBlog.CommonModels.BindingModels.Music.Songs;
    using MyBlog.CommonModels.ViewModels.Music.Songs;

    public interface ISongService
    {
        bool AddToFavourites(string userId, int songId);

        ICollection<SongConciseViewModel> GetAllSongs();

        AddSongBindingModel GetAllArtistsAndSongGenres();

        SongDetailsViewModel GetSong(int id);

        SongGenreViewModel GetSongGenre(int id);

        Task<int> AddSongAsync(AddSongBindingModel model);

        Task<int> EditSongAsync(EditSongBindingModel model);

        Task<bool> DeleteSongAsync(int id);

        Task<int> AddSongGenreAsync(AddSongGenreBindingModel model);
    }
}
