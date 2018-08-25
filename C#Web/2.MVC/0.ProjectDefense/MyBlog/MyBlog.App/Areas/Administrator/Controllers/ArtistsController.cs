namespace MyBlog.App.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.BindingModels.Music.Artists;
    using MyBlog.CommonModels.ViewModels.Music.Artists;
    using MyBlog.Services.Interfaces;

    public class ArtistsController : AdminController
    {
        private readonly IArtistService artistService;

        public ArtistsController(IArtistService artistService)
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
        public IActionResult AddArtist()
        {
            var model = this.artistService.GetAllArtistTypes();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddArtist(AddArtistBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.AddArtist();
            }

            int generatedId = await this.artistService.AddArtistAsync(model);

            if (generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.AddArtist();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.ArtistSuffix));

            return Redirect(string.Format(RedirectConstants.AdministratorAreaArtistDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult EditArtist(int id)
        {
            ArtistDetailsViewModel artist = this.artistService.GetArtist(id);

            if (artist == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(artist);
        }

        [HttpPost]
        public async Task<IActionResult> EditArtist(EditArtistBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.EditArtist(model.Id);
            }

            int generatedId = await this.artistService.EditArtistAsync(model);

            if (generatedId < 1)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return Redirect(string.Format(RedirectConstants.AdministratorAreaArtistDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult DeleteArtist(int id)
        {
            ArtistDetailsViewModel artist = this.artistService.GetArtist(id);

            if (artist == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(artist);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteArtist(EditArtistBindingModel model)
        {
            bool isDeleted = await this.artistService.DeleteArtistAsync(model.Id);

            return RedirectToAction(RedirectConstants.IndexSuffix);
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
        public IActionResult AddArtistType()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddArtistType(AddArtistTypeBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.AddArtistType();
            }

            int generatedId = await this.artistService.AddArtistTypeAsync(model);

            if (generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.AddArtistType();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.ArtistTypeDisplay));

            return RedirectToAction(RedirectConstants.ArtistTypeDetailsSuffix, RedirectConstants.ArtistsSuffix, generatedId);
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