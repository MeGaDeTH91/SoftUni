namespace MyBlog.CommonModels.ViewModels.Reviews
{
    using System.Collections.Generic;
    using MyBlog.Models.Users;

    public class ReviewDetailsViewModel
    {
        public string Title { get; set; }
        
        public string PhotoURL { get; set; }
        
        public string HighLightVideoURL { get; set; }
        
        public string AdditionalInfoURL { get; set; }
        
        public string Content { get; set; }

        public int ReviewTypeId { get; set; }
        public ReviewTypeViewModel ReviewType { get; set; }

        public ICollection<UserReviews> AddedToFavoritesBy { get; set; }
    }
}
