namespace MyBlog.Models.Articles
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class ArticleCategory
    {
        public ArticleCategory()
        {
            this.Articles = new List<Article>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.ArticleCategoryConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.ArticleCategoryConstraints.NameMaxLength)]
        public string CategoryName { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
