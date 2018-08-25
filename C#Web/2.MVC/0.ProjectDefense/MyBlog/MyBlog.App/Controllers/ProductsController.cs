namespace MyBlog.App.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.Models.Users;
    using MyBlog.Services.Interfaces;

    public class ProductsController : BaseUserController
    {
        private readonly IProductService productService;

        public ProductsController(UserManager<User> userManager, IProductService productService) : base(userManager)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var instruments = this.productService.GetAllProducts();

            return this.View(instruments);
        }

        
        

        [HttpGet]
        public IActionResult ProductTypeDetails(int id)
        {
            var productType = this.productService.GetProductType(id);

            if (productType == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.ProductsSuffix);
            }

            return this.View(productType);
        }

        [HttpGet]
        public IActionResult BuyProduct(int id)
        {
            var loggerUser = this.User;
            var dbUser = this.userManager.GetUserAsync(loggerUser);

            var boughtSuccessfully = this.productService.BuyProduct(dbUser.Result.Id, id);

            if (boughtSuccessfully == false)
            {
                SetErrorMessage(CommonConstants.AlreadyBoughtOrInvalidDataErrorMessage);

                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.ProductsSuffix);
            }

            SetSuccessMessage(CommonConstants.BoughtSuccessfullyMessage);

            return Redirect(string.Format(RedirectConstants.ProductDetailsPage, id));
        }

        private void SetSuccessMessage(string successMessage)
        {
            this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
            {
                Type = MessageType.Success,
                Message = successMessage
            });
        }

        private void SetErrorMessage(string errorMessage)
        {
            this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
            {
                Type = MessageType.Danger,
                Message = errorMessage
            });
        }
    }
}