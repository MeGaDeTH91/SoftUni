namespace MyBlog.App.Areas.Administrator.Pages.Music
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.ViewModels.Music.Instruments;
    using MyBlog.Services.Interfaces;

    public class InstrumentDetailsModel : BasePageModel
    {
        public InstrumentDetailsViewModel InstrumentDetailsViewModel { get; private set; }
        private readonly IInstrumentService instrumentService;

        public int InstrumentId { get; set; }

        public InstrumentDetailsModel(IInstrumentService instrumentService)
        {
            this.instrumentService = instrumentService;
        }

        public IActionResult OnGet(int id)
        {
            var instrument = this.instrumentService.GetInstrument(id);

            if (instrument == null)
            {
                this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
                {
                    Type = MessageType.Danger,
                    Message = CommonConstants.NotFoundMessage
                });
            }

            this.InstrumentId = id;

            this.InstrumentDetailsViewModel = instrument;

            return this.Page();
        }
    }
}