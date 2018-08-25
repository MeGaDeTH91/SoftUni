namespace MyBlog.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using MyBlog.Common;
    using MyBlog.Common.Helpers;
    using MyBlog.CommonModels.BindingModels.Reviews;
    using MyBlog.CommonModels.ViewModels.Reviews;
    using MyBlog.Data;
    using MyBlog.Models.Reviews;
    using MyBlog.Models.Users;
    using MyBlog.Services.Interfaces;

    public class ReviewService : BaseBlogService, IReviewService
    {
        public ReviewService(BlogDataDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public bool AddToFavourites(string userId, int reviewId)
        {
            var user = this.DbContext
                .Users
                .FirstOrDefault(x => x.Id == userId);

            var review = this.DbContext
                .Reviews
                .FirstOrDefault(x => x.Id == reviewId);

            if (user == null || review == null)
            {
                return false;
            }

            var userReview = new UserReviews()
            {
                UserId = userId,
                ReviewId = reviewId,
                AddedToFavouritesOn = DateTime.UtcNow
            };

            bool alreadyInFavourites = this.DbContext.FavouriteUserReviews
                .Any(x => x.UserId == userId && x.ReviewId == reviewId);

            if (alreadyInFavourites)
            {
                return false;
            }

            user.FavouriteReviews.Add(userReview);
            this.DbContext.SaveChanges();

            return true;
        }

        public async Task<int> AddReviewAsync(AddReviewBindingModel model)
        {
            var checkForDuplicate = this.DbContext
                .Reviews
                .FirstOrDefault(x => x.Title == model.Title);

            if (checkForDuplicate != null)
            {
                return ErrorId;
            }

            var review = this.Mapper.Map<Review>(model);

            if (review.HighLightVideoURL.Contains(CommonConstants.OriginalVideoUrlPart))
            {
                review.HighLightVideoURL = ModifyVideoURL_Embeded.ModifyEmbed(review.HighLightVideoURL);
            }

            await this.DbContext.Reviews.AddAsync(review);
            await this.DbContext.SaveChangesAsync();

            return review.Id;
        }

        public async Task<int> AddReviewTypeAsync(AddReviewTypeBindingModel model)
        {
            var existingType = this.DbContext
                .ReviewTypes
                .FirstOrDefault(x => x.ReviewTypeName == model.ReviewTypeName);

            if (existingType != null)
            {
                return ErrorId;
            }

            var type = this.Mapper.Map<ReviewType>(model);

            await this.DbContext.ReviewTypes.AddAsync(type);
            await this.DbContext.SaveChangesAsync();

            return type.Id;
        }
        
        public async Task<bool> DeleteReviewAsync(int id)
        {
            var review = this.DbContext
                .Reviews
                .FirstOrDefault(x => x.Id == id);

            if (review == null)
            {
                return false;
            }

            this.DbContext.Reviews.Remove(review);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<int> EditReviewAsync(EditReviewBindingModel model)
        {
            var review = this.DbContext
                .Reviews
                .FirstOrDefault(x => x.Id == model.Id);

            if (review == null)
            {
                return ErrorId;
            }

            review.Content = model.Content;
            review.PhotoURL = model.PhotoURL;
            review.HighLightVideoURL = model.HighLightVideoURL;
            review.AdditionalInfoURL = model.AdditionalInfoURL;

            if (review.HighLightVideoURL.Contains(CommonConstants.OriginalVideoUrlPart))
            {
                review.HighLightVideoURL = ModifyVideoURL_Embeded.ModifyEmbed(review.HighLightVideoURL);
            }

            await this.DbContext.SaveChangesAsync();

            return review.Id;
        }

        public ICollection<ReviewConciseViewModel> GetAllReviews()
        {
            var reviews = this.DbContext
                .Reviews
                .Select(this.Mapper.Map<ReviewConciseViewModel>)
                .ToList();

            return reviews;
        }

        public AddReviewBindingModel GetAllReviewTypes()
        {
            var reviewTypes = this.DbContext
                .ReviewTypes
                .Select(this.Mapper.Map<ReviewTypeViewModel>)
                .ToList();
            
            var reviewTypesQuery = reviewTypes.Select(b => new SelectListItem() { Text = b.ReviewTypeName, Value = b.Id.ToString() });

            var model = new AddReviewBindingModel()
            {
                AllReviewTypes = reviewTypesQuery.ToList()
            };

            return model;
        }

        public ReviewDetailsViewModel GetReview(int id)
        {
            var actualReview = this.DbContext
                .Reviews
                .Include(x => x.ReviewType)
                .Include(x => x.AddedToFavoritesBy)
                .FirstOrDefault(x => x.Id == id);

            if (actualReview == null)
            {
                return null;
            }

            var reviewModel = this.Mapper.Map<ReviewDetailsViewModel>(actualReview);

            return reviewModel;
        }

        public ReviewTypeViewModel GetReviewType(int id)
        {
            var reviewType = this.DbContext
                .ReviewTypes
                .Include(x => x.Reviews)
                .FirstOrDefault(x => x.Id == id);

            if (reviewType == null)
            {
                return null;
            }

            var reviewTypeModel = new ReviewTypeViewModel()
            {
                ReviewTypeName = reviewType.ReviewTypeName,
                Reviews = this.Mapper.Map<ICollection<ReviewConciseViewModel>>(reviewType.Reviews)
            };

            return reviewTypeModel;
        }
    }
}
