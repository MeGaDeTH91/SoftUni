namespace MyBlog.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Models.Reviews;

    public class UserReviews
    {
        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int ReviewId { get; set; }

        public Review Review { get; set; }

        [Required]
        public DateTime AddedToFavouritesOn { get; set; }
    }
}
