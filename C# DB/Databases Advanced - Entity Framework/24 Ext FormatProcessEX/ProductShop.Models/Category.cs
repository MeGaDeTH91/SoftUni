using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }

        public ICollection<CategoryProduct> CategoriesProducts { get; set; } = new List<CategoryProduct>();
    }
}
