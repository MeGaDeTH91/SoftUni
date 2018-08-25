namespace MyBlog.App.Pages.Music
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.ViewModels.Music.Artists;
    using MyBlog.Services.Interfaces;

    public class ArtistDetailsModel : BaseUserPageModel
    {
        public ArtistDetailsViewModel ArtistDetailsViewModel { get; private set; }
        private readonly IArtistService artistService;

        public int ArtistId { get; set; }
        public int Likes { get; private set; }

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
            this.Likes = this.ArtistDetailsViewModel.AddedToFavoritesBy.Count;

            return this.Page();
        }
    }
}