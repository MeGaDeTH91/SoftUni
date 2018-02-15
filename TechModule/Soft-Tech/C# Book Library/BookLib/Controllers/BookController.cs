using BookLib.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Data.Entity;

namespace BookLib.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Book
        public ActionResult Index()
        {

                var books = db.Books.Include(b => b.Author).ToList();
                return View(books);
                
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Include(b => b.Author)
                .SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return new HttpNotFoundResult($"Cannot find book with ID {id}");
            }
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
                book.AuthorId = User.Identity.GetUserId();

                db.Books.Add(book);
                db.SaveChanges();

                return RedirectToAction("Index");
        }

        // GET: Book/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Book book = db.Books
                .SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return new HttpNotFoundResult($"Cannot find book with ID {id}");
            }
            var userId = User.Identity.GetUserId();
            if (book.AuthorId != userId)
            {
                return new HttpNotFoundResult($"You can't touch this!");
            }

            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, Book bookViewModel)
        {
            if(bookViewModel.Title == null || bookViewModel.Description == null)
            {
                return View(bookViewModel);
            }

            Book book = db.Books.Include(b => b.Author)
                .SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return new HttpNotFoundResult($"Cannot find book with ID {id}");
            }

            book.Title = bookViewModel.Title;
            book.Description = bookViewModel.Description;
            db.SaveChanges();

            return RedirectToAction("Details", new { id = id});
        }

        // GET: Book/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            
            Book book = db.Books
                .SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return new HttpNotFoundResult($"Cannot find book with ID {id}");
            }

            var userId = User.Identity.GetUserId();
            if (book.AuthorId != userId)
            {
                return new HttpNotFoundResult($"You can't touch this!");
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Delete(int id, Book bookViewModel)
        {
            Book book = db.Books
                .SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return new HttpNotFoundResult($"Cannot find book with ID {id}");
            }
            db.Books.Remove(book);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
