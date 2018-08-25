namespace MyBlog.CommonModels.ViewModels.PremiumOffers
{
    using MyBlog.CommonModels.ViewModels.Brands;
    using MyBlog.CommonModels.ViewModels.Products;

    public class PremiumOfferDetailsViewModel
    {
        public int Id { get; set; }

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
    }
}
