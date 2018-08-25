namespace MyBlog.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;
    using MyBlog.Common;
    using MyBlog.CommonModels.BindingModels.Articles;
    using MyBlog.CommonModels.ViewModels.Articles;
    using MyBlog.Data;
    using MyBlog.Models.Articles;
    using MyBlog.Services.Interfaces;
    using MyBlog.Common.Helpers;
    using MyBlog.Models.Users;
    using System;
    using MyBlog.App.Helpers.HtmlUtilities;

    public class ArticleService : BaseBlogService, IArticleService
    {
        public ArticleService(BlogDataDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public bool AddToFavourites(string userId, int articleId)
        {
            var user = this.DbContext
                .Users
                .FirstOrDefault(x => x.Id == userId);

            var article = this.DbContext
                .Articles
                .FirstOrDefault(x => x.Id == articleId);

            if(user == null || article == null)
            {
                return false;
            }

            var userArticle = new UserArticles()
            {
                UserId = userId,
                ArticleId = articleId,
                AddedToFavouritesOn = DateTime.UtcNow
            };

            bool alreadyInFavourites = this.DbContext.FavouriteUserArticles
                .Any(x => x.UserId == userId && x.ArticleId == articleId);

            if (alreadyInFavourites)
            {
                return false;
            }

            user.FavouriteArticles.Add(userArticle);
            this.DbContext.SaveChanges();

            return true;
        }

        public async Task<int> AddArticleAsync(AddArticleBindingModel model)
        {
            var checkForDuplicate = this.DbContext
                .Articles
                .FirstOrDefault(x => x.Title == model.Title);

            if(checkForDuplicate != null)
            {
                return ErrorId;
            }

            model.Content = Html_String_Utility.EncodeThisPropertyForMe(model.Content);
            model.HighLightVideoURL = Html_String_Utility.EncodeThisPropertyForMe(model.HighLightVideoURL);
            model.PhotoURL = Html_String_Utility.EncodeThisPropertyForMe(model.PhotoURL);
            model.Title = Html_String_Utility.EncodeThisPropertyForMe(model.Title);

            var article = this.Mapper.Map<Article>(model);

            var articleCategory = this.DbContext
                .ArticleCategories
                .FirstOrDefault(x => x.CategoryName == model.ArticleCategoryName);

            if(articleCategory == null)
            {
                articleCategory = new ArticleCategory()
                {
                    CategoryName = model.ArticleCategoryName
                };
                await this.DbContext.ArticleCategories.AddAsync(articleCategory);
                await this.DbContext.SaveChangesAsync();
            }
            article.ArticleCategoryId = articleCategory.Id;

            if (article.HighLightVideoURL.Contains(CommonConstants.OriginalVideoUrlPart))
            {
                article.HighLightVideoURL = ModifyVideoURL_Embeded.ModifyEmbed(article.HighLightVideoURL);
            }

            await this.DbContext.Articles.AddAsync(article);
            await this.DbContext.SaveChangesAsync();

            return article.Id;
        }

        public async Task<int> AddArticleCategoryAsync(AddArticleCategoryBindingModel model)
        {
            var existingCategory = this.DbContext
                .ArticleCategories
                .FirstOrDefault(x => x.CategoryName == model.CategoryName);

            if(existingCategory != null)
            {
                return ErrorId;
            }

            var category = this.Mapper.Map<ArticleCategory>(model);

            await this.DbContext.ArticleCategories.AddAsync(category);
            await this.DbContext.SaveChangesAsync();

            return category.Id;

        }

        public async Task<bool> DeleteArticleAsync(int id)
        {
            var article = this.DbContext
                .Articles
                .FirstOrDefault(x => x.Id == id);

            if (article == null)
            {
                return false;
            }

            this.DbContext.Articles.Remove(article);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<int> EditArticleAsync(EditArticleBindingModel model)
        {
            var article = this.DbContext
                .Articles
                .FirstOrDefault(x => x.Id == model.Id);

            if(article == null)
            {
                return ErrorId;
            }

            model.Content = Html_String_Utility.EncodeThisPropertyForMe(model.Content);
            model.HighLightVideoURL = Html_String_Utility.EncodeThisPropertyForMe(model.HighLightVideoURL);
            model.PhotoURL = Html_String_Utility.EncodeThisPropertyForMe(model.PhotoURL);

            article.Content = model.Content;
            article.PhotoURL = model.PhotoURL;
            article.HighLightVideoURL = model.HighLightVideoURL;

            await this.DbContext.SaveChangesAsync();

            return article.Id;
        }

        public ICollection<ArticleConciseViewModel> GetAllArticles()
        {
            var articles = this.DbContext
                .Articles
                .Select(x => this.Mapper.Map<ArticleConciseViewModel>(x))
                .ToList();

            articles.ForEach(x => x.Title = Html_String_Utility.DecodeThisPropertyForMe(x.Title));
            articles.ForEach(x => x.PhotoURL = Html_String_Utility.DecodeThisPropertyForMe(x.PhotoURL));

            return articles;
        }

        public ArticleDetailsViewModel GetArticle(int id)
        {
            var actualArticle = this.DbContext
                .Articles
                .Include(x => x.ArticleCategory)
                .Include(x => x.AddedToFavoritesBy)
                .FirstOrDefault(x => x.Id == id);

            if(actualArticle == null)
            {
                return null;
            }
            
            var article = this.Mapper.Map<ArticleDetailsViewModel>(actualArticle);

            article.Content = Html_String_Utility.DecodeThisPropertyForMe(actualArticle.Content);
            article.HighLightVideoURL = Html_String_Utility.DecodeThisPropertyForMe(actualArticle.HighLightVideoURL);
            article.PhotoURL = Html_String_Utility.DecodeThisPropertyForMe(actualArticle.PhotoURL);
            article.Title = Html_String_Utility.DecodeThisPropertyForMe(actualArticle.Title);

            return article;
        }

        public ArticlesCategoryViewModel GetArticleCategory(int id)
        {
            var category = this.DbContext
                .ArticleCategories
                .Include(x => x.Articles)
                .FirstOrDefault(x => x.Id == id);

            if(category == null)
            {
                return null;
            }

            List<ArticleConciseViewModel> articles = this.Mapper.Map<ICollection<ArticleConciseViewModel>>(category.Articles).ToList();

            articles.ForEach(x => x.Title = Html_String_Utility.DecodeThisPropertyForMe(x.Title));
            articles.ForEach(x => x.PhotoURL = Html_String_Utility.DecodeThisPropertyForMe(x.PhotoURL));

            var categoryModel = new ArticlesCategoryViewModel()
            {
                CategoryName = category.CategoryName,
                Articles = articles
            };

            categoryModel.CategoryName = Html_String_Utility.DecodeThisPropertyForMe(categoryModel.CategoryName);

            return categoryModel;
        }
    }
}
