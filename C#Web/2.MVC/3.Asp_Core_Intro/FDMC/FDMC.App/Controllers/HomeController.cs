namespace FDMC.App.Controllers
{
    using FDMC.Data;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class HomeController : Controller
    {
        public HomeController(FDMCDbContext context)
        {
            this.Context = context;
        }

        public FDMCDbContext Context { get; private set; }

        [HttpGet]
        public IActionResult Index()
        {
            var cats = this.Context.Cats.ToList();

            return View(cats);
        }
    }
}
