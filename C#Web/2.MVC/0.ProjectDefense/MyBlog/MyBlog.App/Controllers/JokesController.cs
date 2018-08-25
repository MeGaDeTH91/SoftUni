namespace MyBlog.App.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.Models.Users;
    using MyBlog.Services.Interfaces;

    public class JokesController : BaseUserController
    {
        private readonly IJokeService jokeService;

        public JokesController(UserManager<User> userManager, IJokeService jokeService) : base(userManager)
        {
            this.jokeService = jokeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var jokes = this.jokeService.GetAllJokes();

            return this.View(jokes);
        }

        [HttpGet]
        public IActionResult AddToFavourites(int id)
        {
            var loggerUser = this.User;
            var dbUser = this.userManager.GetUserAsync(loggerUser);

            var addedToFavourites = this.jokeService.AddToFavourites(dbUser.Result.Id, id);

            if (addedToFavourites == false)
            {
                SetErrorMessage(CommonConstants.AlreadyInFavouritesOrInvalidErrorMessage);

                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.JokesSuffix);
            }

            SetSuccessMessage(CommonConstants.AddedToFavouritesSuccessfullyMessage);

            return Redirect(string.Format(RedirectConstants.JokeDetailsPage, id));
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