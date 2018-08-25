namespace MyBlog.App.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.BindingModels.Music.Songs;
    using MyBlog.CommonModels.ViewModels.Music.Songs;
    using MyBlog.Services.Interfaces;

    public class SongsController : AdminController
    {
        private readonly ISongService songService;

        public SongsController(ISongService songService)
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
        public IActionResult AddSong()
        {
            var model = this.songService.GetAllArtistsAndSongGenres();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddSong(AddSongBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.AddSong();
            }

            int generatedId = await this.songService.AddSongAsync(model);

            if (generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.AddSong();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.SongSuffix));

            return Redirect(string.Format(RedirectConstants.AdministratorAreaSongDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult EditSong(int id)
        {
            SongDetailsViewModel song = this.songService.GetSong(id);

            if (song == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(song);
        }

        [HttpPost]
        public async Task<IActionResult> EditSong(EditSongBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.EditSong(model.Id);
            }

            int generatedId = await this.songService.EditSongAsync(model);

            if (generatedId < 1)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return Redirect(string.Format(RedirectConstants.AdministratorAreaSongDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult DeleteSong(int id)
        {
            SongDetailsViewModel song = this.songService.GetSong(id);

            if (song == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(song);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSong(EditSongBindingModel model)
        {
            bool isDeleted = await this.songService.DeleteSongAsync(model.Id);

            return RedirectToAction(RedirectConstants.IndexSuffix);
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
        public IActionResult AddSongGenre()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSongGenre(AddSongGenreBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.AddSongGenre();
            }

            int generatedId = await this.songService.AddSongGenreAsync(model);

            if (generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.AddSongGenre();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.SongGenreDisplay));

            return RedirectToAction(RedirectConstants.SongGenreDetailsSuffix, RedirectConstants.SongsSuffix, generatedId);
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