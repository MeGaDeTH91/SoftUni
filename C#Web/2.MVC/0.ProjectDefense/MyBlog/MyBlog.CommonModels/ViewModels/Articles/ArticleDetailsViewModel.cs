namespace MyBlog.CommonModels.ViewModels.Articles
{
    using System.Collections.Generic;
    using MyBlog.Models.Articles;
    using MyBlog.Models.Users;

    public class ArticleDetailsViewModel
    {
        public string Title { get; set; }
        
        public string PhotoURL { get; set; }
        
        public string HighLightVideoURL { get; set; }
        
        public string Content { get; set; }
        
        public int ArticleCategoryId { get; set; }

        public ArticleCategory ArticleCategory { get; set; }
        
        public ICollection<UserArticles> AddedToFavoritesBy { get; set; }
    }
}
