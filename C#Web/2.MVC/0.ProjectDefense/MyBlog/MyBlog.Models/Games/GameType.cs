namespace MyBlog.Models.Games
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class GameType
    {
        public GameType()
        {
            this.Games = new List<Game>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.GameTypeConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.GameTypeConstraints.NameMaxLength)]
        public string GameTypeName { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
