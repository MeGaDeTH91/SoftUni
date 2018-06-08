namespace HTTPServer.ByTheCakeApplication.Controllers
{
    using ByTheCake.Data;
    using ByTheCake.Models;
    using Data;
    using HTTPServer.Server.Http;
    using Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Server.Http.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CakesController : Controller
    {
        private readonly CakesData cakesData;

        public CakesController()
        {
            this.cakesData = new CakesData();
        }

        public IHttpResponse Add()
        {
            this.ViewData["showResult"] = "none";
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            return this.FileViewResponse(@"cakes\add");
        }

        public IHttpResponse Add(IHttpRequest req)
        {
            if (!req.FormData.ContainsKey("name") ||
                !req.FormData.ContainsKey("price"))
            {
                this.ViewData["showResult"] = "none";
                this.ViewData["error"] = "Cakes are supposed to have name and price.";
                this.ViewData["showError"] = "block";

                return this.FileViewResponse(@"cakes\add");
            }

            string name = req.FormData["name"];
            decimal price = decimal.Parse(req.FormData["price"]);
            string path = string.Empty;

            using(var db = new ByTheCakeContext())
            {
                Product cakeNameCheck = db.Products.FirstOrDefault(x => x.Name.Equals(name));

                if(cakeNameCheck != default(Product))
                {
                    this.ViewData["showResult"] = "none";
                    this.ViewData["error"] = "Cakes must be unique.";
                    this.ViewData["showError"] = "block";

                    return this.FileViewResponse(@"cakes\add");
                }
            }

            if (req.FormData.ContainsKey("path"))
            {
                path = req.FormData["path"];
            }

            var cake = new Product
            {
                Name = name,
                Price = price
            };
            if(path != string.Empty)
            {
                cake.ImageURL = path;
            }
            
            using(var db = new ByTheCakeContext())
            {
                db.Products.Add(cake);
                db.SaveChanges();
            };

            this.ViewData["showResult"] = "block";
            this.ViewData["name"] = name;
            this.ViewData["price"] = price.ToString("F2");            
            this.ViewData["authDisplay"] = "none";
            this.ViewData["showError"] = "none";


            return this.FileViewResponse(@"cakes\add");
        }

        public IHttpResponse CakeDetails(IHttpRequest req)
        {
            var id = int.Parse(req.UrlParameters["id"]);

            Product productToView = default(Product);

            using (ByTheCakeContext context = new ByTheCakeContext())
            {
                productToView = context.Products.FirstOrDefault(x => x.Id ==(id));
            }

            if (productToView == default(Product))
            {
                this.ViewData["error"] = "No such product.";
                this.ViewData["showError"] = "block";
                this.ViewData["authDisplay"] = "none";

                return this.FileViewResponse(@"cakes\search");
            }


            this.ViewData["name"] = productToView.Name;
            this.ViewData["price"] = productToView.Price.ToString("F2");
            this.ViewData["imageUrl"] = productToView.ImageURL;

            return this.FileViewResponse(@"/cakes/cake-details");
        }

        public IHttpResponse Search(IHttpRequest req)
        {
            int userId = req.Session.Get<int>(SessionStore.CurrentUserKey);

            IEnumerable<Order> orders = null;

            using(var db = new ByTheCakeContext())
            {
                orders = db.Orders.Where(x => x.UserId == userId).Include(x => x.Products)
                    .ThenInclude(x => x.Product).ToList();
            }

            const string searchTermKey = "searchTerm";

            var urlParameters = req.UrlParameters;

            this.ViewData["results"] = string.Empty;
            this.ViewData["searchTerm"] = string.Empty;

            if (urlParameters.ContainsKey(searchTermKey))
            {
                var searchTerm = urlParameters[searchTermKey];

                this.ViewData["searchTerm"] = searchTerm;

                var savedCakesDivs = new List<string>();

                using (var db = new ByTheCakeContext())
                {
                    if (searchTerm != "*")
                    {
                        var lowerSearchTerm = searchTerm.ToLower();
                        savedCakesDivs = db.Products.Where(cake => cake.Name.ToLower().Contains(lowerSearchTerm))
                        .Select(c =>
                        $@"<div>
                        <a href=""/cake-details/{c.Id}"" target=""_blank"">{c.Name}</a> - ${c.Price:F2} 
                        <a href=""/shopping/add/{c.Id}?searchTerm={searchTerm}"">Order</a>
                    </div>")
                        .ToList();
                    }
                    else
                    {
                        savedCakesDivs = db.Products
                            .Select(c =>
                            $@"<div>
                        <a href=""/cake-details/{c.Id}"" target=""_blank"">{c.Name}</a> - ${c.Price:F2} 
                        <a href=""/shopping/add/{c.Id}?searchTerm={searchTerm}"">Order</a>
                    </div>")
                            .ToList();
                    }
                }
                
                var results = "No cakes found";

                if (savedCakesDivs.Any())
                {
                    results = string.Join(Environment.NewLine, savedCakesDivs);
                }

                this.ViewData["results"] = results;
            }
            else
            {
                this.ViewData["results"] = "Please, enter search term";
            }

            this.ViewData["showCart"] = "none";

            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (shoppingCart.Orders.Any())
            {
                var totalProducts = shoppingCart.Orders.Count;
                var totalProductsText = totalProducts != 1 ? "products" : "product";

                this.ViewData["showCart"] = "block";
                this.ViewData["products"] = $"{totalProducts} {totalProductsText}";
            }

            return this.FileViewResponse(@"cakes\search");
        }
    }
}
