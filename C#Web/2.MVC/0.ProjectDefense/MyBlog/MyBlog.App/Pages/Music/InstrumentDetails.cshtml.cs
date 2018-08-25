namespace MyBlog.App.Pages.Music
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.ViewModels.Music.Instruments;
    using MyBlog.Services.Interfaces;

    public class InstrumentDetailsModel : BaseUserPageModel
    {
        public InstrumentDetailsViewModel InstrumentDetailsViewModel { get; private set; }
        private readonly IInstrumentService instrumentService;

        public int InstrumentId { get; set; }
        public int Likes { get; private set; }

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
            this.Likes = this.InstrumentDetailsViewModel.AddedToFavoritesBy.Count;

            return this.Page();
        }
    }
}