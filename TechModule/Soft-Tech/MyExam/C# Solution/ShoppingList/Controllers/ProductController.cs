using System.Linq;
using System.Web.Mvc;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    [ValidateInput(false)]
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var database = new ShoppingListDbContext())
            {
                var products = database.Products.ToList();
                return View(products);
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
        public ActionResult Create(Product product)
        {
            using (var database = new ShoppingListDbContext())
            {
                if (ModelState.IsValid)
                {
                    database.Products.Add(product);
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
            using (var database = new ShoppingListDbContext())
            {
                var product = database.Products.Find(id);
                if (product == null)
                {
                    return RedirectToAction("Index");
                }
                return View(product);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Product productModel)
        {
            using (var database = new ShoppingListDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }

                Product productFromDB = database.Products.Find(productModel.Id);

                if (productFromDB == null)
                {
                    return new HttpNotFoundResult($"Cannot find Product with ID {id}");
                }

                productFromDB.Priority = productModel.Priority;
                productFromDB.Name = productModel.Name;
                productFromDB.Quantity = productModel.Quantity;
                productFromDB.Status = productModel.Status;
                database.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}