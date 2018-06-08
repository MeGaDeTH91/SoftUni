namespace HTTPServer.ByTheCakeApplication.Controllers
{
    using Data;
    using Models;
    using Infrastructure;
    using Server.Http.Contracts;
    using Server.Http.Response;
    using System.Linq;
    using System;
    using HTTPServer.Server.Http;
    using ByTheCake.Data;
    using System.Collections.Generic;
    using ByTheCake.Models;

    public class ShoppingController : Controller
    {
        private readonly CakesData cakesData;

        public ShoppingController()
        {
            this.cakesData = new CakesData();
        }

        public IHttpResponse AddToCart(IHttpRequest req)
        {
            var id = int.Parse(req.UrlParameters["id"]);

            Product cake = default(Product);

            using (var db = new ByTheCakeContext())
            {
                cake = db.Products.FirstOrDefault(x => x.Id == id);
            }
            
            if (cake == null)
            {
                return new NotFoundResponse();
            }

            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);
            shoppingCart.Orders.Add(cake);

            var redirectUrl = "/search";

            const string searchTermKey = "searchTerm";

            if (req.UrlParameters.ContainsKey(searchTermKey))
            {
                redirectUrl = $"{redirectUrl}?{searchTermKey}={req.UrlParameters[searchTermKey]}";
            }

            return new RedirectResponse(redirectUrl);
        }

        public IHttpResponse ShowCart(IHttpRequest req)
        {
            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (!shoppingCart.Orders.Any())
            {
                this.ViewData["cartItems"] = "No items in your cart";
                this.ViewData["totalCost"] = "0.00";
            }
            else
            {
                var items = shoppingCart
                    .Orders
                    .Select(i => $"<div>{i.Name} - ${i.Price:F2}</div><br />");

                var totalPrice = shoppingCart
                    .Orders
                    .Sum(i => i.Price);
                
                this.ViewData["cartItems"] = string.Join(string.Empty, items);
                this.ViewData["totalCost"] = $"{totalPrice:F2}";
            }

            return this.FileViewResponse(@"shopping\cart");
        }
        
        public IHttpResponse FinishOrder(IHttpRequest req)
        {
            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            int userId = req.Session.Get<int>(SessionStore.CurrentUserKey);
            User user = default(User);

            int orderId = -10;

            HashSet<Product> products = shoppingCart.Orders.ToHashSet();
            HashSet<ProductOrder> mappingTable = new HashSet<ProductOrder>();

            using (var db = new ByTheCakeContext())
            {
                user = db.Users.FirstOrDefault(x => x.Id == userId);

                if (user == default(User))
                {
                    this.ViewData["error"] = "Nice try to hack me.";
                    this.ViewData["showError"] = "block";
                    this.ViewData["authDisplay"] = "none";

                    return this.FileViewResponse(@"account\register");
                }

                DateTime exactTime = DateTime.UtcNow;

                Order order = new Order()
                {
                    UserId = user.Id,
                    User = user,
                    CreationDate = exactTime
                };

                db.Orders.Add(order);
                db.SaveChanges();
                orderId = order.Id;

                foreach (var product in products)
                {
                    int productId = product.Id;
                    Product productDb = db.Products.FirstOrDefault(x => x.Id == productId);

                    ProductOrder productOrder = new ProductOrder()
                    {
                        OrderId = orderId,
                        ProductId = productId
                    };
                    order.Products.Add(productOrder);
                    productDb.Orders.Add(productOrder);
                    db.SaveChanges();
                }
            }
            
            req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey).Orders.Clear();

            return this.FileViewResponse(@"shopping\finish-order");
        }
    }
}
