namespace MyBlog.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using MyBlog.Common;
    using MyBlog.Common.Helpers;
    using MyBlog.CommonModels.BindingModels.Products;
    using MyBlog.CommonModels.ViewModels.Brands;
    using MyBlog.CommonModels.ViewModels.Products;
    using MyBlog.Data;
    using MyBlog.Models.ProductsForSale;
    using MyBlog.Models.Users;
    using MyBlog.Services.Interfaces;

    public class ProductService : BaseBlogService, IProductService
    {
        public ProductService(BlogDataDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public bool BuyProduct(string userId, int productId)
        {
            var user = this.DbContext
                .Users
                .FirstOrDefault(x => x.Id == userId);

            var product = this.DbContext
                .Products
                .FirstOrDefault(x => x.Id == productId);

            if (user == null || product == null)
            {
                return false;
            }

            var userProduct = new UserProducts()
            {
                UserId = userId,
                ProductId = productId,
                BoughtOn = DateTime.UtcNow
            };

            bool alreadyInFavourites = this.DbContext.UserBoughtProducts
                .Any(x => x.UserId == userId && x.ProductId == productId);

            if (alreadyInFavourites)
            {
                return false;
            }

            user.BoughtProducts.Add(userProduct);
            this.DbContext.SaveChanges();

            return true;
        }

        public async Task<int> AddProductAsync(AddProductBindingModel model)
        {
            var checkForDuplicate = this.DbContext
                .Products
                .FirstOrDefault(x => x.ProductName == model.ProductName);

            if (checkForDuplicate != null)
            {
                return ErrorId;
            }

            var product = this.Mapper.Map<Product>(model);
            
            if (product.HighLightVideoURL.Contains(CommonConstants.OriginalVideoUrlPart))
            {
                product.HighLightVideoURL = ModifyVideoURL_Embeded.ModifyEmbed(product.HighLightVideoURL);
            }

            await this.DbContext.Products.AddAsync(product);
            await this.DbContext.SaveChangesAsync();

            return product.Id;
        }

        public async Task<int> AddProductTypeAsync(AddProductTypeBindingModel model)
        {
            var existingType = this.DbContext
                .ProductTypes
                .FirstOrDefault(x => x.TypeName == model.TypeName);

            if (existingType != null)
            {
                return ErrorId;
            }

            var type = this.Mapper.Map<ProductType>(model);

            await this.DbContext.ProductTypes.AddAsync(type);
            await this.DbContext.SaveChangesAsync();

            return type.Id;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = this.DbContext
                .Products
                .FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return false;
            }

            this.DbContext.Products.Remove(product);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<int> EditProductAsync(EditProductBindingModel model)
        {
            var product = this.DbContext
                .Products
                .FirstOrDefault(x => x.Id == model.Id);

            if (product == null)
            {
                return ErrorId;
            }

            product.Description = model.Description;
            product.PhotoURL = model.PhotoURL;
            product.HighLightVideoURL = model.HighLightVideoURL;
            product.AdditionalInfoURL = model.AdditionalInfoURL;
            product.Price = model.Price;

            if (product.HighLightVideoURL.Contains(CommonConstants.OriginalVideoUrlPart))
            {
                product.HighLightVideoURL = ModifyVideoURL_Embeded.ModifyEmbed(product.HighLightVideoURL);
            }

            await this.DbContext.SaveChangesAsync();

            return product.Id;
        }

        public ICollection<ProductConciseViewModel> GetAllProducts()
        {
            var products = this.DbContext
                .Products
                .Select(this.Mapper.Map<ProductConciseViewModel>)
                .ToList();

            return products;
        }

        public ProductDetailsViewModel GetProduct(int id)
        {
            var actualProduct = this.DbContext
                .Products
                .Include(x => x.ProductType)
                .Include(x => x.Brand)
                .Include(x => x.BoughtBy)
                .FirstOrDefault(x => x.Id == id);

            if (actualProduct == null)
            {
                return null;
            }

            var productModel = this.Mapper.Map<ProductDetailsViewModel>(actualProduct);

            return productModel;
        }

        public ProductTypeViewModel GetProductType(int id)
        {
            var productType = this.DbContext
                .ProductTypes
                .Include(x => x.Products)
                .FirstOrDefault(x => x.Id == id);

            if (productType == null)
            {
                return null;
            }

            var instrumentTypeModel = new ProductTypeViewModel()
            {
                TypeName = productType.TypeName,
                Products = this.Mapper.Map<ICollection<ProductConciseViewModel>>(productType.Products)
            };

            return instrumentTypeModel;
        }

        public AddProductBindingModel GetAllBrandsAndProductTypes()
        {
            var brands = this.DbContext
                .Brands
                .Select(this.Mapper.Map<BrandConciseViewModel>)
                .ToList();

            var productTypes = this.DbContext
                .ProductTypes
                .Select(this.Mapper.Map<ProductTypeViewModel>)
                .ToList();

            var brandsQuery = brands.Select(b => new SelectListItem() { Text = b.BrandName, Value = b.Id.ToString() });
            var productTypesQuery = productTypes.Select(b => new SelectListItem() { Text = b.TypeName, Value = b.Id.ToString() });

            var model = new AddProductBindingModel()
            {
                AllBrands = brandsQuery.ToList(),
                AllProductTypes = productTypesQuery.ToList()
            };

            return model;
        }
    }
}
