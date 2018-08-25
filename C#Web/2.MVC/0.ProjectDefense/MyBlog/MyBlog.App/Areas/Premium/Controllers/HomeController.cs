namespace MyBlog.App.Areas.Premium.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.Services.PremiumServices.Interfaces;

    public class HomeController : PremiumController
    {
        private readonly IPremiumProductService premiumProductService;

        public HomeController(IPremiumProductService premiumProductService)
        {
            this.premiumProductService = premiumProductService;
        }

        [HttpGet]
        public IActionResult PremiumIndex()
        {
            var offers = this.premiumProductService.GetAllPremiumProducts();

            return View(offers);
        }

        [HttpGet]
        public IActionResult ProductDetails(int id)
        {
            var product = this.premiumProductService.GetPremiumProduct(id);

            if (product == null)
            {
                SetErrorMessage(CommonConstants.NotFoundMessage);

                return RedirectToAction(RedirectConstants.PremiumIndex, RedirectConstants.HomeControllexSuffix);
            }

            return this.View(product);
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            var product = this.premiumProductService.GetPremiumProduct(id);

            if(product == null)
            {
                SetErrorMessage(CommonConstants.NotFoundMessage);
            }

            return RedirectToAction(RedirectConstants.PremiumIndex, RedirectConstants.HomeControllexSuffix);
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