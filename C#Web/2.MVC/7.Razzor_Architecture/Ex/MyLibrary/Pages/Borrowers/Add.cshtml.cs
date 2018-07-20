using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibrary.Data;
using MyLibrary.Models;
using MyLibrary.Web.Pages.BaseModel;

namespace MyLibrary.Web.Pages.Borrowers
{
    public class AddModel : BaseContextModel
    {
        public AddModel(BookLibraryDbContext context) : base(context)
        {
        }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Address { get; set; }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                return this.Page();
            }

            Borrower borrower = new Borrower()
            {
                Name = this.Name,
                Address = this.Address,
            };

            this.Context.Borrowers.Add(borrower);
            this.Context.SaveChanges();

            return RedirectToPage("/Index");
        }
    }
}