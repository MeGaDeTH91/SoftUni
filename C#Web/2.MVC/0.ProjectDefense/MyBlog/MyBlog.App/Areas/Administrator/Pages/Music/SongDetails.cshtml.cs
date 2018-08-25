namespace MyBlog.App.Areas.Administrator.Pages.Music
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.ViewModels.Music.Songs;
    using MyBlog.Services.Interfaces;

    public class SongDetailsModel : BasePageModel
    {
        public SongDetailsViewModel SongDetailsViewModel { get; private set; }
        private readonly ISongService songService;

        public int SongId { get; set; }

        public SongDetailsModel(ISongService songService)
        {
            this.songService = songService;
        }

        public IActionResult OnGet(int id)
        {
            var song = this.songService.GetSong(id);

            if (song == null)
            {
                this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
                {
                    Type = MessageType.Danger,
                    Message = CommonConstants.NotFoundMessage
                });
            }

            this.SongId = id;

            this.SongDetailsViewModel = song;

            return this.Page();
        }
    }
}