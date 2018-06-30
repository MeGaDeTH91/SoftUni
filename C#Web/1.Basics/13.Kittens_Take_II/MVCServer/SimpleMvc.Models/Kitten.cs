namespace SimpleMvc.Models
{
    using SimpleMvc.Common;
    using System.ComponentModel.DataAnnotations;

    public class Kitten
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.KittenConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.KittenConstraints.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Range(ValidationConstants.KittenConstraints.MinAge, ValidationConstants.KittenConstraints.MaxAge)]
        public int Age { get; set; }


        [Required]
        public int BreedId { get; set; }

        public Breed Breed { get; set; }
    }
}
