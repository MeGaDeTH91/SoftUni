namespace MyBlog.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyBlog.CommonModels.BindingModels.Brands;
    using MyBlog.CommonModels.ViewModels.Brands;
    using MyBlog.Data;
    using MyBlog.Models.Brands;
    using MyBlog.Models.Users;
    using MyBlog.Services.Interfaces;

    public class BrandService : BaseBlogService, IBrandService
    {
        public BrandService(BlogDataDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public bool AddToFavourites(string userId, int brandId)
        {
            var user = this.DbContext
                .Users
                .FirstOrDefault(x => x.Id == userId);

            var brand = this.DbContext
                .Brands
                .FirstOrDefault(x => x.Id == brandId);

            if (user == null || brand == null)
            {
                return false;
            }

            var userBrand = new UserBrands()
            {
                UserId = userId,
                BrandId = brandId,
                AddedToFavouritesOn = DateTime.UtcNow
            };

            bool alreadyInFavourites = this.DbContext.FavouriteUserBrands
                .Any(x => x.UserId == userId && x.BrandId == brandId);

            if (alreadyInFavourites)
            {
                return false;
            }

            user.FavouriteBrands.Add(userBrand);
            this.DbContext.SaveChanges();

            return true;
        }

        public async Task<int> AddBrandAsync(BrandBindingModel model)
        {
            var checkForDuplicate = this.DbContext
                .Brands
                .FirstOrDefault(x => x.BrandName == model.BrandName);

            if (checkForDuplicate != null)
            {
                return ErrorId;
            }

            var brand = this.Mapper.Map<Brand>(model);

            var brandType = this.DbContext
                .BrandTypes
                .FirstOrDefault(x => x.TypeName == model.BrandTypeStr);

            if (brandType == null)
            {
                brandType = new BrandType()
                {
                    TypeName = model.BrandTypeStr
                };

                await this.DbContext.BrandTypes.AddAsync(brandType);
                await this.DbContext.SaveChangesAsync();
            }

            brand.BrandTypeId = brandType.Id;
            brand.BrandType = brandType;

            await this.DbContext.Brands.AddAsync(brand);
            await this.DbContext.SaveChangesAsync();

            return brand.Id;
        }

        public async Task<int> AddBrandTypeAsync(BrandTypeBindingModel model)
        {
            var existingType = this.DbContext
                .BrandTypes
                .FirstOrDefault(x => x.TypeName == model.TypeName);

            if (existingType != null)
            {
                return ErrorId;
            }

            var type = this.Mapper.Map<BrandType>(model);

            await this.DbContext.BrandTypes.AddAsync(type);
            await this.DbContext.SaveChangesAsync();

            return type.Id;
        }
        
        public async Task<bool> DeleteBrandAsync(int id)
        {
            var brand = this.DbContext
                .Brands
                .FirstOrDefault(x => x.Id == id);

            if (brand == null)
            {
                return false;
            }

            this.DbContext.Brands.Remove(brand);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<int> EditBrandAsync(EditBrandBindingModel model)
        {
            var brand = this.DbContext
                .Brands
                .FirstOrDefault(x => x.Id == model.Id);

            if (brand == null)
            {
                return ErrorId;
            }

            brand.BrandDescription = model.BrandDescription;
            brand.BrandImageURL = model.BrandImageURL;
            brand.AdditionalInfoURL = model.AdditionalInfoURL;

            await this.DbContext.SaveChangesAsync();

            return brand.Id;
        }

        public ICollection<BrandConciseViewModel> GetAllBrands()
        {
            var brands = this.DbContext
                .Brands
                .Select(this.Mapper.Map<BrandConciseViewModel>)
                .ToList();

            return brands;
        }

        public BrandDetailsViewModel GetBrand(int id)
        {
            var actualBrand = this.DbContext
                .Brands
                .Include(x => x.BrandType)
                .Include(x => x.AddedToFavoritesBy)
                .FirstOrDefault(x => x.Id == id);

            if (actualBrand == null)
            {
                return null;
            }

            var brand = this.Mapper.Map<BrandDetailsViewModel>(actualBrand);

            return brand;
        }

        public BrandTypeViewModel GetBrandType(int id)
        {
            var brandType = this.DbContext
                .BrandTypes
                .Include(x => x.Brands)
                .FirstOrDefault(x => x.Id == id);

            if (brandType == null)
            {
                return null;
            }

            var brandTypeModel = new BrandTypeViewModel()
            {
                BrandTypeName = brandType.TypeName,
                Brands = this.Mapper.Map<ICollection<BrandConciseViewModel>>(brandType.Brands)
            };

            return brandTypeModel;
        }
    }
}
