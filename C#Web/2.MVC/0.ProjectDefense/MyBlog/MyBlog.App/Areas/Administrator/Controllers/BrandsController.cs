namespace MyBlog.App.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.BindingModels.Brands;
    using MyBlog.CommonModels.ViewModels.Brands;
    using MyBlog.Services.Interfaces;

    public class BrandsController : AdminController
    {
        private readonly IBrandService brandService;

        public BrandsController(IBrandService brandService)
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
        public IActionResult AddBrand()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand(BrandBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.AddBrand();
            }

            int generatedId = await this.brandService.AddBrandAsync(model);

            if (generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.AddBrand();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.BrandSuffix));

            return Redirect(string.Format(RedirectConstants.AdministratorAreaBrandDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult EditBrand(int id)
        {
            BrandDetailsViewModel brand = this.brandService.GetBrand(id);

            if (brand == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(brand);
        }

        [HttpPost]
        public async Task<IActionResult> EditBrand(EditBrandBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.EditBrand(model.Id);
            }

            int generatedId = await this.brandService.EditBrandAsync(model);

            if (generatedId < 1)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return Redirect(string.Format(RedirectConstants.AdministratorAreaBrandDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult DeleteBrand(int id)
        {
            BrandDetailsViewModel brand = this.brandService.GetBrand(id);

            if (brand == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(brand);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBrand(BrandBindingModel model)
        {
            bool isDeleted = await this.brandService.DeleteBrandAsync(model.Id);

            return RedirectToAction(RedirectConstants.IndexSuffix);
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

        [HttpGet]
        public IActionResult AddBrandType()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBrandType(BrandTypeBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.View();
            }

            int generatedId = await this.brandService.AddBrandTypeAsync(model);

            if (generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.View();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.BrandTypeDisplay));

            return RedirectToAction(RedirectConstants.BrandTypeBrandsSuffix, RedirectConstants.BrandsSuffix, generatedId);
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