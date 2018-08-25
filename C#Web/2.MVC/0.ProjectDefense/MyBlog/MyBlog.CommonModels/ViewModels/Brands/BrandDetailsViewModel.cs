namespace MyBlog.CommonModels.ViewModels.Brands
{
    using System.Collections.Generic;
    using MyBlog.CommonModels.ViewModels.Games;
    using MyBlog.CommonModels.ViewModels.Music.Instruments;
    using MyBlog.CommonModels.ViewModels.Products;
    using MyBlog.Models.Brands;
    using MyBlog.Models.Users;

    public class BrandDetailsViewModel
    {
        public string BrandName { get; set; }
        
        public string BrandDescription { get; set; }
        
        public string BrandImageURL { get; set; }
        
        public string AdditionalInfoURL { get; set; }
        
        public int BrandTypeId { get; set; }
        public BrandType BrandType { get; set; }

        public ICollection<InstrumentConciseViewModel> Instruments { get; set; }

        public ICollection<GameConciseViewModel> Games { get; set; }

        public ICollection<ProductConciseViewModel> Products { get; set; }

        public ICollection<UserBrands> AddedToFavoritesBy { get; set; }
    }
}
