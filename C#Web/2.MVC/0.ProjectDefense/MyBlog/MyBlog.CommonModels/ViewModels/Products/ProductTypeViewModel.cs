namespace MyBlog.CommonModels.ViewModels.Products
{
    using System.Collections.Generic;

    public class ProductTypeViewModel
    {
        public int Id { get; set; }
        
        public string TypeName { get; set; }

        public ICollection<ProductConciseViewModel> Products { get; set; }
    }
}
