namespace MyBlog.App.Areas.Administrator.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.BindingModels.Books;
    using MyBlog.CommonModels.ViewModels.Books;
    using MyBlog.Services.Interfaces;
    using System.Threading.Tasks;

    public class BooksController : AdminController
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var articles = this.bookService.GetAllBooks();

            return this.View(articles);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.AddBook();
            }

            int generatedId = await this.bookService.AddBookAsync(model);

            if (generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.View();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.BookSuffix));

            return Redirect(string.Format(RedirectConstants.AdministratorAreaBookDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult EditBook(int id)
        {
            BookDetailsViewModel book = this.bookService.GetBook(id);

            if (book == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(book);
        }

        [HttpPost]
        public async Task<IActionResult> EditBook(EditBookBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.EditBook(model.Id);
            }

            int generatedId = await this.bookService.EditBookAsync(model);

            if (generatedId < 1)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return Redirect(string.Format(RedirectConstants.AdministratorAreaBookDetailsPage, generatedId));
        }

        [HttpGet]
        public IActionResult DeleteBook(int id)
        {
            BookDetailsViewModel book = this.bookService.GetBook(id);

            if (book == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix);
            }

            return this.View(book);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(BookBindingModel model)
        {
            bool isDeleted = await this.bookService.DeleteBookAsync(model.Id);

            return RedirectToAction(RedirectConstants.IndexSuffix);
        }

        [HttpGet]
        public IActionResult BookCategory(int id)
        {
            var category = this.bookService.GetBookCategory(id);

            if (category == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.BooksSuffix);
            }

            return this.View(category);
        }

        [HttpGet]
        public IActionResult AddBookCategory()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBookCategory(AddBookCategoryBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.AddBookCategory();
            }

            int generatedId = await this.bookService.AddBookCategoryAsync(model);

            if (generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.AddBookCategory();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.BookCategoryDisplay));

            return RedirectToAction(RedirectConstants.BookCategorySuffix, RedirectConstants.BooksSuffix, generatedId);
        }

        [HttpGet]
        public IActionResult BookAuthor(int id)
        {
            var bookAuthor = this.bookService.GetBookAuthor(id);

            if (bookAuthor == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.BooksSuffix);
            }

            return this.View(bookAuthor);
        }

        [HttpGet]
        public IActionResult AddBookAuthor()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBookAuthor(AddBookAuthorBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                SetErrorMessage(CommonConstants.DangerMessage);

                return this.AddBookAuthor();
            }

            int generatedId = await this.bookService.AddBookAuthorAsync(model);

            if (generatedId < 1)
            {
                SetErrorMessage(CommonConstants.DuplicateMessage);

                return this.AddBookAuthor();
            }

            SetSuccessMessage(string.Format(CommonConstants.SuccessMessage, CommonConstants.BookAuthorDisplay));

            return RedirectToAction(RedirectConstants.BookAuthorSuffx, RedirectConstants.BooksSuffix, generatedId);
        }

        private void SetSuccessMessage(string successMessage)
        {
            this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
            {
                Type = MessageType.Success,
                Message = successMessage
            });
        }

        private void SetErrorMessage(string errorMessage)
        {
            this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
            {
                Type = MessageType.Danger,
                Message = errorMessage
            });
        }
    }
}