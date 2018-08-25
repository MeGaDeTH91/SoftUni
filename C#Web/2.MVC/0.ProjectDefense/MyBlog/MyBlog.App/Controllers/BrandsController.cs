namespace MyBlog.App.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.BindingModels.Brands;
    using MyBlog.CommonModels.ViewModels.Brands;
    using MyBlog.Models.Users;
    using MyBlog.Services.Interfaces;

    public class BrandsController : BaseUserController
    {
        private readonly IBrandService brandService;

        public BrandsController(UserManager<User> userManager, IBrandService brandService) : base(userManager)
        {
            this.brandService = brandService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var brands = this.brandService.GetAllBrands();

            return this.View(brands);
        }

        [HttpGet]
        public IActionResult AddToFavourites(int id)
        {
            var loggerUser = this.User;
            var dbUser = this.userManager.GetUserAsync(loggerUser);

            var addedToFavourites = this.brandService.AddToFavourites(dbUser.Result.Id, id);

            if (addedToFavourites == false)
            {
                SetErrorMessage(CommonConstants.AlreadyInFavouritesOrInvalidErrorMessage);

                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.BrandsSuffix);
            }

            SetSuccessMessage(CommonConstants.AddedToFavouritesSuccessfullyMessage);

            return Redirect(string.Format(RedirectConstants.BrandDetailsPage, id));
        }

        [HttpGet]
        public IActionResult BrandTypeDetails(int id)
        {
            var brandType = this.brandService.GetBrandType(id);

            if (brandType == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.BrandsSuffix);
            }

            return this.View(brandType);
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