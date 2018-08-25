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

    public class MemesController : AdminController
    {
        private readonly IMemeService memeService;

        public MemesController(IMemeService memeService)
        {
            this.memeService = memeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var memes = this.memeService.GetAllMemes();

            return this.View(memes);
        }

        [HttpGet]
        public IActionResult AddMeme()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMeme(AddMemeBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.AddMeme();
            }

            int generatedId = await this.memeService.AddMemeAsync(model);

            if (generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.AddMeme();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.MemeSuffix));

            return Redirect(string.Format(RedirectConstants.AdministratorAreaMemeDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult EditMeme(int id)
        {
            MemeDetailsViewModel meme = this.memeService.GetMeme(id);

            if (meme == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(meme);
        }

        [HttpPost]
        public async Task<IActionResult> EditMeme(EditMemeBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.EditMeme(model.Id);
            }

            int generatedId = await this.memeService.EditMemeAsync(model);

            if (generatedId < 1)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return Redirect(string.Format(RedirectConstants.AdministratorAreaMemeDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult DeleteMeme(int id)
        {
            MemeDetailsViewModel brand = this.memeService.GetMeme(id);

            if (brand == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(brand);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMeme(EditMemeBindingModel model)
        {
            bool isDeleted = await this.memeService.DeleteMemeAsync(model.Id);

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