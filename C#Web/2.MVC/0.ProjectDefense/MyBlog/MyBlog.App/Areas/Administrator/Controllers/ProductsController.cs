namespace MyBlog.App.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.BindingModels.Products;
    using MyBlog.CommonModels.ViewModels.Products;
    using MyBlog.Services.Interfaces;

    public class ProductsController : AdminController
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
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
        public IActionResult AddProduct()
        {
            var model = this.productService.GetAllBrandsAndProductTypes();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.AddProduct();
            }

            int generatedId = await this.productService.AddProductAsync(model);

            if (generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.AddProduct();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.ProductSuffix));

            return Redirect(string.Format(RedirectConstants.AdministratorAreaProductDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            ProductDetailsViewModel product = this.productService.GetProduct(id);

            if (product == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(product);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(EditProductBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.EditProduct(model.Id);
            }

            int generatedId = await this.productService.EditProductAsync(model);

            if (generatedId < 1)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return Redirect(string.Format(RedirectConstants.AdministratorAreaProductDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            ProductDetailsViewModel product = this.productService.GetProduct(id);

            if (product == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(product);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(EditProductBindingModel model)
        {
            bool isDeleted = await this.productService.DeleteProductAsync(model.Id);

            return RedirectToAction(RedirectConstants.IndexSuffix);
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
        public IActionResult AddProductType()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProductType(AddProductTypeBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.AddProductType();
            }

            int generatedId = await this.productService.AddProductTypeAsync(model);

            if (generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.AddProductType();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.ProductTypeDisplay));

            return RedirectToAction(RedirectConstants.ProductTypeDetailsSuffix, RedirectConstants.ProductsSuffix, generatedId);
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