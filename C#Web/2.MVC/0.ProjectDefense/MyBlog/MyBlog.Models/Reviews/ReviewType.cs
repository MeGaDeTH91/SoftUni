namespace MyBlog.Models.Reviews
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class ReviewType
    {
        public ReviewType()
        {
            this.Reviews = new List<Review>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.ReviewTypeConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.ReviewTypeConstraints.NameMaxLength)]
        public string ReviewTypeName { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
