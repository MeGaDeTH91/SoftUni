namespace MyBlog.App.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.BindingModels.Music.Instruments;
    using MyBlog.CommonModels.ViewModels.Music.Instruments;
    using MyBlog.Models.Users;
    using MyBlog.Services.Interfaces;

    public class InstrumentsController : BaseUserController
    {
        private readonly IInstrumentService instrumentService;

        public InstrumentsController(UserManager<User> userManager, IInstrumentService instrumentService) : base(userManager)
        {
            this.instrumentService = instrumentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var instruments = this.instrumentService.GetAllInstruments();

            return this.View(instruments);
        }

        [HttpGet]
        public IActionResult AddToFavourites(int id)
        {
            var loggerUser = this.User;
            var dbUser = this.userManager.GetUserAsync(loggerUser);

            var addedToFavourites = this.instrumentService.AddToFavourites(dbUser.Result.Id, id);

            if (addedToFavourites == false)
            {
                SetErrorMessage(CommonConstants.AlreadyInFavouritesOrInvalidErrorMessage);

                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.InstrumentsSuffix);
            }

            SetSuccessMessage(CommonConstants.AddedToFavouritesSuccessfullyMessage);

            return Redirect(string.Format(RedirectConstants.InstrumentDetailsPage, id));
        }

        [HttpGet]
        public IActionResult InstrumentTypeDetails(int id)
        {
            var instrumentType = this.instrumentService.GetInstrumentType(id);

            if (instrumentType == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.InstrumentsSuffix);
            }

            return this.View(instrumentType);
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