namespace MyBlog.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Models.Articles;

    public class UserArticles
    {
        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int ArticleId { get; set; }

        public Article Article { get; set; }

        [Required]
        public DateTime AddedToFavouritesOn { get; set; }
    }
}
