namespace MyLibrary.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.Data;
    using MyLibrary.Models;
    using MyLibrary.Web.BindingModels;
    using MyLibrary.Web.ViewModels;
    using System;
    using System.Globalization;
    using System.Linq;

    public class MoviesController : BaseController
    {
        private const string BorrowedStatus = "Borrowed";
        private const string AtHomeStatus = "At home";

        public MoviesController(BookLibraryDbContext context) : base(context)
        {
        }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddMovieBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            using (this.Context)
            {
                var director = this.Context
                    .Directors
                    .FirstOrDefault(x => x.Name == model.Director);

                if(director == default(Director))
                {
                    director = new Director()
                    {
                        Name = model.Director
                    };

                    this.Context.Directors.Add(director);
                    this.Context.SaveChanges();
                }


                Movie movie = new Movie()
                {
                    Title = model.Title,
                    Description = model.Description,
                    PosterImage = model.PosterImage,
                    DirectorId = director.Id
                };

                this.Context.Movies.Add(movie);
                this.Context.SaveChanges();
                
                return RedirectToAction("Details", new { id = movie.Id });
            }
        }

        [HttpGet]
        public IActionResult Borrow(int id)
        {
            var borrowersQuery = this.Context.Borrowers.Select(b => new SelectListItem() { Text = b.Name, Value = b.Id.ToString() });
            var borrowers = borrowersQuery.ToList();

            BorrowViewModel model = new BorrowViewModel()
            {
                Borrowers = borrowers,
                MovieId = id,
                StartDate = DateTime.UtcNow,
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Borrow(BorrowingBindingModel model)
        {
            var movie = this.Context
                .Movies
                .Include(x => x.Borrowers)
                .FirstOrDefault(x => x.Id == model.MovieId);

            var borrower = this.Context
                .Borrowers
                .Include(x => x.BorrowedBooks)
                .FirstOrDefault(x => x.Id == model.BorrowerId);

            if (movie.IsBorrowed || (model.EndDate != null && model.StartDate >= model.EndDate))
            {
                return RedirectToPage(IndexPage);
            }

            movie.IsBorrowed = true;
            movie.Status = BorrowedStatus;

            var modelBorrow = new MovieBorrow()
            {
                MovieId = movie.Id,
                BorrowerId = borrower.Id,
                StartDate = model.StartDate,
                EndDate = model.EndDate
            };

            this.Context.MovieBorrows.Add(modelBorrow);

            this.Context.SaveChanges();

            return RedirectToAction("Details", new { id = movie.Id });
        }

        [HttpGet]
        public IActionResult Return(int id)
        {
            var movie = this.Context
                .Movies
                .FirstOrDefault(x => x.Id == id);

            if (movie == default(Movie))
            {
                return RedirectToPage(IndexPage);
            }

            movie.IsBorrowed = false;
            movie.Status = AtHomeStatus;

            this.Context.SaveChanges();

            var movieBorrow = this.Context
                .MovieBorrows
                .Where(x => x.MovieId == movie.Id)
                .ToList()
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            if (movieBorrow == null)
            {
                return RedirectToPage(IndexPage);
            }

            movieBorrow.EndDate = DateTime.UtcNow;
            this.Context.SaveChanges();

            return RedirectToAction("Details", new { id = movie.Id });
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Movie movie = this.Context
                .Movies
                .Include(x => x.Director)
                .FirstOrDefault(x => x.Id == id);

            if(movie == default(Movie))
            {
                return RedirectToPage(IndexPage);
            }

            MovieDetailsViewModel model = new MovieDetailsViewModel()
            {
                Title = movie.Title,
                MovieId = movie.Id,
                Description = movie.Description,
                PosterImageURL = movie.PosterImage,
                DirectorId = movie.DirectorId,
                Director = movie.Director.Name,
                Status = movie.Status,
                IsBorrowed = movie.IsBorrowed
            };
            return this.View(model);
        }

        [HttpGet]
        public IActionResult Status(int id)
        {
            var movie = this.Context.Movies.FirstOrDefault(x => x.Id == id);

            if (movie == default(Movie))
            {
                return RedirectToPage(IndexPage);
            }

            var movieName = movie.Title;


            MovieStatusViewModel movieHistory = new MovieStatusViewModel()
            {
                MovieTitle = movie.Title
            };

            movieHistory.DateHistory = this.Context
                .MovieBorrows
                .Include(x => x.Borrower)
                .Where(x => x.MovieId == id)
                .Select(x => new StartEndDateModel()
                {
                    StartDate = x.StartDate.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                    EndDate = x.EndDate != null ? ((DateTime)x.EndDate).ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture) : "none",
                    BorrowerName = x.Borrower.Name
                })
                .ToList();

            return this.View(movieHistory);
        }

        [HttpGet]
        public IActionResult All()
        {
            var movies = this.Context
                .Movies
                .Include(x => x.Director)
                .Select(MovieDetailsViewModel.MapFromMovie)
                .ToList();

            return this.View(movies);
        }
    }
}