namespace MyBlog.App.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.BindingModels.Games;
    using MyBlog.CommonModels.ViewModels.Games;
    using MyBlog.Models.Users;
    using MyBlog.Services.Interfaces;

    public class GamesController : BaseUserController
    {
        private readonly IGameService gameService;

        public GamesController(UserManager<User> userManager, IGameService gameService) : base(userManager)
        {
            this.gameService = gameService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var games = this.gameService.GetAllGames();

            return this.View(games);
        }

        [HttpGet]
        public IActionResult AddToFavourites(int id)
        {
            var loggerUser = this.User;
            var dbUser = this.userManager.GetUserAsync(loggerUser);

            var addedToFavourites = this.gameService.AddToFavourites(dbUser.Result.Id, id);

            if (addedToFavourites == false)
            {
                SetErrorMessage(CommonConstants.AlreadyInFavouritesOrInvalidErrorMessage);

                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.GamesSuffix);
            }

            SetSuccessMessage(CommonConstants.AddedToFavouritesSuccessfullyMessage);

            return Redirect(string.Format(RedirectConstants.GameDetailsPage, id));
        }


        [HttpGet]
        public IActionResult GameTypeDetails(int id)
        {
            var gameType = this.gameService.GetGameType(id);

            if (gameType == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.GamesSuffix);
            }

            return this.View(gameType);
        }

        private void SetSuccessMessage(string successMessage)
        {
            this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
            {
                Type = MessageType.Success,
                Message = successMessage
            });
        }

        private void SetErrorMessage(string errorMessage)
        {
            this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
            {
                Type = MessageType.Danger,
                Message = errorMessage
            });
        }
    }
}