namespace MyBlog.Services.PremiumServices
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyBlog.Common;
    using MyBlog.CommonModels.ViewModels.PremiumOffers;
    using MyBlog.CommonModels.ViewModels.Products;
    using MyBlog.Data;
    using MyBlog.Services.PremiumServices.Interfaces;

    public class PremiumProductService : BaseBlogService, IPremiumProductService
    {
        public PremiumProductService(BlogDataDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        
        public ICollection<ProductConciseViewModel> GetAllPremiumProducts()
        {
            var products = this.DbContext
                .Products
                .Select(this.Mapper.Map<ProductConciseViewModel>)
                .ToList();

            products.ForEach(x => x.Price *= CommonConstants.PremiumProductPriceReduce);

            return products;
        }

        public PremiumOfferDetailsViewModel GetPremiumProduct(int id)
        {
            var actualProduct = this.DbContext
                .Products
                .Include(x => x.ProductType)
                .Include(x => x.Brand)
                .FirstOrDefault(x => x.Id == id);

            if (actualProduct == null)
            {
                return null;
            }

            var productModel = this.Mapper.Map<PremiumOfferDetailsViewModel>(actualProduct);
            productModel.Price *= CommonConstants.PremiumProductPriceReduce;

            return productModel;
        }
    }
}
