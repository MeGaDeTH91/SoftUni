namespace MyBlog.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MyBlog.CommonModels.BindingModels.Books;
    using MyBlog.CommonModels.ViewModels.Books;

    public interface IBookService
    {
        bool AddToFavourites(string userId, int bookId);

        ICollection<BookConciseViewModel> GetAllBooks();

        BookDetailsViewModel GetBook(int id);

        BookCategoryViewModel GetBookCategory(int id);

        BookAuthorViewModel GetBookAuthor(int id);

        Task<int> AddBookAsync(BookBindingModel model);

        Task<int> EditBookAsync(EditBookBindingModel model);

        Task<bool> DeleteBookAsync(int id);

        Task<int> AddBookCategoryAsync(AddBookCategoryBindingModel model);

        Task<int> AddBookAuthorAsync(AddBookAuthorBindingModel model);
    }
}
