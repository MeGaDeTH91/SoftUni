namespace MyBlog.Services.Interfaces
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using MyBlog.CommonModels.ViewModels.Brands;
    using MyBlog.CommonModels.BindingModels.Brands;

    public interface IBrandService
    {
        bool AddToFavourites(string userId, int brandId);

        ICollection<BrandConciseViewModel> GetAllBrands();

        BrandDetailsViewModel GetBrand(int id);

        BrandTypeViewModel GetBrandType(int id);

        Task<int> AddBrandAsync(BrandBindingModel model);

        Task<int> EditBrandAsync(EditBrandBindingModel model);

        Task<bool> DeleteBrandAsync(int id);

        Task<int> AddBrandTypeAsync(BrandTypeBindingModel model);
    }
}
