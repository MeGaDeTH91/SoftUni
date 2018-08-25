namespace MyBlog.Models.Fun
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Models.Users;
    using MyBlog.Common;

    public class Joke
    {
        public Joke()
        {
            this.AddedToFavoritesBy = new List<UserJokes>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.JokeConstraints.TitleMinLength)]
        [MaxLength(ValidationConstants.JokeConstraints.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ValidationConstants.JokeConstraints.ContentMinLength)]
        public string Content { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [DataType(DataType.ImageUrl, ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        public string PhotoURL { get; set; }
        
        public ICollection<UserJokes> AddedToFavoritesBy { get; set; }
    }
}
