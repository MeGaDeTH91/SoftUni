namespace MyBlog.App.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.BindingModels.Music.Instruments;
    using MyBlog.CommonModels.ViewModels.Music.Instruments;
    using MyBlog.Services.Interfaces;

    public class InstrumentsController : AdminController
    {
        private readonly IInstrumentService instrumentService;

        public InstrumentsController(IInstrumentService instrumentService)
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
        public IActionResult AddInstrument()
        {
            var model = this.instrumentService.GetAllBrandsAndInstrumentTypes();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddInstrument(AddInstrumentBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.AddInstrument();
            }

            int generatedId = await this.instrumentService.AddInstrumentAsync(model);

            if (generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.AddInstrument();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.InstrumentSuffix));

            return Redirect(string.Format(RedirectConstants.AdministratorAreaInstrumentDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult EditInstrument(int id)
        {
            InstrumentDetailsViewModel instrument = this.instrumentService.GetInstrument(id);

            if (instrument == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(instrument);
        }

        [HttpPost]
        public async Task<IActionResult> EditInstrument(EditInstrumentBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.EditInstrument(model.Id);
            }

            int generatedId = await this.instrumentService.EditInstrumentAsync(model);

            if (generatedId < 1)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return Redirect(string.Format(RedirectConstants.AdministratorAreaInstrumentDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult DeleteInstrument(int id)
        {
            InstrumentDetailsViewModel instrument = this.instrumentService.GetInstrument(id);

            if (instrument == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(instrument);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteInstrument(EditInstrumentBindingModel model)
        {
            bool isDeleted = await this.instrumentService.DeleteInstrumentAsync(model.Id);

            return RedirectToAction(RedirectConstants.IndexSuffix);
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

        [HttpGet]
        public IActionResult AddInstrumentType()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddInstrumentType(AddInstrumentTypeBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.AddInstrumentType();
            }

            int generatedId = await this.instrumentService.AddInstrumentTypeAsync(model);

            if (generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.AddInstrumentType();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.InstrumentTypeDisplay));

            return RedirectToAction(RedirectConstants.InstrumentTypeDetailsSuffix, RedirectConstants.InstrumentsSuffix, generatedId);
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