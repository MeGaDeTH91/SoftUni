namespace MyBlog.App.Areas.Administrator.Pages.Music
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.ViewModels.Music.Artists;
    using MyBlog.Services.Interfaces;

    public class ArtistDetailsModel : BasePageModel
    {
        public ArtistDetailsViewModel ArtistDetailsViewModel { get; private set; }
        private readonly IArtistService artistService;

        public int ArtistId { get; private set; }

        public ArtistDetailsModel(IArtistService artistService)
        {
            this.artistService = artistService;
        }

        public IActionResult OnGet(int id)
        {
            var artist = this.artistService.GetArtist(id);

            if (artist == null)
            {
                this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
                {
                    Type = MessageType.Danger,
                    Message = CommonConstants.NotFoundMessage
                });
            }

            this.ArtistId = id;

            this.ArtistDetailsViewModel = artist;

            return this.Page();
        }
    }
}