namespace MyBlog.App.Areas.Administrator.Pages.Books
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.ViewModels.Books;
    using MyBlog.Services.Interfaces;

    public class BookDetailsModel : BasePageModel
    {
        public BookDetailsViewModel BookDetailsViewModel { get; private set; }
        private readonly IBookService bookService;

        public int BookId { get; set; }

        public int BookAuthorId { get; set; }

        public int BookCategoryId { get; set; }
        
        public BookDetailsModel(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult OnGet(int id)
        {
            var book = this.bookService.GetBook(id);

            if (book == null)
            {
                this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
                {
                    Type = MessageType.Danger,
                    Message = CommonConstants.NotFoundMessage
                });
            }

            this.BookId = id;
            this.BookDetailsViewModel = book;

            this.BookAuthorId = this.BookDetailsViewModel.BookAuthorId;
            this.BookCategoryId = this.BookDetailsViewModel.BookCategoryId;

            this.BookDetailsViewModel = book;
            
            return this.Page();
        }
    }
}