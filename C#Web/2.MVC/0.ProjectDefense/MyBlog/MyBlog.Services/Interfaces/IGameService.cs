namespace MyBlog.Services.Interfaces
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using MyBlog.CommonModels.ViewModels.Games;
    using MyBlog.CommonModels.BindingModels.Games;

    public interface IGameService
    {
        bool AddToFavourites(string userId, int gameId);

        ICollection<GameConciseViewModel> GetAllGames();

        AddGameBindingModel GetAllBrandsAndGameTypes();

        GameDetailsViewModel GetGame(int id);

        GameTypeViewModel GetGameType(int id);

        Task<int> AddGameAsync(AddGameBindingModel model);

        Task<int> EditGameAsync(EditGameBindingModel model);

        Task<bool> DeleteGameAsync(int id);

        Task<int> AddGameTypeAsync(AddGameTypeBindingModel model);
    }
}
