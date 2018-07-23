using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibrary.Data;
using MyLibrary.Models;
using MyLibrary.Web.Models;
using MyLibrary.Web.Pages.BaseModel;

namespace MyLibrary.Web.Pages.Books
{
    public class StatusModel : BaseContextModel
    {
        public StatusModel(BookLibraryDbContext context) : base(context)
        {
        }

        public string BookName { get; set; }

        public List<BookBorrowViewModel> BookHistory { get; set; }

        public IActionResult OnGet(int id)
        {
            var book = this.Context.Books.FirstOrDefault(x => x.Id == id);

            if(book == default(Book))
            {
                return RedirectToPage(IndexPage);
            }

            this.BookName = book.Title;

            this.BookHistory = this.Context
                .BookBorrows
                .Where(x => x.BookId == id)
                .Select(x => new BookBorrowViewModel()
                {
                    StartDate = x.StartDate.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                    EndDate = x.EndDate != null? ((DateTime)x.EndDate).ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture) : "none"
                })
                .ToList();

            return this.Page();
        }
    }
}