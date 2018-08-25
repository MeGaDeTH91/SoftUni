namespace MyBlog.Models.Brands
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class BrandType
    {
        public BrandType()
        {
            this.Brands = new List<Brand>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.BrandTypeConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.BrandTypeConstraints.NameMaxLength)]
        public string TypeName { get; set; }

        public ICollection<Brand> Brands { get; set; }
    }
}
