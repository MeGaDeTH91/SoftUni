namespace MyBlog.App.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.BindingModels.Fun;
    using MyBlog.CommonModels.ViewModels.Fun;
    using MyBlog.Models.Users;
    using MyBlog.Services.Interfaces;

    public class MemesController : BaseUserController
    {
        private readonly IMemeService memeService;

        public MemesController(UserManager<User> userManager, IMemeService memeService) : base(userManager)
        {
            this.memeService = memeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var memes = this.memeService.GetAllMemes();

            return this.View(memes);
        }

        [HttpGet]
        public IActionResult AddToFavourites(int id)
        {
            var loggerUser = this.User;
            var dbUser = this.userManager.GetUserAsync(loggerUser);

            var addedToFavourites = this.memeService.AddToFavourites(dbUser.Result.Id, id);

            if (addedToFavourites == false)
            {
                SetErrorMessage(CommonConstants.AlreadyInFavouritesOrInvalidErrorMessage);

                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.MemesSuffix);
            }

            SetSuccessMessage(CommonConstants.AddedToFavouritesSuccessfullyMessage);

            return Redirect(string.Format(RedirectConstants.MemeDetailsPage, id));
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