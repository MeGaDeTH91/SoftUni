namespace MyBlog.App.Pages.Fun
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.Common;
    using MyBlog.CommonModels.ViewModels.Fun;
    using MyBlog.Services.Interfaces;

    public class JokeDetailsModel : BaseUserPageModel
    {
        public JokeDetailsViewModel JokeDetailsViewModel { get; private set; }

        private readonly IJokeService jokeService;

        public int JokeId { get; set; }
        public int Likes { get; private set; }

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
            this.Likes = this.JokeDetailsViewModel.AddedToFavoritesBy.Count;

            return this.Page();
        }
    }
}