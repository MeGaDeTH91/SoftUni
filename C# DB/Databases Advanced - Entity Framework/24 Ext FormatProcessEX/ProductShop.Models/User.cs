namespace ProductShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Xml.Serialization;

    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        [InverseProperty("Buyer")]
        public ICollection<Product> BoughtProducts { get; set; } = new List<Product>();

        [InverseProperty("Seller")]
        public ICollection<Product> SoldProducts { get; set; } = new List<Product>();
    }
}
