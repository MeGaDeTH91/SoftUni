namespace SoftUni.WebServer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using SimpleMvc.Common;    

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
        public string ProductTypeName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
