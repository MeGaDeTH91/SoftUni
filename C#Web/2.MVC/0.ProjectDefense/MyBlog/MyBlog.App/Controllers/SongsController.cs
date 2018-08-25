namespace MyBlog.App.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.BindingModels.Music.Songs;
    using MyBlog.CommonModels.ViewModels.Music.Songs;
    using MyBlog.Models.Users;
    using MyBlog.Services.Interfaces;

    public class SongsController : BaseUserController
    {
        private readonly ISongService songService;

        public SongsController(UserManager<User> userManager, ISongService songService) : base(userManager)
        {
            this.songService = songService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var songs = this.songService.GetAllSongs();

            return this.View(songs);
        }
        
        [HttpGet]
        public IActionResult SongGenreDetails(int id)
        {
            var songGenre = this.songService.GetSongGenre(id);

            if (songGenre == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.SongsSuffix);
            }

            return this.View(songGenre);
        }

        [HttpGet]
        public IActionResult AddToFavourites(int id)
        {
            var loggerUser = this.User;
            var dbUser = this.userManager.GetUserAsync(loggerUser);

            var addedToFavourites = this.songService.AddToFavourites(dbUser.Result.Id, id);

            if (addedToFavourites == false)
            {
                SetErrorMessage(CommonConstants.AlreadyInFavouritesOrInvalidErrorMessage);

                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.SongsSuffix);
            }

            SetSuccessMessage(CommonConstants.AddedToFavouritesSuccessfullyMessage);

            return Redirect(string.Format(RedirectConstants.SongDetailsPage, id));
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