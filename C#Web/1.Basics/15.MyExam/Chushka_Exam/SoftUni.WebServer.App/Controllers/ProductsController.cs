namespace SoftUni.WebServer.App.Controllers
{
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.Common;
    using SoftUni.WebServer.App.BindingModels;
    using SoftUni.WebServer.Models;
    using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
    using SoftUni.WebServer.Mvc.Interfaces;

    public class ProductsController : BaseController
    {
        private const string InvalidProductCreationMessage = "Please fill product fields correctly!";
        private const string RadioButtonsKey = "radioButtons";
        private const string NonExistingProductMessage = "No such product in database.";
        private const string NameKey = "name";
        private const string PriceKey = "price";
        private const string DescriptionKey = "description";

        private const string DefaultFoodRadioButton = @"<input type=""radio"" id=""food"" name=""ProductType"" value=""Food"" checked> Food";
        private const string IdKey = "id";
        private const string AdminButtonsKey = "adminButtons";
        private const string ProductTypeKey = "type";
        private const string ProductIdKey = "productId";
        private string FoodRadioButton = @"<input type=""radio"" id=""food"" name=""ProductType"" value=""Food""> Food";
        private string DomesticRadioButton = @"<input style=""margin-left: 8%"" id=""domestic"" type=""radio"" name=""ProductType"" value=""Domestic""> Domestic";
        private string HealthRadioButton = @"<input style=""margin-left: 8%"" id=""health"" type=""radio"" name=""ProductType"" value=""Health""> Health";
        private string CosmeticRadioButton = @"<input style=""margin-left: 8%"" id=""cosmetic"" type=""radio"" name=""ProductType"" value=""Cosmetic""> Cosmetic";
        private string OtherRadioButton = @"<input style=""margin-left: 8%"" id=""other"" type=""radio"" name=""ProductType"" value=""Other""> Other";

        private string DisabledFoodRadioButton = @"<input type=""radio"" id=""food"" name=""ProductType"" value=""Food"" checked disabled> Food";
        private string DisabledDomesticRadioButton = @"<input style=""margin-left: 8%"" id=""domestic"" type=""radio"" name=""ProductType"" value=""Domestic"" disabled> Domestic";
        private string DisabledHealthRadioButton = @"<input style=""margin-left: 8%"" id=""health"" type=""radio"" name=""ProductType"" value=""Health"" disabled> Health";
        private string DisabledCosmeticRadioButton = @"<input style=""margin-left: 8%"" id=""cosmetic"" type=""radio"" name=""ProductType"" value=""Cosmetic"" disabled> Cosmetic";
        private string DisabledOtherRadioButton = @"<input style=""margin-left: 8%"" id=""other"" type=""radio"" name=""ProductType"" value=""Other"" disabled> Other";

        [HttpGet]
        public IActionResult Create()
        {
            bool userIsAdmin = this.User.IsAuthenticated && this.User.IsInRole(AdminRoleString);

            if (!userIsAdmin)
            {
                return RedirectToHome;
            }

            this.ViewData[ErrorKey] = string.Empty;

            StringBuilder radioButtons = new StringBuilder();

            radioButtons.AppendLine(DefaultFoodRadioButton);
            radioButtons.AppendLine(DomesticRadioButton);
            radioButtons.AppendLine(HealthRadioButton);
            radioButtons.AppendLine(CosmeticRadioButton);
            radioButtons.AppendLine(OtherRadioButton);

            this.ViewData[RadioButtonsKey] = radioButtons.ToString();
            
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductBindingModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.ViewData[ErrorKey] = InvalidProductCreationMessage;

                return this.View();
            }
            using (this.Context)
            {
                bool validPrice = decimal.TryParse(model.Price, out decimal price) && (price >= ValidationConstants.ProductConstraints.MinPrice && price < ValidationConstants.ProductConstraints.MaxPrice);

                if (!validPrice)
                {
                    this.ViewData[ErrorKey] = InvalidProductCreationMessage;

                    return this.View();
                }

                ProductType productType = this.Context.ProductTypes.FirstOrDefault(x => x.ProductTypeName == model.ProductType);

                Product product = new Product()
                {
                    Name = model.Name,
                    Price = price,
                    Description = model.Description,
                    ProductTypeId = productType.Id,
                    ProductType = productType
                };

                this.Context.Products.Add(product);
                this.Context.SaveChanges();

                return RedirectToHome;
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            bool userIsAdmin = this.User.IsAuthenticated && this.User.IsInRole(AdminRoleString);

            if (!userIsAdmin)
            {
                return RedirectToHome;
            }

            this.ViewData[IdKey] = id.ToString();
            this.ViewData[ErrorKey] = string.Empty;
            
            using (this.Context)
            {
                Product product = this.Context.Products.Include(x => x.ProductType).FirstOrDefault(x => x.Id == id);

                if(product == default(Product))
                {
                    this.ViewData[ErrorKey] = NonExistingProductMessage;
                    this.ViewData[NameKey] = string.Empty;
                    this.ViewData[PriceKey] = string.Empty;
                    this.ViewData[DescriptionKey] = string.Empty;
                    this.ViewData[RadioButtonsKey] = string.Empty;

                    return this.View();
                }
                
                StringBuilder radioButtons = new StringBuilder();
                
                switch (product.ProductType.ProductTypeName)
                {
                    case "Food":
                        FoodRadioButton = @"<input type=""radio"" id=""food"" name=""ProductType"" value=""Food"" checked> Food";
                        break;
                    case "Domestic":
                        DomesticRadioButton = @"<input style=""margin-left: 8%"" id=""domestic"" type=""radio"" name=""ProductType"" value=""Domestic"" checked> Domestic";
                        break;
                    case "Health":
                        HealthRadioButton = @"<input style=""margin-left: 8%"" id=""health"" type=""radio"" name=""ProductType"" value=""Health"" checked> Health";
                        break;
                    case "Cosmetic":
                        CosmeticRadioButton = @"<input style=""margin-left: 8%"" id=""cosmetic"" type=""radio"" name=""ProductType"" value=""Cosmetic"" checked> Cosmetic";
                        break;
                    case "Other":
                        OtherRadioButton = @"<input style=""margin-left: 8%"" id=""other"" type=""radio"" name=""ProductType"" value=""Other"" checked> Other";
                        break;
                    default:
                        break;
                }

                radioButtons.AppendLine(FoodRadioButton);
                radioButtons.AppendLine(DomesticRadioButton);
                radioButtons.AppendLine(HealthRadioButton);
                radioButtons.AppendLine(CosmeticRadioButton);
                radioButtons.AppendLine(OtherRadioButton);

                this.ViewData[NameKey] = product.Name;
                this.ViewData[PriceKey] = product.Price.ToString("F2");
                this.ViewData[DescriptionKey] = product.Description;

                this.ViewData[RadioButtonsKey] = radioButtons.ToString();

                return this.View();
            }
            
        }

        [HttpPost]
        public IActionResult Edit(EditProductBindingModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.ViewData[ErrorKey] = InvalidProductCreationMessage;

                return this.View();
            }

            int id = model.Id;

            using (this.Context)
            {
                Product product = this.Context.Products.Include(x => x.ProductType).FirstOrDefault(x => x.Id == id);

                if (product == default(Product))
                {
                    this.ViewData[ErrorKey] = NonExistingProductMessage;
                    this.ViewData[NameKey] = string.Empty;
                    this.ViewData[PriceKey] = string.Empty;
                    this.ViewData[DescriptionKey] = string.Empty;
                    this.ViewData[RadioButtonsKey] = string.Empty;

                    return this.View();
                }

                product.Name = model.Name;
                product.Description = model.Description;

                ProductType productType = this.Context.ProductTypes.FirstOrDefault(x => x.ProductTypeName == model.ProductType);

                product.ProductType = productType;
                product.ProductTypeId = productType.Id;
                decimal price = 0;

                bool validPrice = decimal.TryParse(model.Price, out price);

                product.Price = price;
                
                this.Context.SaveChanges();

                return RedirectToHome;
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            bool userIsAdmin = this.User.IsAuthenticated && this.User.IsInRole(AdminRoleString);

            if (!userIsAdmin)
            {
                return RedirectToHome;
            }

            this.ViewData[ErrorKey] = string.Empty;

            using (this.Context)
            {
                Product product = this.Context.Products.Include(x => x.ProductType).FirstOrDefault(x => x.Id == id);

                if (product == default(Product))
                {
                    this.ViewData[ErrorKey] = NonExistingProductMessage;
                    this.ViewData[NameKey] = string.Empty;
                    this.ViewData[PriceKey] = string.Empty;
                    this.ViewData[DescriptionKey] = string.Empty;
                    this.ViewData[RadioButtonsKey] = string.Empty;
                    

                    return this.View();
                }

                this.ViewData[NameKey] = product.Name;
                this.ViewData[PriceKey] = product.Price.ToString("F2");
                this.ViewData[DescriptionKey] = product.Description;
                this.ViewData[IdKey] = id.ToString();

                StringBuilder radioButtons = new StringBuilder();
                
                radioButtons.AppendLine(DisabledFoodRadioButton);
                radioButtons.AppendLine(DisabledDomesticRadioButton);
                radioButtons.AppendLine(DisabledHealthRadioButton);
                radioButtons.AppendLine(DisabledCosmeticRadioButton);
                radioButtons.AppendLine(DisabledOtherRadioButton);

                this.ViewData[RadioButtonsKey] = radioButtons.ToString();

                return this.View();
            }
        }

        [HttpPost]
        public IActionResult Delete(DeleteProductBindingModel model)
        {
            int id = model.Id;

            using (this.Context)
            {
                Product product = this.Context.Products.Include(x => x.ProductType).FirstOrDefault(x => x.Id == id);
                
                this.Context.Products.Remove(product);
                this.Context.SaveChanges();

                return RedirectToHome;
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin;
            }

            bool userIsAdmin = this.User.IsInRole(AdminRoleString);

            Product product = default(Product);

            using (this.Context)
            {
                product = this.Context.Products.Include(x => x.ProductType).FirstOrDefault(x => x.Id == id);
            }

            if(product == default(Product))
            {
                return RedirectToHome;
            }

            this.ViewData[NameKey] = product.Name;
            this.ViewData[PriceKey] = product.Price.ToString("F2");
            this.ViewData[ProductTypeKey] = product.ProductType.ProductTypeName;
            this.ViewData[DescriptionKey] = product.Description;
            this.ViewData[ProductIdKey] = product.Id.ToString();

            if (userIsAdmin)
            {
                StringBuilder adminButtons = new StringBuilder();

                adminButtons.AppendLine($@"<a style=""margin-left: 8%"" class="" btn chushka-bg-color"" href=""/products/edit?id={product.Id}"">Edit</a>");

                adminButtons.AppendLine($@"<a style=""margin-left: 8%"" class="" btn chushka-bg-color"" href=""/products/delete?id={product.Id}"">Delete</a>");

                this.ViewData[AdminButtonsKey] = adminButtons.ToString();
            }
            else
            {
                this.ViewData[AdminButtonsKey] = string.Empty;
            }
            
            return this.View();
        }
    }
}
