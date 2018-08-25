namespace MyBlog.App.Areas.Administrator.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.BindingModels.Articles;
    using MyBlog.CommonModels.ViewModels.Articles;
    using MyBlog.Services.Interfaces;
    using System.Threading.Tasks;

    public class ArticlesController : AdminController
    {
        private readonly IArticleService articleService;

        public ArticlesController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var articles = this.articleService.GetAllArticles();

            return this.View(articles);
        }

        [HttpGet]
        public IActionResult AddArticle()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle(AddArticleBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.View();
            }

            int generatedId = await this.articleService.AddArticleAsync(model);

            if(generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.View();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.ArticleSuffix));

            return Redirect(string.Format(RedirectConstants.AdministratorAreaArticleDetailsPage, generatedId));
        }

        [HttpGet]
        public  IActionResult EditArticle(int id)
        {
            ArticleDetailsViewModel article = this.articleService.GetArticle(id);

            if(article == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(article);
        }

        [HttpPost]
        public async Task<IActionResult> EditArticle(EditArticleBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.EditArticle(model.Id);
            }

            int generatedId = await this.articleService.EditArticleAsync(model);

            if(generatedId < 1)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return Redirect(string.Format(RedirectConstants.AdministratorAreaArticleDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult DeleteArticle(int id)
        {
            ArticleDetailsViewModel article = this.articleService.GetArticle(id);

            if (article == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(article);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteArticle(EditArticleBindingModel model)
        {
            bool isDeleted = await this.articleService.DeleteArticleAsync(model.Id);

            return RedirectToAction(RedirectConstants.IndexSuffix);
        }

        [HttpGet]
        public IActionResult CategoryArticles(int id)
        {
            var category = this.articleService.GetArticleCategory(id);

            if(category == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.ArticlesSuffix);
            }

            return this.View(category);
        }

        [HttpGet]
        public IActionResult AddArticleCategory()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddArticleCategory(AddArticleCategoryBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.AddArticleCategory();
            }

            int generatedId = await this.articleService.AddArticleCategoryAsync(model);

            if(generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.AddArticleCategory();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.ArticleCategoryDisplay));

            return RedirectToAction(RedirectConstants.ArticleCategorySuffix, RedirectConstants.ArticlesSuffix, generatedId);
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