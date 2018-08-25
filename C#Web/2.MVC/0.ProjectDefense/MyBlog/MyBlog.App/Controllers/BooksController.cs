namespace MyBlog.App.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.BindingModels.Books;
    using MyBlog.CommonModels.ViewModels.Books;
    using MyBlog.Models.Users;
    using MyBlog.Services.Interfaces;
    using System.Threading.Tasks;

    public class BooksController : BaseUserController
    {
        private readonly IBookService bookService;

        public BooksController(UserManager<User> userManager, IBookService bookService) : base(userManager)
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
        public IActionResult AddToFavourites(int id)
        {
            var loggerUser = this.User;
            var dbUser = this.userManager.GetUserAsync(loggerUser);

            var addedToFavourites = this.bookService.AddToFavourites(dbUser.Result.Id, id);

            if (addedToFavourites == false)
            {
                SetErrorMessage(CommonConstants.AlreadyInFavouritesOrInvalidErrorMessage);

                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.BooksSuffix);
            }

            SetSuccessMessage(CommonConstants.AddedToFavouritesSuccessfullyMessage);

            return Redirect(string.Format(RedirectConstants.BookDetailsPage, id));
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
        public IActionResult BookAuthor(int id)
        {
            var bookAuthor = this.bookService.GetBookAuthor(id);

            if (bookAuthor == null)
            {
                return RedirectToAction(RedirectConstants.IndexSuffix, RedirectConstants.BooksSuffix);
            }

            return this.View(bookAuthor);
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