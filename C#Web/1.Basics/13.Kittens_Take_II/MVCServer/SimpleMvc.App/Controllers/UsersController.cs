namespace SimpleMvc.App.Controllers
{
    using System.Linq;
    using SimpleMvc.App.BindingModels;
    using SimpleMvc.Common;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Attributes.Security;
    using SimpleMvc.Framework.Interfaces;
    using SimpleMvc.Models;    

    public class UsersController : BaseController
    {
        private const string InvalidRegisterInput = "Please fill all register fields correctly.";
        private const string InvalidLoginInput = "Invalid credentials.";

        private const string UsernameTakenMessage = "The username is already taken.";
        private const string EmailTakenMessage = "The email is already taken.";

        [HttpGet]
        public IActionResult Register()
        {
            this.Model.Data[ErrorKey] = string.Empty;

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.Model.Data[ErrorKey] = InvalidRegisterInput;
            }

            string hashedPassword = PasswordUtilities.GenerateHash(model.Password);

            using (this.Context)
            {
                var users = this.Context.Users.ToList();

                bool usernameIsTaken = users.Any(x => x.Username == model.Username);
                bool emailIsTaken = users.Any(x => x.Email == model.Email);

                if(usernameIsTaken)
                {
                    this.Model.Data[ErrorKey] = UsernameTakenMessage;
                }
                if (emailIsTaken)
                {
                    this.Model.Data[ErrorKey] = EmailTakenMessage;
                }
                else
                {
                    User user = new User()
                    {
                        Username = model.Username,
                        Email = model.Email,
                        Password = hashedPassword
                    };

                    this.Context.Users.Add(user);
                    this.Context.SaveChanges();

                    this.SignIn(user.Username);
                    return RedirectToHome;
                }

            }

            return this.View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            this.Model.Data[ErrorKey] = string.Empty;

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.Model.Data[ErrorKey] = InvalidLoginInput;
            }

            User user = default(User);

            string hashedPassword = PasswordUtilities.GenerateHash(model.Password);

            using (this.Context)
            {
                user = this.Context.Users.FirstOrDefault(x => x.Username == model.Username && x.Password == hashedPassword);
            }

            if (user == default(User))
            {
                this.Model.Data[ErrorKey] = InvalidLoginInput;
            }
            else
            {
                this.SignIn(user.Username);

                return RedirectToHome;
            }


            return this.View();
        }

        [HttpGet]
        [PreAuthorize]
        public IActionResult Logout()
        {
            this.SignOut();

            return RedirectToHome;
        }
    }
}
