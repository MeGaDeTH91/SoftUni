namespace MyBlog.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Models.Books;

    public class UserBooks
    {
        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int BookId { get; set; }

        public Book Book { get; set; }

        [Required]
        public DateTime AddedToFavouritesOn { get; set; }
    }
}
