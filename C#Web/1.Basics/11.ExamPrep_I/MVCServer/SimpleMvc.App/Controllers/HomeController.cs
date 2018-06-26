namespace SimpleMvc.App.Controllers
{
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;
    using System.Text;

    public class HomeController : BaseController
    {
        private const string IndexContentKey = "indexContent";
        private const string LoginSuccessMessage = "Successfully logged in!";

        [HttpGet]
        public IActionResult Index()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($@"<div class=""jumbotron"">");
            this.Model.Data[ErrorKey] = HideMessageValue;

            if (this.User.IsAuthenticated)
            {
                result.AppendLine($@"<h1>Welcome, {User.Name}</h1>");
                result.AppendLine($@"<hr class=""my-2"">");
                result.AppendLine($@"<p>Fluffy Duffy Munchkin Cats wishes you a cute and awesome experience.</p>");
            }
            else
            {
                result.AppendLine($@"<h1>Welcome to Fluffy Duffy Munchkin Cats</h1>");
                result.AppendLine($@"<p>The simplest, cutest, most reliable website for trading cats.</p>");
                result.AppendLine($@"<hr class=""my-2"">");
                result.AppendLine($@"<p><a href=""/users/login"">Login</a> to trade or <a href=""/users/register"">Register</a> if you don't have an account.</p>");
            }

            result.AppendLine($@"</div>");
            
            this.Model.Data[IndexContentKey] = result.ToString();
            return View();
        }
    }
}
