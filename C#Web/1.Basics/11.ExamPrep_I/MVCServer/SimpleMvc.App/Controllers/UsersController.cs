namespace SimpleMvc.App.Controllers
{
    using SimpleMvc.App.BindingModels;
    using SimpleMvc.Common;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;
    using SimpleMvc.Models;
    using System.Linq;

    public class UsersController : BaseController
    {
        private const string ErrorKey = "error";
        private const string ErrorMessage = "Invalid username and / or password";

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
            User userToAdd = new User()
            {
                Email = model.Email,
                Password = hashedPassword,
                Username = model.Username
            };

            using (this.Context)
            {
                this.Context.Users.Add(userToAdd);
                this.Context.SaveChanges();
            }
            
            this.SignIn(userToAdd.Username);

            return this.RedirectToHome();
        }

        [HttpGet]
        public IActionResult Login()
        {
            this.Model.Data[ErrorKey] = string.Empty;
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel model)
        {
            string hashedPass = PasswordUtilities.GenerateHash(model.Password);

            using (this.Context)
            {
                var user = this.Context.Users.FirstOrDefault(x => x.Username == model.Username && x.Password == hashedPass);

                if(user == null)
                {
                    this.Model.Data[ErrorKey] = ErrorMessage;
                    return this.View();
                }
                else
                {
                    this.SignIn(user.Username);
                    return RedirectToHome();
                }
            }
        }
    }
}
