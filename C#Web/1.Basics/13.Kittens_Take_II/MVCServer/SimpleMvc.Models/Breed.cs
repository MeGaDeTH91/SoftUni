namespace SimpleMvc.Models
{
    using SimpleMvc.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Breed
    {
        public Breed()
        {
            this.Kittens = new List<Kitten>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        [MinLength(ValidationConstants.KittenConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.KittenConstraints.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public ICollection<Kitten> Kittens { get; set; }
    }
}
