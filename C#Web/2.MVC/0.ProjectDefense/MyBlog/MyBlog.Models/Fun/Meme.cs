namespace MyBlog.Models.Fun
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Models.Users;
    using MyBlog.Common;

    public class Meme
    {
        public Meme()
        {
            this.AddedToFavoritesBy = new List<UserMemes>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MemeConstraints.TitleMinLength)]
        [MaxLength(ValidationConstants.MemeConstraints.TitleMaxLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [DataType(DataType.ImageUrl, ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        public string PhotoURL { get; set; }
        
        public ICollection<UserMemes> AddedToFavoritesBy { get; set; }
    }
}
