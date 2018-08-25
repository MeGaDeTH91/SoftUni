namespace MyBlog.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.Common;
    using MyBlog.Models.Users;

    [Authorize]
    public class BaseUserController : Controller
    {
        protected readonly UserManager<User> userManager;

        protected BaseUserController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        protected const string AdminHomeRoute = RedirectConstants.AdminHomeRoute;

        protected IActionResult RedirectToHome => this.RedirectToAction(AdminHomeRoute);
    }
}