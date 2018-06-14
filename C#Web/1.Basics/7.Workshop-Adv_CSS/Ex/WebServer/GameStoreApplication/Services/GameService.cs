namespace HTTPServer.GameStoreApplication.Services
{
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameStore.Models.ViewModels;
    using GameStore.Data;
    using GameStore.Models;

    public class GameService : IGameService
    {
        public IEnumerable<ListGamesViewModel> All()
        {
            using (var db = new GameStoreDbContext())
            {
                return db.Games
                    .Select(x => new ListGamesViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Description = x.Description,
                        Price = x.Price,
                        Size = x.Size,
                        VideoId = x.Trailer
                    })
                    .ToList();
            }
        }

        public IList<HomeUserGameListModel> AllGames()
        {
            throw new NotImplementedException();
        }

        public void Create(string title, string description, string image, decimal price, double size, string videoId, DateTime releaseDate)
        {
            Game gameToAdd = new Game() {
                Title = title,
                Description = description,
                ImageURL = image,
                Price = price,
                Size = size,
                Trailer = videoId,
                ReleaseDate = releaseDate
            };

            using(var db = new GameStoreDbContext())
            {
                db.Games.Add(gameToAdd);
                db.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            Game gameToDelete = default(Game);

            using (var db = new GameStoreDbContext())
            {
                gameToDelete = db.Games.FirstOrDefault(x => x.Id == id);

                if(gameToDelete == default(Game))
                {
                    return false;
                }

                db.Games.Remove(gameToDelete);
                db.SaveChanges();
            }

            return true;
        }

        public AdminGameViewModel Find(int id)
        {
            Game gameToDelete = default(Game);
            
            using(var db = new GameStoreDbContext())
            {
                gameToDelete = db.Games.FirstOrDefault(x => x.Id == id);
            }

            return new AdminGameViewModel
            {
                Id = gameToDelete.Id,
                Title = gameToDelete.Title,
                Description = gameToDelete.Description,
                ImageUrl = gameToDelete.ImageURL,
                Price = gameToDelete.Price,
                Size = gameToDelete.Size,
                Trailer = gameToDelete.Trailer,
                ReleaseDate = gameToDelete.ReleaseDate
            };
        }

        public bool Update(int id, string title, string description, string image, decimal price, double size, string videoId, DateTime releaseDate)
        {
            Game gameToEdit = default(Game);

            using (var db = new GameStoreDbContext())
            {
                gameToEdit = db.Games.FirstOrDefault(x => x.Id == id);

                if(gameToEdit == default(Game))
                {
                    return false;
                }

                gameToEdit.Id = id;
                gameToEdit.Title = title;
                gameToEdit.Description = description;
                gameToEdit.ImageURL = image;
                gameToEdit.Price = price;
                gameToEdit.Size = size;
                gameToEdit.Trailer = videoId;
                gameToEdit.ReleaseDate = releaseDate;

                db.SaveChanges();
            }
            return true;
        }
    }
}
