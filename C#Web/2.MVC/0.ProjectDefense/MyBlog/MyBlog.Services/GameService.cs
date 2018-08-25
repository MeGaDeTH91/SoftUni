namespace MyBlog.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using MyBlog.Common;
    using MyBlog.Common.Helpers;
    using MyBlog.CommonModels.BindingModels.Games;
    using MyBlog.CommonModels.ViewModels.Brands;
    using MyBlog.CommonModels.ViewModels.Games;
    using MyBlog.Data;
    using MyBlog.Models.Games;
    using MyBlog.Models.Users;
    using MyBlog.Services.Interfaces;

    public class GameService : BaseBlogService, IGameService
    {
        public GameService(BlogDataDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public bool AddToFavourites(string userId, int gameId)
        {
            var user = this.DbContext
                .Users
                .FirstOrDefault(x => x.Id == userId);

            var game = this.DbContext
                .Games
                .FirstOrDefault(x => x.Id == gameId);

            if (user == null || game == null)
            {
                return false;
            }

            var userGame = new UserGames()
            {
                UserId = userId,
                GameId = gameId,
                AddedToFavouritesOn = DateTime.UtcNow
            };

            bool alreadyInFavourites = this.DbContext.FavouriteUserGames
                .Any(x => x.UserId == userId && x.GameId == gameId);

            if (alreadyInFavourites)
            {
                return false;
            }

            user.FavouriteGames.Add(userGame);
            this.DbContext.SaveChanges();

            return true;
        }

        public async Task<int> AddGameAsync(AddGameBindingModel model)
        {
            var checkForDuplicate = this.DbContext
                .Games
                .FirstOrDefault(x => x.GameName == model.GameName);

            if (checkForDuplicate != null)
            {
                return ErrorId;
            }

            var game = this.Mapper.Map<Game>(model);

            var gameType = this.DbContext
                .GameTypes
                .FirstOrDefault(x => x.Id == model.GameTypeId);

            var brand = this.DbContext
                .Brands
                .FirstOrDefault(x => x.Id == model.BrandId);

            game.GameTypeId = gameType.Id;
            game.GameType = gameType;

            game.BrandId = brand.Id;
            game.Brand = brand;

            if (game.HighLightVideoURL.Contains(CommonConstants.OriginalVideoUrlPart))
            {
                game.HighLightVideoURL = ModifyVideoURL_Embeded.ModifyEmbed(game.HighLightVideoURL);
            }

            await this.DbContext.Games.AddAsync(game);
            await this.DbContext.SaveChangesAsync();

            return game.Id;
        }

        public async Task<int> AddGameTypeAsync(AddGameTypeBindingModel model)
        {
            var existingType = this.DbContext
                .GameTypes
                .FirstOrDefault(x => x.GameTypeName == model.GameTypeName);

            if (existingType != null)
            {
                return ErrorId;
            }

            var type = this.Mapper.Map<GameType>(model);

            await this.DbContext.GameTypes.AddAsync(type);
            await this.DbContext.SaveChangesAsync();

            return type.Id;
        }

        public async Task<bool> DeleteGameAsync(int id)
        {
            var game = this.DbContext
                .Games
                .FirstOrDefault(x => x.Id == id);

            if (game == null)
            {
                return false;
            }

            this.DbContext.Games.Remove(game);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<int> EditGameAsync(EditGameBindingModel model)
        {
            var game = this.DbContext
                .Games
                .FirstOrDefault(x => x.Id == model.Id);

            if (game == null)
            {
                return ErrorId;
            }

            game.Description = model.Description;
            game.PhotoURL = model.PhotoURL;
            game.HighLightVideoURL = model.HighLightVideoURL;
            game.AdditionalInfoURL = model.AdditionalInfoURL;

            if (game.HighLightVideoURL.Contains(CommonConstants.OriginalVideoUrlPart))
            {
                game.HighLightVideoURL = ModifyVideoURL_Embeded.ModifyEmbed(game.HighLightVideoURL);
            }

            await this.DbContext.SaveChangesAsync();

            return game.Id;
        }

        public ICollection<GameConciseViewModel> GetAllGames()
        {
            var games = this.DbContext
                .Games
                .Select(this.Mapper.Map<GameConciseViewModel>)
                .ToList();

            return games;
        }

        public AddGameBindingModel GetAllBrandsAndGameTypes()
        {
            var brands = this.DbContext
                .Brands
                .Select(this.Mapper.Map<BrandConciseViewModel>)
                .ToList();

            var gameTypes = this.DbContext
                .GameTypes
                .Select(this.Mapper.Map<GameTypeViewModel>)
                .ToList();

            var brandsQuery = brands.Select(b => new SelectListItem() { Text = b.BrandName, Value = b.Id.ToString() });
            var gameTypesQuery = gameTypes.Select(b => new SelectListItem() { Text = b.GameTypeName, Value = b.Id.ToString() });

            var model = new AddGameBindingModel()
            {
                AllBrands = brandsQuery.ToList(),
                AllGameTypes = gameTypesQuery.ToList()
            };

            return model;
        }

        public GameDetailsViewModel GetGame(int id)
        {
            var actualGame = this.DbContext
                .Games
                .Include(x => x.GameType)
                .Include(x => x.Brand)
                .Include(x => x.AddedToFavoritesBy)
                .FirstOrDefault(x => x.Id == id);

            if (actualGame == null)
            {
                return null;
            }

            var game = this.Mapper.Map<GameDetailsViewModel>(actualGame);

            return game;
        }

        public GameTypeViewModel GetGameType(int id)
        {
            var gameType = this.DbContext
                .GameTypes
                .Include(x => x.Games)
                .FirstOrDefault(x => x.Id == id);

            if (gameType == null)
            {
                return null;
            }

            var gameTypeModel = new GameTypeViewModel()
            {
                GameTypeName = gameType.GameTypeName,
                Games = this.Mapper.Map<ICollection<GameConciseViewModel>>(gameType.Games)
            };

            return gameTypeModel;
        }
    }
}
