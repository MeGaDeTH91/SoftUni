namespace MyBlog.Services.Interfaces
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using MyBlog.CommonModels.ViewModels.Reviews;
    using MyBlog.CommonModels.BindingModels.Reviews;

    public interface IReviewService
    {
        bool AddToFavourites(string userId, int reviewId);

        ICollection<ReviewConciseViewModel> GetAllReviews();

        AddReviewBindingModel GetAllReviewTypes();

        ReviewDetailsViewModel GetReview(int id);

        ReviewTypeViewModel GetReviewType(int id);

        Task<int> AddReviewAsync(AddReviewBindingModel model);

        Task<int> EditReviewAsync(EditReviewBindingModel model);

        Task<bool> DeleteReviewAsync(int id);

        Task<int> AddReviewTypeAsync(AddReviewTypeBindingModel model);
    }
}
