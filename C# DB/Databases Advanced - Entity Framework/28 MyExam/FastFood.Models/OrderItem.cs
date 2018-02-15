namespace FastFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class OrderItem
    {
        public int OrderId { get; set; }
        [Required]
        public Order Order { get; set; }

        public int ItemId { get; set; }
        [Required]
        public Item Item { get; set; }

        [Required]
        [Range(typeof(int), "1", "2147483646")]
        public int Quantity { get; set; }
    }
}
