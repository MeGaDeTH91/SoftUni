namespace MyBlog.App.Areas.Administrator.Pages.Products
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.ViewModels.Products;
    using MyBlog.Services.Interfaces;

    public class ProductDetailsModel : BasePageModel
    {
        public ProductDetailsViewModel ProductDetailsViewModel { get; private set; }
        private readonly IProductService productService;

        public int ProductId { get; set; }

        public ProductDetailsModel(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult OnGet(int id)
        {
            var product = this.productService.GetProduct(id);

            if (product == null)
            {
                this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
                {
                    Type = MessageType.Danger,
                    Message = CommonConstants.NotFoundMessage
                });
            }

            this.ProductId = id;

            this.ProductDetailsViewModel = product;

            return this.Page();
        }
    }
}