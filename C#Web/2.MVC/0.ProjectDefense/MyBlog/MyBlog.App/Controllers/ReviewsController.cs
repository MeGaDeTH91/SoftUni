namespace MyBlog.App.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.Models.Users;
    using MyBlog.Services.Interfaces;

    public class ReviewsController : BaseUserController
    {
        private readonly IReviewService reviewService;

        public ReviewsController(UserManager<User> userManager, IReviewService reviewService) : base(userManager)
        {
            this.reviewService = reviewService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var reviews = this.reviewService.GetAllReviews();

            return this.View(reviews);
        }
        
        [HttpGet]
        public IActionResult ReviewTypeDetails(int id)
        {
            var reviewType = this.reviewService.GetReviewType(id);

            if (reviewType == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.ReviewsSuffix);
            }

            return this.View(reviewType);
        }

        [HttpGet]
        public IActionResult AddToFavourites(int id)
        {
            var loggerUser = this.User;
            var dbUser = this.userManager.GetUserAsync(loggerUser);

            var addedToFavourites = this.reviewService.AddToFavourites(dbUser.Result.Id, id);

            if (addedToFavourites == false)
            {
                SetErrorMessage(CommonConstants.AlreadyInFavouritesOrInvalidErrorMessage);

                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.ReviewsSuffix);
            }

            SetSuccessMessage(CommonConstants.AddedToFavouritesSuccessfullyMessage);

            return Redirect(string.Format(RedirectConstants.ReviewDetailsPage, id));
        }

        private void SetSuccessMessage(string successMessage)
        {
            this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
            {
                Type = MessageType.Success,
                Message = successMessage
            });
        }

        private void SetErrorMessage(string errorMessage)
        {
            this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
            {
                Type = MessageType.Danger,
                Message = errorMessage
            });
        }
    }
}