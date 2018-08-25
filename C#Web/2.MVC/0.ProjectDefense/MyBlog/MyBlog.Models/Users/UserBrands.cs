namespace MyBlog.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Models.Brands;

    public class UserBrands
    {
        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        [Required]
        public DateTime AddedToFavouritesOn { get; set; }
    }
}
