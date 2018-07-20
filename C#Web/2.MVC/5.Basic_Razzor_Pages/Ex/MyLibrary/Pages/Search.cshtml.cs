using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibrary.Data;
using MyLibrary.Models;
using MyLibrary.Web.Models;
using MyLibrary.Web.Pages.BaseModel;

namespace MyLibrary.Web.Pages
{
    public class SearchModel : BaseContextModel
    {

        private const string SearchTermKey = "searchTerm";
        private const string AuthorPath = "/Authors/Details";
        private const string BookPath = "/Books/Details";

        public SearchModel(BookLibraryDbContext context) : base(context)
        {
            this.SearchResults = new List<BookAndAuthorSearchViewModel>();
        }

        public string SearchQuery { get; set; }

        //The keys are the search results -> Book Title or Author Name
        public List<BookAndAuthorSearchViewModel> SearchResults { get; set; }

        public IActionResult OnGet()
        {
            this.SearchQuery = this.Request.Query[SearchTermKey];

            var authors = this.Context.Authors.Where(x => x.Name.Contains(SearchQuery)).ToList();

            var books = this.Context.Books.Where(x => x.Title.Contains(SearchQuery)).ToList();

            foreach (var author in authors)
            {
                this.SearchResults.Add(new BookAndAuthorSearchViewModel()
                {
                    Id = author.Id,
                    B_Title_A_Name = author.Name,
                    Path = AuthorPath,
                    ResultType = author.GetType().Name.ToLower()
                });
            }
            foreach (var book in books)
            {
                this.SearchResults.Add(new BookAndAuthorSearchViewModel()
                {
                    Id = book.Id,
                    B_Title_A_Name = book.Title,
                    Path = BookPath,
                    ResultType = book.GetType().Name.ToLower()
                });
            }
            


            return this.Page();
        }
    }
}