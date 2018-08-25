namespace MyBlog.App.Areas.Administrator.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : AdminController
    {
        public IActionResult AdminIndex()
        {
            return View();
        }
    }
}