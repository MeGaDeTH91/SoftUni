namespace MyBlog.Services.PremiumServices.Interfaces
{
    using System.Collections.Generic;
    using MyBlog.CommonModels.ViewModels.PremiumOffers;
    using MyBlog.CommonModels.ViewModels.Products;

    public interface IPremiumProductService
    {
        ICollection<ProductConciseViewModel> GetAllPremiumProducts();

        PremiumOfferDetailsViewModel GetPremiumProduct(int id);
    }
}
