namespace HTTPServer.GameStoreApplication.Services.Contracts
{
    using GameStore.Models.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IGameService
    {
        void Create(string title,
                    string description,
                    string image,
                    decimal price,
                    double size,
                    string videoId,
                    DateTime releaseDate);

        IEnumerable<ListGamesViewModel> All();

        AdminGameViewModel Find(int id);

        bool Delete(int id);

        bool Update(int id,
                    string title,
                    string description,
                    string image,
                    decimal price,
                    double size,
                    string videoId,
                    DateTime releaseDate);

        IList<HomeUserGameListModel> AllGames();
    }
}
