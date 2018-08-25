namespace MyBlog.App.Areas.Owner.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.Common;

    [Area(CommonConstants.OwnerSuffix)]
    [Authorize(Roles = CommonConstants.OwnerSuffix)]
    public class BaseOwnerController : Controller
    {
        protected const string OwnerHomeRoute = RedirectConstants.OwnerHomeRoute;

        protected IActionResult RedirectToHome => this.RedirectToAction(OwnerHomeRoute);
    }
}