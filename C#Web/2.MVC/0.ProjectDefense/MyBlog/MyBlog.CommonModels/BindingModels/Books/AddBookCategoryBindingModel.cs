namespace MyBlog.CommonModels.BindingModels.Books
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class AddBookCategoryBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.BookCategoryConstraints.CategoryNameMinLength)]
        [MaxLength(ValidationConstants.BookCategoryConstraints.CategoryNameMaxLength)]
        [Display(Name = CommonConstants.BookCategoryDisplay)]
        public string BookCategoryName { get; set; }
    }
}
