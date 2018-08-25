namespace MyBlog.App.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.Models.Users;
    using MyBlog.Services.Interfaces;

    public class ArticlesController : BaseUserController
    {
        private readonly IArticleService articleService;

        public ArticlesController(UserManager<User> userManager, IArticleService articleService) : base(userManager)
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
        public IActionResult AddToFavourites(int id)
        {
            var loggerUser = this.User;
            var dbUser = this.userManager.GetUserAsync(loggerUser);

            var addedToFavourites = this.articleService.AddToFavourites(dbUser.Result.Id, id);

            if (addedToFavourites == false)
            {
                SetErrorMessage(CommonConstants.AlreadyInFavouritesOrInvalidErrorMessage);

                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.ArticlesSuffix);
            }

            SetSuccessMessage(CommonConstants.AddedToFavouritesSuccessfullyMessage);

            return Redirect(string.Format(RedirectConstants.ArticleDetailsPage, id));
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