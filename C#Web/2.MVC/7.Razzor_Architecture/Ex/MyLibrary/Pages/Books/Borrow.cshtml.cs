using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyLibrary.Web.Pages.Books
{
    using MyLibrary.Data;
    using MyLibrary.Web.Pages.BaseModel;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.Models;

    public class BorrowModel : BaseContextModel
    {
        private const string BorrowedStatus = "Borrowed";

        public BorrowModel(BookLibraryDbContext context) : base(context)
        {
        }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string EndDate { get; set; }
        
        public List<string> Borrowers { get; set; }

        public IActionResult OnGet(int id)
        {
            //var book = this.Context.Books.FirstOrDefault(x => x.Id == id);
            

            this.Borrowers = this.Context.Borrowers.Select(x => x.Name).ToList();

            return this.Page();
        }

        public IActionResult OnPost(int id)
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                return this.OnGet(id);
            }

            var book = this.Context
                .Books
                .Include(x => x.Borrowers)
                .FirstOrDefault(x => x.Id == id);

            var borrower = this.Context
                .Borrowers
                .Include(x => x.BorrowedBooks)
                .FirstOrDefault(x => x.Name == this.Name);
            
            DateTime? endDate = null;
            
            if(this.EndDate != null)
            {
                endDate = DateTime.Parse(this.EndDate);
            }

            if (book.IsBorrowed || endDate < DateTime.UtcNow)
            {
                return RedirectToPage(IndexPage);
            }

            book.IsBorrowed = true;
            book.Status = BorrowedStatus;

            var bookBorrow = new BookBorrow()
            {
                BookId = book.Id,
                BorrowerId = borrower.Id,
                StartDate = DateTime.UtcNow,
                EndDate = endDate
            };

            this.Context.BookBorrows.Add(bookBorrow);

            this.Context.SaveChanges();

            return RedirectToPage(IndexPage);
        }
    }
}