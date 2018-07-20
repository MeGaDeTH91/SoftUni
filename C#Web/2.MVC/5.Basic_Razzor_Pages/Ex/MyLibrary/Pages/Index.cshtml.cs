using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using MyLibrary.Web.Models;
using MyLibrary.Web.Pages.BaseModel;

namespace MyLibrary.Pages
{
    public class IndexModel : BaseContextModel
    {
        public IndexModel(BookLibraryDbContext context) : base(context)
        {
        }

        public IEnumerable<BookViewModel> Books { get; set; }

        public void OnGet()
        {
            this.Books = this.Context
                .Books
                .Include(x => x.Author)
                .Select(BookViewModel.MapFromBook)
                .ToList();
        }
    }
}
