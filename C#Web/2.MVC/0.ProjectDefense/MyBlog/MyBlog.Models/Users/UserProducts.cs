namespace MyBlog.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Models.ProductsForSale;

    public class UserProducts
    {
        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        public DateTime BoughtOn { get; set; }
    }
}
