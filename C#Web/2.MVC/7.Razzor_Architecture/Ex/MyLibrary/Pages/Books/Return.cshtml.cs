using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibrary.Data;
using MyLibrary.Models;
using MyLibrary.Web.Pages.BaseModel;

namespace MyLibrary.Web.Pages.Books
{
    public class ReturnModel : BaseContextModel
    {
        private const string AtHomeStatus = "At home";

        public ReturnModel(BookLibraryDbContext context) : base(context)
        {
        }

        public IActionResult OnGet(int id)
        {
            var book = this.Context
                .Books
                .FirstOrDefault(x => x.Id == id);

            if(book == default(Book))
            {
                return RedirectToPage(IndexPage);
            }

            book.IsBorrowed = false;
            book.Status = AtHomeStatus;

            this.Context.SaveChanges();

            var bookBorrow = this.Context
                .BookBorrows
                .Where(x => x.BookId == book.Id)
                .ToList()
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            if(bookBorrow == null)
            {
                return RedirectToPage(IndexPage);
            }

            bookBorrow.EndDate = DateTime.UtcNow;
            this.Context.SaveChanges();

            return RedirectToPage("/Books/Details", new { id = book.Id });
        }
    }
}