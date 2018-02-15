using System;
using System.Linq;
using System.Web.Mvc;
using TeisterMask.Models;

namespace TeisterMask.Controllers
{
        [ValidateInput(false)]
	public class TaskController : Controller
	{
        private TeisterMaskDbContext db = new TeisterMaskDbContext();

        [HttpGet]
            [Route("")]
	    public ActionResult Index()
	    {
            var tasks = db.Tasks.ToList();
            return View(tasks);
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
		public ActionResult Create(Task task)
		{
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

		[HttpGet]
		[Route("edit/{id}")]
        public ActionResult Edit(int id)
		{
            var task = db.Tasks.Find(id);
            if (task == null)
            {
                return RedirectToAction("Index");
            }
            return View(task);
        }

		[HttpPost]
		[Route("edit/{id}")]
        [ValidateAntiForgeryToken]
		public ActionResult EditConfirm(int id, Task taskModel)
		{
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            Task taskFromDB = db.Tasks.Find(taskModel.Id);

            if (taskFromDB == null)
            {
                return new HttpNotFoundResult($"Cannot find Task with ID {id}");
            }

            taskFromDB.Title = taskModel.Title;
            taskFromDB.Status = taskModel.Status;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
	}
}