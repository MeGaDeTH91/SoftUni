namespace MyBlog.CommonModels.ViewModels.Products
{
    using System.Collections.Generic;
    using MyBlog.CommonModels.ViewModels.Brands;
    using MyBlog.Models.Users;

    public class ProductDetailsViewModel
    {
        public string ProductName { get; set; }
        
        public decimal Price { get; set; }
        
        public int BrandId { get; set; }
        public BrandConciseViewModel Brand { get; set; }
        
        public string PhotoURL { get; set; }
        
        public string HighLightVideoURL { get; set; }
        
        public string AdditionalInfoURL { get; set; }
        
        public string Description { get; set; }
        
        public int ProductTypeId { get; set; }
        public ProductTypeViewModel ProductType { get; set; }

        public ICollection<UserProducts> BoughtBy { get; set; }
    }
}
