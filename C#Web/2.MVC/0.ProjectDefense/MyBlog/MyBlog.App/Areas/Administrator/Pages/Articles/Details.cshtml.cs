namespace MyBlog.App.Areas.Administrator.Pages.Articles
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.ViewModels.Articles;
    using MyBlog.Services.Interfaces;

    public class DetailsModel : BasePageModel
    {
        public ArticleDetailsViewModel ArticleDetailsViewModel { get; private set; }
        private readonly IArticleService articleService;

        public int ArticleId { get; private set; }
        public int Likes { get; private set; }

        public DetailsModel(IArticleService articleService)
        {
            this.articleService = articleService;
        }
        
        public IActionResult OnGet(int id)
        {
            var article = this.articleService.GetArticle(id);

            if(article == null)
            {
                this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
                {
                    Type = MessageType.Danger,
                    Message = CommonConstants.NotFoundMessage
                });
            }

            this.ArticleId = id;

            this.ArticleDetailsViewModel = article;

            this.Likes = this.ArticleDetailsViewModel.AddedToFavoritesBy.Count;

            return this.Page();
        }
    }
}