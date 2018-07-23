using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using MyLibrary.Models;
using MyLibrary.Web.ViewModels;

namespace MyLibrary.Web.Controllers
{
    public class DirectorsController : BaseController
    {
        public DirectorsController(BookLibraryDbContext context) : base(context)
        {
        }

        public IActionResult Details(int id)
        {
            var director = this.Context
                .Directors
                .Include(x => x.Movies)
                .FirstOrDefault(x => x.Id == id);

            if (director == default(Director))
            {
                return NotFound();
            }

            DirectorDetailsViewModel model = new DirectorDetailsViewModel()
            {
                Name = director.Name,
                Movies = director.Movies.Select(MovieDetailsViewModel.MapFromMovie).ToList()
            };
            
            return View(model);
        }
    }
}