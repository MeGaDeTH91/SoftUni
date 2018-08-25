namespace MyBlog.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyBlog.Common;
    using MyBlog.Common.Helpers;
    using MyBlog.CommonModels.BindingModels.Books;
    using MyBlog.CommonModels.ViewModels.Books;
    using MyBlog.Data;
    using MyBlog.Models.Books;
    using MyBlog.Models.Users;
    using MyBlog.Services.Interfaces;

    public class BookService : BaseBlogService, IBookService
    {
        public BookService(BlogDataDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public bool AddToFavourites(string userId, int bookId)
        {
            var user = this.DbContext
                .Users
                .FirstOrDefault(x => x.Id == userId);

            var book = this.DbContext
                .Books
                .FirstOrDefault(x => x.Id == bookId);

            if (user == null || book == null)
            {
                return false;
            }

            var userBook = new UserBooks()
            {
                UserId = userId,
                BookId = bookId,
                AddedToFavouritesOn = DateTime.UtcNow
            };

            bool alreadyInFavourites = this.DbContext.FavouriteUserBooks
                .Any(x => x.UserId == userId && x.BookId == bookId);

            if (alreadyInFavourites)
            {
                return false;
            }

            user.FavouriteBooks.Add(userBook);
            this.DbContext.SaveChanges();

            return true;
        }

        public async Task<int> AddBookAsync(BookBindingModel model)
        {
            var checkForDuplicate = this.DbContext
                .Books
                .FirstOrDefault(x => x.Title == model.Title);

            if (checkForDuplicate != null)
            {
                return ErrorId;
            }

            var book = this.Mapper.Map<Book>(model);

            var bookCategory = this.DbContext
                .BookCategories
                .FirstOrDefault(x => x.BookCategoryName == model.BookCategoryStr);

            if (bookCategory == null)
            {
                bookCategory = new BookCategory()
                {
                    BookCategoryName = model.BookCategoryStr
                };

                await this.DbContext.BookCategories.AddAsync(bookCategory);
                await this.DbContext.SaveChangesAsync();
            }

            var bookAuthor = this.DbContext
                .BookAuthors
                .FirstOrDefault(x => x.FullName == model.BookAuthorStr);

            if (bookAuthor == null)
            {
                return ErrorId;
            }

            book.BookAuthorId = bookAuthor.Id;
            book.BookAuthor = bookAuthor;

            book.BookCategoryId = bookCategory.Id;
            book.BookCategory = bookCategory;

            await this.DbContext.Books.AddAsync(book);
            await this.DbContext.SaveChangesAsync();

            return book.Id;
        }

        public async Task<int> AddBookAuthorAsync(AddBookAuthorBindingModel model)
        {
            var checkForDuplicate = this.DbContext
                .BookAuthors
                .FirstOrDefault(x => x.FullName == model.FullName);

            if(checkForDuplicate != null)
            {
                return ErrorId;
            }

            var newAuthor = this.Mapper.Map<BookAuthor>(model);

            var authorGenre = this.DbContext
                .BookAuthorGenres
                .FirstOrDefault(x => x.AuthorGenreName == model.BookAuthorGenreStr);

            if(authorGenre == null)
            {
                authorGenre = new BookAuthorGenre()
                {
                    AuthorGenreName = model.BookAuthorGenreStr
                };

                await this.DbContext.BookAuthorGenres.AddAsync(authorGenre);
                await this.DbContext.SaveChangesAsync();
            }

            newAuthor.BookAuthorGenreId = authorGenre.Id;
            newAuthor.BookAuthorGenre = authorGenre;

            if (newAuthor.HighLightVideoURL.Contains(CommonConstants.OriginalVideoUrlPart))
            {
                newAuthor.HighLightVideoURL = ModifyVideoURL_Embeded.ModifyEmbed(newAuthor.HighLightVideoURL);
            }

            await this.DbContext.BookAuthors.AddAsync(newAuthor);
            await this.DbContext.SaveChangesAsync();

            return newAuthor.Id;
        }

        public async Task<int> AddBookCategoryAsync(AddBookCategoryBindingModel model)
        {
            var existingCategory = this.DbContext
                .BookCategories
                .FirstOrDefault(x => x.BookCategoryName == model.BookCategoryName);

            if (existingCategory != null)
            {
                return ErrorId;
            }

            var category = this.Mapper.Map<BookCategory>(model);

            await this.DbContext.BookCategories.AddAsync(category);
            await this.DbContext.SaveChangesAsync();

            return category.Id;
        }
        
        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = this.DbContext
                .Books
                .FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return false;
            }

            this.DbContext.Books.Remove(book);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<int> EditBookAsync(EditBookBindingModel model)
        {
            var book = this.DbContext
                .Books
                .FirstOrDefault(x => x.Id == model.Id);

            if (book == null)
            {
                return ErrorId;
            }

            book.Description = model.Description;
            book.PhotoURL = model.PhotoURL;
            book.AdditionalInfoURL = model.AdditionalInfoURL;

            await this.DbContext.SaveChangesAsync();

            return book.Id;
        }

        public ICollection<BookConciseViewModel> GetAllBooks()
        {
            var books = this.DbContext
                .Books
                .Select(x => this.Mapper.Map<BookConciseViewModel>(x))
                .ToList();

            return books;
        }

        public BookDetailsViewModel GetBook(int id)
        {
            var actualBook = this.DbContext
                .Books
                .Include(x => x.BookCategory)
                .Include(x => x.BookAuthor)
                .Include(x => x.AddedToFavoritesBy)
                .FirstOrDefault(x => x.Id == id);

            if (actualBook == null)
            {
                return null;
            }

            var book = this.Mapper.Map<BookDetailsViewModel>(actualBook);

            return book;
        }

        public BookAuthorViewModel GetBookAuthor(int id)
        {
            var bookAuthor = this.DbContext
                .BookAuthors
                .Include(x => x.Books)
                .Include(x => x.BookAuthorGenre)
                .FirstOrDefault(x => x.Id == id);

            if (bookAuthor == null)
            {
                return null;
            }

            var bookAuthorModel = this.Mapper.Map<BookAuthorViewModel>(bookAuthor);

            return bookAuthorModel;
        }

        public BookCategoryViewModel GetBookCategory(int id)
        {
            var bookCategory = this.DbContext
                .BookCategories
                .Include(x => x.Books)
                .FirstOrDefault(x => x.Id == id);

            if (bookCategory == null)
            {
                return null;
            }

            var bookCategoryModel = new BookCategoryViewModel()
            {
                BookCategoryName = bookCategory.BookCategoryName,
                Books = this.Mapper.Map<ICollection<BookConciseViewModel>>(bookCategory.Books)
            };

            return bookCategoryModel;
        }
    }
}
