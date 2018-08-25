namespace MyBlog.App.Areas.Premium.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.Common;

    [Area(CommonConstants.PremiumAreaSuffix)]
    [Authorize(Roles = CommonConstants.PremiumUserSuffix)]
    public class PremiumController : Controller
    {
        protected const string PremiumHomeRoute = RedirectConstants.PremiumHomeRoute;

        protected IActionResult RedirectToHome => this.RedirectToAction(PremiumHomeRoute);
    }
}