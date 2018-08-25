namespace MyBlog.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MyBlog.CommonModels.BindingModels.Articles;
    using MyBlog.CommonModels.ViewModels.Articles;

    public interface IArticleService
    {
        bool AddToFavourites(string userId, int articleId);

        ICollection<ArticleConciseViewModel> GetAllArticles();

        ArticleDetailsViewModel GetArticle(int id);

        ArticlesCategoryViewModel GetArticleCategory(int id);

        Task<int> AddArticleAsync(AddArticleBindingModel model);

        Task<int> EditArticleAsync(EditArticleBindingModel model);

        Task<bool> DeleteArticleAsync(int id);

        Task<int> AddArticleCategoryAsync(AddArticleCategoryBindingModel model);
    }
}
