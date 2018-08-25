namespace MyBlog.CommonModels.ViewModels.Fun
{
    using System.Collections.Generic;
    using MyBlog.Models.Users;

    public class MemeDetailsViewModel
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string PhotoURL { get; set; }

        public ICollection<UserMemes> AddedToFavoritesBy { get; set; }
    }
}
