using System;
using System.Linq;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
	public class TaskController : Controller
	{
        private TodoListDbContext db = new TodoListDbContext();

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
            if(task == null)
            {
                return RedirectToAction("Index");
            }

            if(string.IsNullOrWhiteSpace(task.Title) || string.IsNullOrWhiteSpace(task.Comments))
            {
                return RedirectToAction("Index");
            }
            db.Tasks.Add(task);
            db.SaveChanges();

		    return RedirectToAction("Index");
        }

		[HttpGet]
		[Route("delete/{id}")]
        public ActionResult Delete(int id)
		{
            var task = db.Tasks.Find(id);
            if(task == null)
            {
                return RedirectToAction("Index");
            }
            return View(task);
        }

		[HttpPost]
		[Route("delete/{id}")]
        [ValidateAntiForgeryToken]
		public ActionResult DeleteConfirm(int id)
		{
            var task = db.Tasks.Find(id);
            if (task == null)
            {
                return RedirectToAction("Index");
            }

            db.Tasks.Remove(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}