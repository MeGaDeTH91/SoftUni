namespace MyBlog.CommonModels.ViewModels.Articles
{
    using System.Collections.Generic;

    public class ArticlesCategoryViewModel
    {
        public string CategoryName { get; set; }

        public ICollection<ArticleConciseViewModel> Articles { get; set; }
    }
}
