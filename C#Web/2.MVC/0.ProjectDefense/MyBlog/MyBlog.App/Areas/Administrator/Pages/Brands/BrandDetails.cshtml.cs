namespace MyBlog.App.Areas.Administrator.Pages.Brands
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.ViewModels.Brands;
    using MyBlog.Services.Interfaces;

    public class BrandDetailsModel : BasePageModel
    {
        public BrandDetailsViewModel BrandDetailsViewModel { get; private set; }
        private readonly IBrandService brandService;

        public int BrandId { get; set; }

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

            return this.Page();
        }
    }
}