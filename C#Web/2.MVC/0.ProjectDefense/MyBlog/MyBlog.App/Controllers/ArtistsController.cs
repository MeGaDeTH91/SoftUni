namespace MyBlog.App.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.Models.Users;
    using MyBlog.Services.Interfaces;

    public class ArtistsController : BaseUserController
    {
        private readonly IArtistService artistService;

        public ArtistsController(UserManager<User> userManager, IArtistService artistService) : base(userManager)
        {
            this.artistService = artistService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var artists = this.artistService.GetAllArtists();

            return this.View(artists);
        }
        
        [HttpGet]
        public IActionResult ArtistTypeDetails(int id)
        {
            var artistType = this.artistService.GetArtistType(id);

            if (artistType == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.ArtistsSuffix);
            }

            return this.View(artistType);
        }

        [HttpGet]
        public IActionResult AddToFavourites(int id)
        {
            var loggerUser = this.User;
            var dbUser = this.userManager.GetUserAsync(loggerUser);

            var addedToFavourites = this.artistService.AddToFavourites(dbUser.Result.Id, id);

            if (addedToFavourites == false)
            {
                SetErrorMessage(CommonConstants.AlreadyInFavouritesOrInvalidErrorMessage);

                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.ArtistsSuffix);
            }

            SetSuccessMessage(CommonConstants.AddedToFavouritesSuccessfullyMessage);

            return Redirect(string.Format(RedirectConstants.ArtistDetailsPage, id));
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