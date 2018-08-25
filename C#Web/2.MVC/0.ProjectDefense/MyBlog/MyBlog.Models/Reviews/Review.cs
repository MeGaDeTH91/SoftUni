namespace MyBlog.Models.Reviews
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Models.Users;
    using MyBlog.Common;

    public class Review
    {
        public Review()
        {
            this.PhotoURL = "http://www.leavedebtbehind.com/wp-content/uploads/2009/04/review-cover.jpg";

            this.AddedToFavoritesBy = new List<UserReviews>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.ReviewConstraints.TitleMinLength)]
        [MaxLength(ValidationConstants.ReviewConstraints.TitleMaxLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [DataType(DataType.ImageUrl, ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        public string PhotoURL { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        [DataType(DataType.Url, ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        public string HighLightVideoURL { get; set; }

        [Required]
        [DataType(DataType.Url, ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        public string AdditionalInfoURL { get; set; }

        [Required]
        [MinLength(ValidationConstants.ReviewConstraints.ContentMinLength)]
        public string Content { get; set; }

        [Required]
        public int ReviewTypeId { get; set; }

        public ReviewType ReviewType { get; set; }

        public ICollection<UserReviews> AddedToFavoritesBy { get; set; }
    }
}
