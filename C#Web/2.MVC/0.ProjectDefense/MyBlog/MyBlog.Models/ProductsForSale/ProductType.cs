namespace MyBlog.Models.ProductsForSale
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class ProductType
    {
        public ProductType()
        {
            this.Products = new List<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.ProductTypeConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.ProductTypeConstraints.NameMaxLength)]
        public string TypeName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
