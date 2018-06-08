namespace ByTheCake.Models
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public Order()
        {
            this.Products = new HashSet<ProductOrder>();
        }

        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<ProductOrder> Products { get; set; }
    }
}
