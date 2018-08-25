namespace MyBlog.App.Pages.Brands
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.ViewModels.Brands;
    using MyBlog.Services.Interfaces;

    public class BrandDetailsModel : BaseUserPageModel
    {
        public BrandDetailsViewModel BrandDetailsViewModel { get; private set; }
        private readonly IBrandService brandService;

        public int BrandId { get; private set; }
        public int Likes { get; private set; }

        public BrandDetailsModel(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        public IActionResult OnGet(int id)
        {
            var brand = this.brandService.GetBrand(id);

            if (brand == null)
            {
                this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
                {
                    Type = MessageType.Danger,
                    Message = CommonConstants.NotFoundMessage
                });
            }

            this.BrandId = id;

            this.BrandDetailsViewModel = brand;
            this.Likes = this.BrandDetailsViewModel.AddedToFavoritesBy.Count;

            return this.Page();
        }
    }
}