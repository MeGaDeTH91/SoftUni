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
    using Microsoft.EntityFrameworkCore;

    public class UsersController : Controller
    {
        private const string LoginRoute = "/users/login";
        private const string HomeRoute = "/home/index";
        private const string UsersKey = "users";
        private const string UsernameKey = "username";
        private const string UserIdKey = "userid";
        private const string NotesKey = "notes";

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            if (!this.IsValidModel(model))
            {
                return View();
            }

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
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel model)
        {
            using(var db = new NotesDbContext())
            {
                var foundUser = db.Users.FirstOrDefault(x => x.Username == model.Username);

                if(foundUser == null)
                {
                    return RedirectToAction(LoginRoute);
                }

                db.SaveChanges();
                this.SignIn(foundUser.Username);
            }

            return RedirectToAction(HomeRoute);
        }

        [HttpGet]
        public IActionResult All()
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToAction(LoginRoute);
            }

            IDictionary<int, string> users = new Dictionary<int, string>();

            using(var db = new NotesDbContext())
            {
                users = db.Users.ToDictionary(k => k.Id, v => v.Username);
            }

            this.Model[UsersKey] = users.Any() ? string.Join(string.Empty, users.Select(u => $"<li><a href=\"/users/profile?id={u.Key}\">{u.Value}</a></li>")) : string.Empty;
            
            return View();
        }

        [HttpGet]
        public IActionResult Profile(int id)
        {
            using (var db = new NotesDbContext())
            {
                User user = db.Users
                    .Include(x => x.Notes)
                    .FirstOrDefault(x => x.Id == id);

                this.Model[UsernameKey] = user.Username;
                this.Model[UserIdKey] = user.Id.ToString();

                this.Model[NotesKey] = user.Notes.Any() ? string.Join(string.Empty, user.Notes.Select(u => $"<li><strong>{u.Title}</strong> - {u.Content}</li>")) : string.Empty;

                return View();
            }
        }

        [HttpPost]
        public IActionResult Profile(AddNoteBindingModel model)
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

        [HttpPost]
        public IActionResult Logout()
        {
            this.SignOut();

            return RedirectToAction(HomeRoute);
        }
    }
}
