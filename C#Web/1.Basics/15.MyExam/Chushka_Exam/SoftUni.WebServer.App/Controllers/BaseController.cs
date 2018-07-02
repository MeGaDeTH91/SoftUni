namespace SoftUni.WebServer.App.Controllers
{
    using SoftUni.WebServer.Data;
    using SoftUni.WebServer.Mvc.Controllers;
    using SoftUni.WebServer.Mvc.Interfaces;
    using System;
    using System.Text;

    public class BaseController : Controller
    {
        protected const string ErrorKey = "error";
        protected const string UserRoleString = "User";
        protected const string AdminRoleString = "Admin";
        private const string NavbarKey = "navbar";
        protected const string IndexContentKey = "indexContent";
        protected const string LoginRoute = "/users/login";
        protected const string HomeRoute = "/home/index";

        public BaseController()
        {
            this.Context = new ChushkaDbContext();
        }

        protected ChushkaDbContext Context { get; set; }

        protected IActionResult RedirectToLogin => this.RedirectToAction(LoginRoute);
        protected IActionResult RedirectToHome => this.RedirectToAction(HomeRoute);

        public override void OnAuthentication()
        {
            StringBuilder navbar = new StringBuilder();

            if (!this.User.IsAuthenticated)
            {
                navbar.AppendLine(@"<ul class=""navbar-nav"">
                        <li class="" nav-item"">
                            <a class="" nav-link nav-link-white"" href=""/"">Home</a>
                        </li>
                        <li class="" nav-item"">
                            <a class="" nav-link nav-link-white"" href=""/users/login"">Login</a>
                        </li>
                        <li class="" nav-item"">
                            <a class="" nav-link nav-link-white"" href=""/users/register"">Register</a>
                        </li>
                    </ul>");
            }
            else if(this.User.IsInRole(UserRoleString))
            {
                navbar.AppendLine(@"<ul class=""navbar-nav right-side"">
                        <li class="" nav-item"">
                            <a class="" nav-link nav-link-white"" href=""/"">Home</a>
                        </li>
                    </ul>
                    <ul class=""navbar-nav left-side"">
                        <li class=""nav-item"">
                            <a class=""nav-link nav-link-white"" href=""/users/logout"">Logout</a>
                        </li>
                    </ul>");
            }
            else if (this.User.IsInRole(AdminRoleString))
            {
                navbar.AppendLine(@"
                    <ul class=""navbar-nav"">
                        <li class="" nav-item"">
                            <a class="" nav-link nav-link-white"" href=""/"">Home</a>
                        </li>
                    
                        <li class="" nav-item"">
                            <a class="" nav-link nav-link-white"" href=""/products/create"">Create Product</a>
                        </li>
                        <li class="" nav-item"">
                            <a class="" nav-link nav-link-white"" href=""/orders/all"">All Orders</a>
                        </li>
                    </ul>
                    <ul class=""navbar-nav left-side"">
                        <li class=""nav-item"">
                            <a class=""nav-link nav-link-white"" href=""/users/logout"">Logout</a>
                        </li>
                    </ul>");
            }

            this.ViewData[NavbarKey] = navbar.ToString();
        }
    }
}
