namespace MyBlog.App.Areas.Administrator.Pages.Fun
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.Common;
    using MyBlog.CommonModels.ViewModels.Fun;
    using MyBlog.Services.Interfaces;

    public class JokeDetailsModel : BasePageModel
    {
        public JokeDetailsViewModel JokeDetailsViewModel { get; private set; }

        private readonly IJokeService jokeService;

        public int JokeId { get; set; }

        public JokeDetailsModel(IJokeService jokeService)
        {
            this.jokeService = jokeService;
        }

        public IActionResult OnGet(int id)
        {
            var joke = this.jokeService.GetJoke(id);

            if (joke == null)
            {
                SetErrorMessage(CommonConstants.NotFoundMessage);
            }

            this.JokeId = id;

            this.JokeDetailsViewModel = joke;

            return this.Page();
        }
    }
}