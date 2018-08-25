namespace MyBlog.App.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.BindingModels.Games;
    using MyBlog.CommonModels.ViewModels.Games;
    using MyBlog.Services.Interfaces;

    public class GamesController : AdminController
    {
        private readonly IGameService gameService;

        public GamesController(IGameService gameService)
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
        public IActionResult AddGame()
        {
            var model = this.gameService.GetAllBrandsAndGameTypes();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(AddGameBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.AddGame();
            }

            int generatedId = await this.gameService.AddGameAsync(model);

            if (generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.AddGame();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.GameSuffix));

            return Redirect(string.Format(RedirectConstants.AdministratorAreaGameDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult EditGame(int id)
        {
            GameDetailsViewModel game = this.gameService.GetGame(id);

            if (game == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(game);
        }

        [HttpPost]
        public async Task<IActionResult> EditGame(EditGameBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.EditGame(model.Id);
            }

            int generatedId = await this.gameService.EditGameAsync(model);

            if (generatedId < 1)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return Redirect(string.Format(RedirectConstants.AdministratorAreaGameDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult DeleteGame(int id)
        {
            GameDetailsViewModel game = this.gameService.GetGame(id);

            if (game == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(game);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGame(EditGameBindingModel model)
        {
            bool isDeleted = await this.gameService.DeleteGameAsync(model.Id);

            return RedirectToAction(RedirectConstants.IndexSuffix);
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

        [HttpGet]
        public IActionResult AddGameType()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGameType(AddGameTypeBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.AddGameType();
            }

            int generatedId = await this.gameService.AddGameTypeAsync(model);

            if (generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.AddGameType();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.GameTypeDisplay));

            return RedirectToAction(RedirectConstants.GameTypeDetailsSuffix, RedirectConstants.GamesSuffix, generatedId);
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