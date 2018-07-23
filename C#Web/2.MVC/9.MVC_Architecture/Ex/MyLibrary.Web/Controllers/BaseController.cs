using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Data;

namespace MyLibrary.Web.Controllers
{
    public class BaseController : Controller
    {
        protected const string IndexPage = "/Index";

        public BaseController(BookLibraryDbContext context)
        {
            this.Context = context;
        }

        public BookLibraryDbContext Context { get; set; }
    }
}