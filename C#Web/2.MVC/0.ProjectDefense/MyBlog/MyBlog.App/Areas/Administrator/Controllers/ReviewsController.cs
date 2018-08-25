namespace MyBlog.App.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.BindingModels.Reviews;
    using MyBlog.CommonModels.ViewModels.Reviews;
    using MyBlog.Services.Interfaces;

    public class ReviewsController : AdminController
    {
        private readonly IReviewService reviewService;

        public ReviewsController(IReviewService reviewService)
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
        public IActionResult AddReview()
        {
            var model = this.reviewService.GetAllReviewTypes();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(AddReviewBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.AddReview();
            }

            int generatedId = await this.reviewService.AddReviewAsync(model);

            if (generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.AddReview();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.ReviewSuffix));

            return Redirect(string.Format(RedirectConstants.AdministratorAreaReviewDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult EditReview(int id)
        {
            ReviewDetailsViewModel review = this.reviewService.GetReview(id);

            if (review == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(review);
        }

        [HttpPost]
        public async Task<IActionResult> EditReview(EditReviewBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.EditReview(model.Id);
            }

            int generatedId = await this.reviewService.EditReviewAsync(model);

            if (generatedId < 1)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return Redirect(string.Format(RedirectConstants.AdministratorAreaReviewDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult DeleteReview(int id)
        {
            ReviewDetailsViewModel review = this.reviewService.GetReview(id);

            if (review == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(review);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReview(EditReviewBindingModel model)
        {
            bool isDeleted = await this.reviewService.DeleteReviewAsync(model.Id);

            return RedirectToAction(RedirectConstants.IndexSuffix);
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
        public IActionResult AddReviewType()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReviewType(AddReviewTypeBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.AddReviewType();
            }

            int generatedId = await this.reviewService.AddReviewTypeAsync(model);

            if (generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.AddReviewType();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.ReviewTypeDisplay));

            return RedirectToAction(RedirectConstants.ReviewTypeDetailsSuffix, RedirectConstants.ReviewsSuffix, generatedId);
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