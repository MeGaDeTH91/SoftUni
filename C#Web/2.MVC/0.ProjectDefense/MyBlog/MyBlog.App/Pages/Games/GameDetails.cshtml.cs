namespace MyBlog.App.Pages.Games
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.ViewModels.Games;
    using MyBlog.Services.Interfaces;

    public class GameDetailsModel : BaseUserPageModel
    {
        public GameDetailsViewModel GameDetailsViewModel { get; private set; }
        private readonly IGameService gameService;

        public int GameId { get; set; }
        public int Likes { get; private set; }

        public GameDetailsModel(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public IActionResult OnGet(int id)
        {
            var game = this.gameService.GetGame(id);

            if (game == null)
            {
                this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
                {
                    Type = MessageType.Danger,
                    Message = CommonConstants.NotFoundMessage
                });
            }

            this.GameId = id;

            this.GameDetailsViewModel = game;
            this.Likes = this.GameDetailsViewModel.AddedToFavoritesBy.Count;

            return this.Page();
        }
    }
}