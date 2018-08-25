namespace MyBlog.App.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.BindingModels.Fun;
    using MyBlog.CommonModels.ViewModels.Fun;
    using MyBlog.Services.Interfaces;

    public class JokesController : AdminController
    {
        private readonly IJokeService jokeService;

        public JokesController(IJokeService jokeService)
        {
            this.jokeService = jokeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var jokes = this.jokeService.GetAllJokes();

            return this.View(jokes);
        }

        [HttpGet]
        public IActionResult AddJoke()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddJoke(AddJokeBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.AddJoke();
            }

            int generatedId = await this.jokeService.AddJokeAsync(model);

            if (generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.AddJoke();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.JokeSuffix));

            return Redirect(string.Format(RedirectConstants.AdministratorAreaJokeDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult EditJoke(int id)
        {
            JokeDetailsViewModel joke = this.jokeService.GetJoke(id);

            if (joke == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.JokesSuffix);
            }

            return this.View(joke);
        }

        [HttpPost]
        public async Task<IActionResult> EditJoke(EditJokeBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.EditJoke(model.Id);
            }

            int generatedId = await this.jokeService.EditJokeAsync(model);

            if (generatedId < 1)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return Redirect(string.Format(RedirectConstants.AdministratorAreaJokeDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult DeleteJoke(int id)
        {
            JokeDetailsViewModel joke = this.jokeService.GetJoke(id);

            if (joke == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(joke);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteJoke(EditJokeBindingModel model)
        {
            bool isDeleted = await this.jokeService.DeleteJokeAsync(model.Id);

            return RedirectToAction(RedirectConstants.IndexSuffix);
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