namespace FDMC.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Cat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public int Age { get; set; }

        [Required]
        public string Breed { get; set; }

        public string ImageURL { get; set; }
    }
}
