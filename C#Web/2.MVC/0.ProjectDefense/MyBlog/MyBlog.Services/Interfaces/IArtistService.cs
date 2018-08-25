namespace MyBlog.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MyBlog.CommonModels.BindingModels.Music.Artists;
    using MyBlog.CommonModels.ViewModels.Music.Artists;

    public interface IArtistService
    {
        bool AddToFavourites(string userId, int artistId);

        ICollection<ArtistConciseViewModel> GetAllArtists();

        AddArtistBindingModel GetAllArtistTypes();

        ArtistDetailsViewModel GetArtist(int id);

        ArtistTypeViewModel GetArtistType(int id);

        Task<int> AddArtistAsync(AddArtistBindingModel model);

        Task<int> EditArtistAsync(EditArtistBindingModel model);

        Task<bool> DeleteArtistAsync(int id);

        Task<int> AddArtistTypeAsync(AddArtistTypeBindingModel model);
    }
}
