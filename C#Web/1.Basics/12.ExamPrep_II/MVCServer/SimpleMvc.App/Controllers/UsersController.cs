namespace SimpleMvc.App.Controllers
{
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.App.BindingModels;
    using SimpleMvc.Common;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Attributes.Security;
    using SimpleMvc.Framework.Interfaces;
    using SimpleMvc.Models;
    

    public class UsersController : BaseController
    {
        private const string UsernameKey = "username";
        private const string EmailKey = "email";
        private const string VideosKey = "videos";

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
                this.Model.Data[ErrorKey] = InvalidLoginDetails;

                return this.View();
            }

            string hashedPassToCheck = PasswordUtilities.GenerateHash(model.Password);

            using (this.Context)
            {
                User userToLog = this.Context
                    .Users.FirstOrDefault(x => x.Username == model.Username && x.Password == hashedPassToCheck);

                if(userToLog == null)
                {
                    this.Model.Data[ErrorKey] = InvalidLoginDetails;

                    return this.View();
                }

                this.SignIn(userToLog.Username);

                return RedirectToHome();
            }
        }

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
                this.Model.Data[ErrorKey] = InvalidRegisterDetails;

                return this.View();
            }
            using (this.Context)
            {
                bool userExists = CheckForExistingUser(model);
                if (userExists)
                {
                    return this.View();
                }

                string passwordHash = PasswordUtilities.GenerateHash(model.Password);

                User user = new User()
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = passwordHash,
                };
                this.Context.Users.Add(user);
                this.Context.SaveChanges();

                this.SignIn(user.Username);

                return RedirectToHome();
            }
        }

        [HttpGet]
        [PreAuthorize]
        public IActionResult Logout()
        {
            if (!this.SessionUser.IsAuthenticated)
            {
                this.Model.Data[ErrorKey] = LogoutErrorMessage;
                return RedirectToAction(LoginRoute);
            }

            this.SignOut();

            return RedirectToHome();
        }

        [HttpGet]
        [PreAuthorize]
        public IActionResult Profile()
        {
            if (!this.SessionUser.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            string loggedUsername = this.SessionUser.Name;

            User user = default(User);

            using(this.Context)
            {
                user = this.Context
                    .Users
                    .Include(x => x.Tubes)
                    .FirstOrDefault(x => x.Username == loggedUsername);
            }

            StringBuilder result = new StringBuilder();

            int rowNumber = 1;

            foreach (var tube in user.Tubes)
            {
                result.AppendLine($@"<tr>
                    <th scope=""row"">{rowNumber}</th>
                        <td>{tube.Title}</td>
                        <td>{tube.Author}</td>
                        <td><a href=""/tubes/details?id={tube.Id}"">Details</a></td>
                    </tr>");

                rowNumber++;
            }

            this.Model.Data[UsernameKey] = user.Username;
            this.Model.Data[EmailKey] = $"({user.Email})";
            this.Model.Data[VideosKey] = result.ToString();
            
            return this.View();
        }

        private bool CheckForExistingUser(RegisterUserBindingModel model)
        {
            if (this.Context.Users.Any(x => x.Email == model.Email))
            {
                this.Model.Data[ErrorKey] = InvalidRegisterEmailExists;
                return true;
            }
            if (this.Context.Users.Any(x => x.Username == model.Username))
            {
                this.Model.Data[ErrorKey] = InvalidRegisterUsernameExists;
                return true;
            }

            return false;
        }
    }
}
