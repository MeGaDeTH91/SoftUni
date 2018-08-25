namespace MyBlog.App.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.Models.Users;

    public class HomeController : BaseUserController
    {
        public HomeController(UserManager<User> userManager) : base(userManager)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}