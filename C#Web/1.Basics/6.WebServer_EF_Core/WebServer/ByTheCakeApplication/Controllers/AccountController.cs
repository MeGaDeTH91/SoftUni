namespace HTTPServer.ByTheCakeApplication.Controllers
{
    using Infrastructure;
    using Models;
    using Server.Http;
    using Server.Http.Contracts;
    using Server.Http.Response;
    using ByTheCake.Models;
    using ByTheCake.Data;
    using System.Linq;
    using HTTPServer.ByTheCakeApplication.Utilities;
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class AccountController : Controller
    {
        public IHttpResponse Login()
        {
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            return this.FileViewResponse(@"account\login");
        }

        public IHttpResponse Login(IHttpRequest req)
        {
            const string formNameKey = "username";
            const string formPasswordKey = "password";

            if (!req.FormData.ContainsKey(formNameKey)
                || !req.FormData.ContainsKey(formPasswordKey))
            {
                this.ViewData["error"] = "You have empty fields";
                this.ViewData["showError"] = "block";
                this.ViewData["authDisplay"] = "none";

                return this.FileViewResponse(@"account\login");
            }

            var userName = req.FormData[formNameKey];
            var password = req.FormData[formPasswordKey];

            if (string.IsNullOrWhiteSpace(userName)
                || string.IsNullOrWhiteSpace(password))
            {
                this.ViewData["error"] = "You have empty fields";
                this.ViewData["showError"] = "block";
                this.ViewData["authDisplay"] = "none";

                return this.FileViewResponse(@"account\login");
            }

            User userToLog = default(User);

            using (ByTheCakeContext context = new ByTheCakeContext())
            {
                userToLog = context.Users.FirstOrDefault(x => x.Username == userName);
            }

            bool userExists = ValidateUserExistence(userToLog);
            if (!userExists)
            {
                this.ViewData["error"] = "Invalid credentials.";
                this.ViewData["showError"] = "block";
                this.ViewData["authDisplay"] = "none";

                return new RedirectResponse("/register");
            }

            string hashedPassword = PasswordUtilities.GenerateHash(password);

            bool passwordIsCorrect = userToLog.PasswordHash.Equals(hashedPassword);
            if (!passwordIsCorrect)
            {
                this.ViewData["error"] = "Invalid credentials.";
                this.ViewData["showError"] = "block";
                this.ViewData["authDisplay"] = "none";

                return this.FileViewResponse(@"account\login");
            }

            req.Session.Add(SessionStore.CurrentUserKey, userToLog.Id);
            req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());

            return new RedirectResponse("/");
        }        

        public IHttpResponse Register()
        {
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            return this.FileViewResponse(@"account\register");
        }

        public IHttpResponse Register(IHttpRequest req)
        {
            const string formNameKey = "name";
            const string formUsernameKey = "username";
            const string formPasswordKey = "password";
            const string formConfirmPasswordKey = "confirmpassword";

            if (!req.FormData.ContainsKey(formNameKey) || 
                !req.FormData.ContainsKey(formPasswordKey) ||
                !req.FormData.ContainsKey(formConfirmPasswordKey) ||
                !req.FormData.ContainsKey(formUsernameKey))
            {
                return new BadRequestResponse();
            }

            var name = req.FormData[formNameKey];
            var username = req.FormData[formUsernameKey];
            var password = req.FormData[formPasswordKey];
            var confirmPassword = req.FormData[formConfirmPasswordKey];

            if (string.IsNullOrWhiteSpace(name) || 
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) ||
                string.IsNullOrWhiteSpace(username))
            {
                this.ViewData["error"] = "You have empty fields";
                this.ViewData["showError"] = "block";
                this.ViewData["authDisplay"] = "none";

                return this.FileViewResponse(@"account\register");
            }

            int userId = 0;

            using (ByTheCakeContext context = new ByTheCakeContext())
            {
                bool userExists = context.Users.Any(x => x.Username == username);
                if (userExists)
                {
                    this.ViewData["error"] = "The username is taken.";
                    this.ViewData["showError"] = "block";
                    this.ViewData["authDisplay"] = "none";

                    return this.FileViewResponse(@"account\register");
                }

                bool passwordsMatch = password.Equals(confirmPassword);
                if (!passwordsMatch)
                {
                    this.ViewData["error"] = "Password do not match.";
                    this.ViewData["showError"] = "block";
                    this.ViewData["authDisplay"] = "none";

                    return this.FileViewResponse(@"account\register");
                }

                User userToRegister = new User()
                {
                    Name = name,
                    Username = username,
                    PasswordHash = PasswordUtilities.GenerateHash(password),
                    RegistrationDate = DateTime.Now
                };

                context.Users.Add(userToRegister);
                context.SaveChanges();

                userId = userToRegister.Id;
            }

            req.Session.Add(SessionStore.CurrentUserKey, userId);
            req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());

            return new RedirectResponse("/");
        }

        public IHttpResponse Orders(IHttpRequest req)
        {
            const string tableContentKey = "tableContent";
            var userId = req.Session.Get<int>(SessionStore.CurrentUserKey);
            string tableData = "";
            using (var db = new ByTheCakeContext())
            {
                var orders = db.Orders
                    .Include(x => x.Products)
                    .ThenInclude(x => x.Product)
                    .Where(o => o.UserId == userId)
                    .ToList();
                tableData = string.Join("", orders.Select(o => $"<tr><td><a href=\"/orderDetails/{o.Id}\">{ o.Id}</a></td><td>{ o.CreationDate.ToString("dd-MM-yyyy")}</td><td>${ o.Products.Sum(x => x.Product.Price).ToString("F2")}</td></tr >"));
            }

            if (string.IsNullOrEmpty(tableData))
            {
                this.ViewData["error"] = "<h2>You have no orders</h2>";
                this.ViewData["showResult"] = "none";
                this.ViewData["showError"] = "block";
            }
            else
            {
                this.ViewData[tableContentKey] = tableData;
                this.ViewData["showResult"] = "block";
                this.ViewData["showError"] = "none";
            }

            return this.FileViewResponse(@"account\my-orders");

        }

        public IHttpResponse OrderDetails(IHttpRequest req)
        {
            const string tableContentKey = "tableContent";
            var userId = req.Session.Get<int>(SessionStore.CurrentUserKey);

            var orderId = int.Parse(req.UrlParameters["id"]);

            Order order = default(Order);

            string tableData = "";
            using (var db = new ByTheCakeContext())
            {
                order = db.Orders
                    .Include(x => x.Products)
                    .ThenInclude(x => x.Product)
                    .FirstOrDefault(x => x.Id == orderId);
                
                var orders = db.Orders
                    .Include(x => x.Products)
                    .ThenInclude(x => x.Product)
                    .Where(o => o.UserId == userId)
                    .ToList();
                tableData = string.Join("", order.Products.Select(o => $"<tr><td><a href=\"/cake-details/{ o.ProductId}\">{o.Product.Name}</a></td><td>${ o.Product.Price.ToString("F2")}</td></tr >"));
            }

            if (string.IsNullOrEmpty(tableData))
            {
                this.ViewData["error"] = "<h2>You have no orders</h2>";
                this.ViewData["showResult"] = "none";
                this.ViewData["showError"] = "block";
            }
            else
            {
                this.ViewData["id"] = orderId.ToString();
                this.ViewData[tableContentKey] = tableData;
                this.ViewData["date"] = order.CreationDate.ToString("dd-MM-yyyy");
                this.ViewData["showError"] = "none";
            }

            return this.FileViewResponse(@"account\orderDetails");

        }

        public IHttpResponse Profile(IHttpRequest req)
        {
            int userId = req.Session.Get<int>(SessionStore.CurrentUserKey);

            User profileToView = default(User);

            using (ByTheCakeContext context = new ByTheCakeContext())
            {
                profileToView = context.Users.FirstOrDefault(x => x.Id.Equals(userId));
            }

            if (profileToView == default(User))
            {
                this.ViewData["error"] = "Nice try to hack me.";
                this.ViewData["showError"] = "block";
                this.ViewData["authDisplay"] = "none";

                return this.FileViewResponse(@"account\register");
            }


            this.ViewData["name"] = profileToView.Name;
            this.ViewData["registerDate"] = profileToView.RegistrationDate.ToString(string.Format("MM-dd-yyyy"));
            this.ViewData["ordersCount"] = profileToView.Orders.Count().ToString();

            return this.FileViewResponse(@"account\profile");
        }

        public IHttpResponse Logout(IHttpRequest req)
        {
            req.Session.Clear();

            return new RedirectResponse("/login");
        }

        private bool ValidateUserExistence(User userToLog)
        {
            if (userToLog == default(User))
            {
                return false;
            }
            return true;
        }

        private static void CompleteLogin(IHttpRequest req, int userId)
        {
            req.Session.Add(SessionStore.CurrentUserKey, userId);
            req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());
        }
    }
}
