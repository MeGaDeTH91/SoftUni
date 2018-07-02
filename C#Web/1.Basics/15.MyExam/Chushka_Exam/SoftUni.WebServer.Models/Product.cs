namespace SoftUni.WebServer.Models
{
    using SimpleMvc.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            this.Orders = new List<Order>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.ProductConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.ProductConstraints.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        public string Description { get; set; }

        [Required]
        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
