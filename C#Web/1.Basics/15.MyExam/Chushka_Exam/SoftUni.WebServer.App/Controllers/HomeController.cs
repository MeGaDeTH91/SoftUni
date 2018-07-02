namespace SoftUni.WebServer.App.Controllers
{
    using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
    using SoftUni.WebServer.Mvc.Interfaces;
    using System;
    using System.Linq;
    using System.Text;

    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            StringBuilder indexContent = new StringBuilder();

            if (!this.User.IsAuthenticated)
            {
                indexContent.AppendLine(@"<main>
            <div class=""jumbotron mt-3 chushka-bg-color"">
                <h1>Welcome to Chushka Universal Web Shop</h1>
                <hr class=""bg-white"" />
                <h3><a class="" nav-link-dark"" href=""/users/login"">Login</a> if you have an account.</h3>
                <h3><a class=""nav-link-dark"" href=""/users/register"">Register</a> if you don't.</h3>
            </div>
        </main>");
            }
            else if (this.User.IsInRole(UserRoleString))
            {
                indexContent.AppendLine($@"<main class=""mt-3 mb-5"">
                                    <div class=""container-fluid text-center"">
                                        <h2>Greetings, {this.User.Name}!</h2>
                                        <h4>Feel free to view and order any of our products.</h4>
                                    </div>
                                    <hr class=""hr-2 bg-dark"" />");

                //Products Here
                indexContent.AppendLine($@"<div class=""container-fluid product-holder"">
                            <div class=""row d-flex justify-content-around"">");

                using (this.Context)
                {
                    var products = this.Context.Products.ToList();

                    for (int i = 0; i < products.Count; i++)
                    {
                        int rowNumber = i + 1;

                        var product = products[i];

                        indexContent.AppendLine($@"<a href=""/products/details?id={product.Id}"" class=""col-md-2"">
                    <div class=""product p-1 chushka-bg-color rounded-top rounded-bottom"">
                        <h5 class=""text-center mt-3"">{product.Name}</h5>
                        <hr class=""hr-1 bg-white""/>
                        <p class=""text-white text-center"">
                            {product.Description}
                        </p>
                        <hr class=""hr-1 bg-white""/>
                        <h6 class=""text-center text-white mb-3"">${product.Price.ToString()}</h6>
                    </div>
                </a>");

                        if(rowNumber % 5 == 0)
                        {
                            indexContent.AppendLine($@"</div></div><br/><div class=""container-fluid product-holder"">
                            <div class=""row d-flex justify-content-around"">");
                        }
                    }
                }

                indexContent.AppendLine(@"</div></div>");
                indexContent.AppendLine(@"</main>");
            }
            else if (this.User.IsInRole(AdminRoleString))
            {
                indexContent.AppendLine($@"<main class=""mt-3 mb-5"">
                                    <div class=""container-fluid text-center"">
                                        <h2>Greetings, {this.User.Name}!</h2>
                                        <h4>Enjoy your work today!</h4>
                                    </div>
                                    <hr class=""hr-2 bg-dark"" />");

                indexContent.AppendLine($@"<div class=""container-fluid product-holder"">
                            <div class=""row d-flex justify-content-around"">");

                using (this.Context)
                {
                    var products = this.Context.Products.ToList();

                    for (int i = 0; i < products.Count; i++)
                    {
                        int rowNumber = i + 1;

                        var product = products[i];

                        indexContent.AppendLine($@"<a href=""/products/details?id={product.Id}"" class=""col-md-2"">
                    <div class=""product p-1 chushka-bg-color rounded-top rounded-bottom"">
                        <h5 class=""text-center mt-3"">{product.Name}</h5>
                        <hr class=""hr-1 bg-white""/>
                        <p class=""text-white text-center"">
                            {product.Description}
                        </p>
                        <hr class=""hr-1 bg-white""/>
                        <h6 class=""text-center text-white mb-3"">${product.Price.ToString()}</h6>
                    </div>
                </a>");

                        if (rowNumber % 5 == 0)
                        {
                            indexContent.AppendLine($@"</div></div><br/><div class=""container-          fluid product-holder"">
                            <div class=""row d-flex justify-content-around"">");
                        }
                    }
                }

                indexContent.AppendLine(@"</div></div>");
                indexContent.AppendLine(@"</main>");
            }

            this.ViewData[IndexContentKey] = indexContent.ToString();

            return this.View();
        }
    }
}
