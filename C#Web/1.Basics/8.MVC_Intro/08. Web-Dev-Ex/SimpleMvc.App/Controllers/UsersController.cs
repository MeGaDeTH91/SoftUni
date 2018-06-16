namespace SimpleMvc.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using SimpleMvc.App.BindingModels;
    using SimpleMvc.Data;
    using SimpleMvc.Domain;
    using SimpleMvc.Domain.Common;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;
    using SimpleMvc.Framework.Interfaces.Generic;
    using SimpleMvc.App.ViewModels;
    using Microsoft.EntityFrameworkCore;

    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            string hashedPassword = PasswordUtilities.GenerateHash(model.Password);

            User userToRegister = new User()
            {
                Username = model.Username,
                Password = hashedPassword
            };

            using(var db = new NotesDbContext())
            {
                db.Users.Add(userToRegister);
                db.SaveChanges();
            }

            return View();
        }

        [HttpGet]
        public IActionResult<IEnumerable<UserViewModel>> All()
        {
            IEnumerable<UserViewModel> viewModel = null;

            using(var db = new NotesDbContext())
            {
                viewModel = db.Users.Select(x => new UserViewModel()
                {
                    Id = x.Id,
                    Username = x.Username,
                    Notes = x.Notes
                }).ToList();
            }
            
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            using (var db = new NotesDbContext())
            {
                User user = db.Users
                    .Include(x => x.Notes)
                    .FirstOrDefault(x => x.Id == id);

                var viewModel = new UserProfileViewModel
                {
                    UserId = id,
                    Username = user.Username,
                    Notes = user.Notes
                    .Select(x => new NoteViewModel()
                    {
                        Title = x.Title,
                        Content = x.Content
                    })
                };

                return View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
        {
            using(var db = new NotesDbContext())
            {
                var user = db.Users.Find(model.UserId);

                Note note = new Note()
                {
                    Title = model.Title,
                    Content = model.Content,
                };
                user.Notes.Add(note);
                db.SaveChanges();
            }

            return Profile(model.UserId);
        }
    }
}
