namespace MyBlog.App.Areas.Administrator.Pages.Fun
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.Common;
    using MyBlog.CommonModels.ViewModels.Fun;
    using MyBlog.Services.Interfaces;

    public class MemeDetailsModel : BasePageModel
    {
        public MemeDetailsViewModel MemeDetailsViewModel { get; private set; }
        private readonly IMemeService memeService;

        public int MemeId { get; set; }

        public MemeDetailsModel(IMemeService memeService)
        {
            this.memeService = memeService;
        }

        public IActionResult OnGet(int id)
        {
            var meme = this.memeService.GetMeme(id);

            if (meme == null)
            {
                SetErrorMessage(CommonConstants.NotFoundMessage);
            }

            this.MemeId = id;

            this.MemeDetailsViewModel = meme;

            return this.Page();
        }
    }
}