namespace FDMC.App.Controllers
{
    using FDMC.App.Models;
    using FDMC.Data;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
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
            ICollection<HomeCatsViewModel> cats = this.Context.Cats
                .Select(x => new HomeCatsViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            return View(cats);
        }
    }
}
