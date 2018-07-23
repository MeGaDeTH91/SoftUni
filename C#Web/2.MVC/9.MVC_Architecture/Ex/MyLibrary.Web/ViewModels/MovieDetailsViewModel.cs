namespace MyLibrary.Web.ViewModels
{
    using MyLibrary.Models;
    using System;

    public class MovieDetailsViewModel
    {        
        public string Status { get; set; }

        public int MovieId { get; set; }

        public string Title { get; set; }

        public int DirectorId { get; set; }

        public string Director { get; set; }

        public string PosterImageURL { get; set; }

        public string Description { get; set; }

        public bool IsBorrowed { get; set; }

        public static Func<Movie, MovieDetailsViewModel> MapFromMovie
        {
            get
            {
                return movie => new MovieDetailsViewModel()
                {
                    Director = movie.Director.Name,
                    DirectorId = movie.DirectorId,
                    MovieId = movie.Id,
                    Title = movie.Title,
                    Status = movie.Status
                };
            }
        }
    }
}
