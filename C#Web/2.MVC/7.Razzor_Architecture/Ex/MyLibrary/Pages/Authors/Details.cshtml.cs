using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using MyLibrary.Models;
using MyLibrary.Web.Pages.BaseModel;

namespace MyLibrary.Web.Pages.Authors
{
    public class DetailsModel : BaseContextModel
    {
        public DetailsModel(BookLibraryDbContext context) : base(context)
        {
        }

        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }

        public IActionResult OnGet(int id)
        {
            var author = this.Context
                .Authors
                .Include(x => x.Books)
                .FirstOrDefault(x => x.Id == id);

            if(author == default(Author))
            {
                return NotFound();
            }

            this.Name = author.Name;

            this.Books = author.Books.ToList();

            return this.Page();
        }
    }
}