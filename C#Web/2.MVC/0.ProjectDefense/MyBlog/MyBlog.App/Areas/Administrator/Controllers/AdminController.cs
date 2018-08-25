namespace MyBlog.App.Areas.Administrator.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.Common;

    [Area(CommonConstants.AdminSuffix)]
    [Authorize(Roles = CommonConstants.AdminSuffix)]
    public class AdminController : Controller
    {
        protected const string AdminHomeRoute = RedirectConstants.AdminHomeRoute;

        protected IActionResult RedirectToHome => this.RedirectToAction(AdminHomeRoute);
    }
}