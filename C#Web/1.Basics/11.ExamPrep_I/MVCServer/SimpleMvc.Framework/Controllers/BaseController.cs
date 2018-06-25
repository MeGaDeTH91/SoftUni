using SimpleMvc.Data;
using SimpleMvc.Framework.Interfaces;
using System;

namespace SimpleMvc.Framework.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            this.Context = new KittenDbContext();
            this.InitializeAuthorization();
        }

        protected KittenDbContext Context { get; set; }

        protected internal override void InitializeAuthorization()
        {
            if (this.User.IsAuthenticated)
            {
                this.Model.Data["userDisplay"] = "show";
                this.Model.Data["anonymousDisplay"] = "none";
                this.Model.Data["welcomeUser"] = $"Welcome, {this.User.Name}";
                
            }
            else
            {
                this.Model.Data["userDisplay"] = "none";
                this.Model.Data["anonymousDisplay"] = "show";
            }
        }

        protected IActionResult RedirectToHome() => this.RedirectToAction("/home/index");
    }
}
