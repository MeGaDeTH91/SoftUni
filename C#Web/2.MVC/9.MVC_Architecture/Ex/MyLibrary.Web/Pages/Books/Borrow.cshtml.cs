namespace MyLibrary.Web.Pages.Books
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MyLibrary.Data;
    using MyLibrary.Web.Pages.BaseModel;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.Models;
    using System.ComponentModel.DataAnnotations;
    using MyLibrary.Web.BindingModels;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class BorrowModel : BaseContextModel
    {
        private const string BorrowedStatus = "Borrowed";

        public BorrowModel(BookLibraryDbContext context) : base(context)
        {
            this.Borrowers = new List<SelectListItem>();

            this.StartDate = DateTime.UtcNow;
        }

        [Required(ErrorMessage = "You have to specify a borrower.")]
        [BindProperty]
        [Display(Name = "Borrower")]
        public int BorrowerId { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        [Required]
        public DateTime StartDate { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public IEnumerable<SelectListItem> Borrowers { get; set; }

        public IActionResult OnGet(int id)
        {
            var borrowersQuery = this.Context.Borrowers.Select(b => new SelectListItem() { Text = b.Name, Value = b.Id.ToString() });
            this.Borrowers = borrowersQuery.ToList();

            return this.Page();
        }

        public IActionResult OnPost(int id)
        {

            var book = this.Context
                .Books
                .Include(x => x.Borrowers)
                .FirstOrDefault(x => x.Id == id);

            var borrower = this.Context
                .Borrowers
                .Include(x => x.BorrowedBooks)
                .FirstOrDefault(x => x.Id == this.BorrowerId);
            
            if (book.IsBorrowed || (this.EndDate != null && this.StartDate >= this.EndDate))
            {
                return RedirectToPage(IndexPage);
            }

            book.IsBorrowed = true;
            book.Status = BorrowedStatus;

            var bookBorrow = new BookBorrow()
            {
                BookId = book.Id,
                BorrowerId = borrower.Id,
                StartDate = this.StartDate,
                EndDate = this.EndDate
            };

            this.Context.BookBorrows.Add(bookBorrow);

            this.Context.SaveChanges();

            return RedirectToPage(IndexPage);
        }


    }
}