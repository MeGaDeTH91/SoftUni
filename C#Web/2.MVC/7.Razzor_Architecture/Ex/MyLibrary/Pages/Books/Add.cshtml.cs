namespace MyLibrary.Web.Pages.Books
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using MyLibrary.Data;
    using MyLibrary.Models;
    using MyLibrary.Web.Pages.BaseModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class AddModel : BaseContextModel
    {
        public AddModel(BookLibraryDbContext context) : base(context)
        {
        }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        public string Author { get; set; }

        [BindProperty]
        [Display(Name = "Image URL")]
        [DataType(DataType.ImageUrl)]
        public string ImageURL { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Author author = this.Context.Authors.FirstOrDefault(x => x.Name == this.Author);

            if(author == default(Author))
            {
                author = new Author()
                {
                    Name = this.Author
                };
                this.Context.Authors.Add(author);
                this.Context.SaveChanges();
            }

            Book book = new Book()
            {
                Title = this.Title,
                AuthorId = author.Id,
                Author = author,
                Description = this.Description,
                CoverImage = this.ImageURL
            };

            this.Context.Books.Add(book);
            this.Context.SaveChanges();

            return this.RedirectToPage("/Books/Details", new { id = book.Id});
        }
    }
}