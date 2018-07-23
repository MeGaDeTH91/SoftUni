namespace MyLibrary.Models
{
    using MyLibrary.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Director
    {
        public Director()
        {
            this.Movies = new List<Movie>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.DirectorConstants.NameMinLength)]
        [MaxLength(ValidationConstants.DirectorConstants.NameMaxLength)]
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
