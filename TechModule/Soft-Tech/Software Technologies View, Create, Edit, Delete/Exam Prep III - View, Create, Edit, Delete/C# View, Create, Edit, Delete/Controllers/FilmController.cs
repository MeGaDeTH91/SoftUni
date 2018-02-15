using System.Linq;
using System.Net;
using System.Web.Mvc;
using IMDB.Models;

namespace IMDB.Controllers
{
    [ValidateInput(false)]
    public class FilmController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var database = new IMDBDbContext())
            {
                var films = database.Films.ToList();
                return View(films);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            using (var database = new IMDBDbContext())
            {
                if (ModelState.IsValid)
                {
                    database.Films.Add(film);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            using (var database = new IMDBDbContext())
            {
                var film = database.Films.Find(id);
                if (film == null)
                {
                    return RedirectToAction("Index");
                }
                return View(film);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Film filmModel)
        {
            using (var database = new IMDBDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }

                Film taskFromDB = database.Films.Find(filmModel.Id);

                if (taskFromDB == null)
                {
                    return new HttpNotFoundResult($"Cannot find Task with ID {id}");
                }

                taskFromDB.Name = filmModel.Name;
                taskFromDB.Genre = filmModel.Genre;
                taskFromDB.Director = filmModel.Director;
                taskFromDB.Year = filmModel.Year;
                database.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            using (var database = new IMDBDbContext())
            {
                var film = database.Films.Find(id);
                if (film == null)
                {
                    return RedirectToAction("Index");
                }
                return View(film);
            }
                
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id, Film filmModel)
        {
            using (var database = new IMDBDbContext())
            {
                var film = database.Films.Find(id);
                if (film == null)
                {
                    return RedirectToAction("Index");
                }
                database.Films.Remove(film);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}