namespace MyLibrary.Web.Pages.BaseModel
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using MyLibrary.Data;

    public class BaseContextModel : PageModel
    {
        protected const string IndexPage = "/Index";

        public BaseContextModel(BookLibraryDbContext context)
        {
            this.Context = context;
        }

        public BookLibraryDbContext Context { get; set; }
    }
}
