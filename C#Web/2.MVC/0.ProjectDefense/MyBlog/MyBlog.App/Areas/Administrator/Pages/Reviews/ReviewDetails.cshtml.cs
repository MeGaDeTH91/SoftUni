namespace MyBlog.App.Areas.Administrator.Pages.Reviews
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.ViewModels.Reviews;
    using MyBlog.Services.Interfaces;

    public class ReviewDetailsModel : BasePageModel
    {
        public ReviewDetailsViewModel ReviewDetailsViewModel { get; private set; }
        private readonly IReviewService reviewService;

        public int ReviewId { get; set; }

        public ReviewDetailsModel(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        public IActionResult OnGet(int id)
        {
            var review = this.reviewService.GetReview(id);

            if (review == null)
            {
                this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
                {
                    Type = MessageType.Danger,
                    Message = CommonConstants.NotFoundMessage
                });
            }

            this.ReviewId = id;

            this.ReviewDetailsViewModel = review;

            return this.Page();
        }
    }
}