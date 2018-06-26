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
        private const string InvalidCredentialsMessage = "Invalid username and / or password";
        private const string RegisterErrorMessage = "Please check your input data!";
        private const string LogoutErrorMessage = "You must login before you attempt to logout.";

        [HttpGet]
        public IActionResult Register()
        {
            this.Model.Data[ErrorKey] = HideMessageValue;
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.Model.Data[ErrorKey] = ShowMessageValue;
                this.Model.Data[ErrorMessageKey] = RegisterErrorMessage;
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
                var users = this.Context.Users.ToList();

                if (users.Any(x => x.Email == userToAdd.Email || x.Username == userToAdd.Username))
                {
                    this.Model.Data[ErrorKey] = ShowMessageValue;
                    this.Model.Data[ErrorMessageKey] = RegisterErrorMessage;
                    return View();
                }
                this.Context.Users.Add(userToAdd);
                this.Context.SaveChanges();
            }
            
            this.SignIn(userToAdd.Username);

            return this.RedirectToHome();
        }

        [HttpGet]
        public IActionResult Login()
        {
            this.Model.Data[ErrorKey] = HideMessageValue;
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.Model.Data[ErrorKey] = ShowMessageValue;
                this.Model.Data[ErrorMessageKey] = InvalidCredentialsMessage;
                return View();
            }

            string hashedPass = PasswordUtilities.GenerateHash(model.Password);

            using (this.Context)
            {
                var user = this.Context.Users.FirstOrDefault(x => x.Username == model.Username && x.Password == hashedPass);

                if(user == null)
                {
                    this.Model.Data[ErrorKey] = ShowMessageValue;
                    this.Model.Data[ErrorMessageKey] = InvalidCredentialsMessage;
                    return this.View();
                }
                else
                {
                    this.SignIn(user.Username);
                    return RedirectToHome();
                }
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            if (!this.User.IsAuthenticated)
            {
                this.Model.Data[ErrorKey] = LogoutErrorMessage;
                return RedirectToAction(LoginRoute);
            }

            this.SignOut();

            return RedirectToHome();
        }
    }
}
