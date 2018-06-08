namespace ByTheCake.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            this.Orders = new HashSet<ProductOrder>();
            this.ImageURL = "https://www.archiesonline.com/upload/product/large/Happy_Birthday_Choco_Cake_PRCAKE139_70abbd2d.jpg";
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        
        public decimal Price { get; set; }

        [StringLength(2048)]
        [MinLength(0)]
        public string ImageURL { get; set; }

        public ICollection<ProductOrder> Orders { get; set; }
    }
}
