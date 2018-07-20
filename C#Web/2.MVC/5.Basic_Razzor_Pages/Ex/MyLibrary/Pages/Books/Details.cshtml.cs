namespace MyLibrary.Web.Pages.Books
{
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

    public class DetailsModel : BaseContextModel
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int AuthorId { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public DetailsModel(BookLibraryDbContext context) : base(context)
        {
        }

        public IActionResult OnGet(int id)
        {
            var book = this.Context
                .Books
                .Include(x => x.Author)
                .FirstOrDefault(x => x.Id == id);

            if(book == default(Book))
            {
                return this.NotFound();
            }

            this.Title = book.Title;
            this.Author = book.Author.Name;
            this.AuthorId = book.AuthorId;
            this.Description = book.Description;
            this.ImageUrl = book.CoverImage;

            return this.Page();
        }
    }
}