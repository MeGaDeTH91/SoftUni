namespace FDMC.App.Controllers
{
    using FDMC.App.BindingModels;
    using FDMC.App.Models;
    using FDMC.Data;
    using FDMC.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class CatsController : Controller
    {
        public CatsController(FDMCDbContext context)
        {
            this.Context = context;
        }

        public FDMCDbContext Context { get; private set; }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddCatBindingModel model)
        {
            if(string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.Breed))
            {
                return RedirectToAction("Add", "Cats");
            }

            int.TryParse(model.Age, out int age);

            Cat cat = new Cat()
            {
                Name = model.Name,
                Age = age,
                Breed = model.Breed,
                ImageURL = model.ImageURL
            };

            using (this.Context)
            {
                this.Context.Cats.Add(cat);
                this.Context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var cat = this.Context.Cats.FirstOrDefault(x => x.Id == id);

            if(cat == default(Cat))
            {
                return RedirectToAction("Index", "Home");
            }
            
            CatViewModel catViewModel = new CatViewModel()
            {
                Name = cat.Name,
                Age = cat.Age.ToString(),
                Breed = cat.Breed,
                ImageURL = cat.ImageURL
            };

            return this.View(catViewModel);
        }
    }
}
