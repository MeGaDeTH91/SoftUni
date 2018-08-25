namespace MyBlog.Services.Interfaces
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using MyBlog.CommonModels.ViewModels.Products;
    using MyBlog.CommonModels.BindingModels.Products;

    public interface IProductService
    {
        bool BuyProduct(string userId, int productId);

        ICollection<ProductConciseViewModel> GetAllProducts();

        AddProductBindingModel GetAllBrandsAndProductTypes();

        ProductDetailsViewModel GetProduct(int id);

        ProductTypeViewModel GetProductType(int id);

        Task<int> AddProductAsync(AddProductBindingModel model);

        Task<int> EditProductAsync(EditProductBindingModel model);

        Task<bool> DeleteProductAsync(int id);

        Task<int> AddProductTypeAsync(AddProductTypeBindingModel model);
    }
}
