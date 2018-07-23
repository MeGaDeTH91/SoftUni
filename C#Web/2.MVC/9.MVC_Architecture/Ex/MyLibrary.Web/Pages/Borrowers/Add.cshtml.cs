using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibrary.Common;
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
        [Required(ErrorMessage = ValidationConstants.ErrorMessages.BorrowerNameMessage)]
        [MinLength(ValidationConstants.BorrowerConstants.NameMinLength)]
        [MaxLength(ValidationConstants.BorrowerConstants.NameMaxLength)]
        public string Name { get; set; }

        [BindProperty]
        public string Address { get; set; }

        public IActionResult OnPost()
        {
            if (!this.ModelState.IsValid)
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