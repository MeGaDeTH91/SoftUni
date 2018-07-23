namespace MyLibrary.Web.ViewModels
{
    using MyLibrary.Models;
    using System.Collections.Generic;

    public class DirectorDetailsViewModel
    {
        public string Name { get; set; }

        public ICollection<MovieDetailsViewModel> Movies { get; set; }
    }
}
