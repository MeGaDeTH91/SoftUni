namespace SimpleMvc.App.Controllers
{
    using SimpleMvc.Data;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;
    using System;
    using System.Text;

    public class BaseController : Controller
    {
        protected const string NavbarKey = "navbar";
        protected const string HomeRoute = "/home/index";
        protected const string LoginRoute = "/users/login";
        protected const string ErrorKey = "error";
        protected const string InvalidRegisterDetails = "Please fill all fields correctly.";
        protected const string InvalidRegisterEmailExists = "User with such email already registered!";
        protected const string InvalidRegisterUsernameExists = "User with such username already registered!";
        protected const string InvalidLoginDetails = "Invalid credentials!";
        protected const string UnauthorizedErrorMessage = "You are not authorized to view this content.";
        protected const string LogoutErrorMessage = "You must login before you attempt to logout.";

        public BaseController()
        {
            this.Context = new MeTubeDbContext();
        }
        
        protected override void InitializeAuthorization()
        {
            StringBuilder result = new StringBuilder();
            
            if (this.SessionUser.IsAuthenticated)
            {
                result.AppendLine(@"<li class=""nav-item active col-md-3"">
                        <a class=""nav-link h5"" href=""/home/index"">Home</a>
                    </li>");

                result.AppendLine(@"<li class=""nav-item active col-md-3"">
                        <a class=""nav-link h5"" href=""/users/profile"">Profile</a>
                    </li>");

                result.AppendLine(@"<li class=""nav-item active col-md-3"">
                        <a class=""nav-link h5"" href=""/tubes/upload"">Upload</a>
                    </li>");

                result.AppendLine(@"<li class=""nav-item active col-md-3"">
                        <a class=""nav-link h5"" href=""/users/logout"">Logout</a>
                    </li>");
            }
            else
            {
                result.AppendLine(@"<li class=""nav-item active col-md-4"">
                        <a class=""nav-link h5"" href=""/home/index"">Home</a>
                    </li>");

                result.AppendLine(@"<li class=""nav-item active col-md-4"">
                        <a class=""nav-link h5"" href=""/users/login"">Login</a>
                    </li>");

                result.AppendLine(@"<li class=""nav-item active col-md-4"">
                        <a class=""nav-link h5"" href=""/users/register"">Register</a>
                    </li>");
            }

            this.Model.Data[NavbarKey] = result.ToString();
        }

        public MeTubeDbContext Context { get; set; }

        protected IActionResult RedirectToHome() => this.RedirectToAction(HomeRoute);

        protected IActionResult RedirectToLogin() => this.RedirectToAction(LoginRoute);
    }
}
