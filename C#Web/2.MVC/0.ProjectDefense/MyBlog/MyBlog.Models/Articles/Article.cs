namespace MyBlog.Models.Articles
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Models.Users;
    using MyBlog.Common;

    public class Article
    {
        public Article()
        {
            this.PhotoURL = "https://s3.amazonaws.com/skinner-production/stories/featured_images/000/025/760/large/news-1.jpg?1522295632";

            this.AddedToFavoritesBy = new List<UserArticles>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.ReviewConstraints.TitleMinLength)]
        [MaxLength(ValidationConstants.ReviewConstraints.TitleMaxLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [DataType(DataType.ImageUrl, ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        public string PhotoURL { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        [DataType(DataType.Url, ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        public string HighLightVideoURL { get; set; }

        [Required]
        [MinLength(ValidationConstants.ReviewConstraints.ContentMinLength)]
        public string Content { get; set; }

        [Required]
        public int ArticleCategoryId { get; set; }

        public ArticleCategory ArticleCategory { get; set; }
        
        public ICollection<UserArticles> AddedToFavoritesBy { get; set; }
    }
}
