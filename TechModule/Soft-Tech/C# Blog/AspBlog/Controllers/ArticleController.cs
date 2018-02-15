using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspBlog.Models;
using System.Data.Entity;

namespace AspBlog.Controllers
{
    public class ArticleController : Controller
    {
        private BlogDbContext db = new BlogDbContext();

        private bool IsAuthorizedToEdit(Article article)
        {
            bool isAdmin = this.User.IsInRole("Admin");
            bool isAuthor = article.IsAuthor(this.User.Identity.Name);

            return isAdmin || isAuthor;
        }

        // GET: Article
        public ActionResult List()
        {
            var articles = db.Articles
                .Include(a => a.Author)
                .ToList();

            return View(articles);
        }

        // GET: Article/Details
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpNotFoundResult("Not here with this ID, sunny");
            }

            var article = db.Articles
                .Where(a => a.Id == id)
                .Include(a => a.Author)
                .First();

            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Article/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // Post: Article/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Article article)
        {
            if(ModelState.IsValid)
            {
                var authorId = db.Users
                    .Where(x => x.UserName == this.User.Identity.Name)
                    .First()
                    .Id;
                article.AuthorId = authorId;
                article.DateAdded = DateTime.Now;
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(article);
        }

        // GET: Article/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult("Not here with this ID, sunny");
            }

            var article = db.Articles
                .Where(a => a.Id == id)
                .Include(a => a.Author)
                .First();

            if(! IsAuthorizedToEdit(article))
            {
                return new HttpNotFoundResult("You really can't touch this!");
            }

            if(article == null)
            {
                return new HttpNotFoundResult("This is not the Article you are looking for, move along!");
            }
            return View(article);
        }

        // Post: Article/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult("Not here with this ID, sunny");
            }

            var article = db.Articles
                .Where(a => a.Id == id)
                .Include(a => a.Author)
                .First();

            if (article == null)
            {
                return new HttpNotFoundResult("This is not the Article you are looking for, move along!");
            }

            db.Articles.Remove(article);
            db.SaveChanges();

            return RedirectToAction("List");
        }

        // GET: Article/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult("Not here with this ID, sunny");
            }

            var article = db.Articles
                .Where(a => a.Id == id)
                .First();

            if (!IsAuthorizedToEdit(article))
            {
                return new HttpNotFoundResult("You really can't touch this!");
            }

            if (article == null)
            {
                return new HttpNotFoundResult("This is not the Article you are looking for, move along!");
            }

            var model = new ArticleViewModel();
            model.Id = article.Id;
            model.Title = article.Title;
            model.Content = article.Content;
            return View(model);
        }

        // Post: Article/Edit
        [HttpPost]
        public ActionResult Edit(ArticleViewModel model)
        {
            if(ModelState.IsValid)
            {
                var article = db.Articles
                    .FirstOrDefault(a => a.Id == model.Id);
                article.Title = model.Title;
                article.Content = model.Content;
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }
    }
}