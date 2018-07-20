namespace MyLibrary.Web.Pages.BaseModel
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using MyLibrary.Data;

    public class BaseContextModel : PageModel
    {
        public BaseContextModel(BookLibraryDbContext context)
        {
            this.Context = context;
        }

        public BookLibraryDbContext Context { get; set; }
    }
}
