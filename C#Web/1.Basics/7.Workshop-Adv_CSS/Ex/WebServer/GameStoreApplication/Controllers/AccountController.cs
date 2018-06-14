namespace HTTPServer.GameStoreApplication.Controllers
{
    using Server.Http;
    using Server.Http.Contracts;
    using Server.Http.Response;
    using GameStore.Models;
    using GameStore.Data;
    using System.Linq;
    using HTTPServer.GameStoreApplication.Utilities;
    using System;
    using GameStore.Models.ViewModels;
    using HTTPServer.GameStoreApplication.Services.Contracts;
    using HTTPServer.GameStoreApplication.Services;
    using System.Text.RegularExpressions;

    public class AccountController : BaseController
    {
        private const string RegisterView = @"account\register";
        private const string LoginView = @"account\login";
        private const string ProfileView = @"account\profile";

        private readonly IUserService userService;

        public AccountController(IHttpRequest request) : base(request)
        {
            this.userService = new UserService();
        }
        
        public IHttpResponse Login()
        {
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            return this.FileViewResponse(LoginView);
        }

        public IHttpResponse Login(LoginViewModel model)
        {
            var email = model.Email;
            var password = model.Password;

            ValidateLoginViewModel(email, password);

            User userToLog = default(User);

            using (GameStoreDbContext context = new GameStoreDbContext())
            {
                userToLog = context.Users.FirstOrDefault(x => x.Email == email);
            }

            bool userExists = ValidateUserExistence(userToLog);
            if (!userExists)
            {
                this.ViewDataErrors[$"{nameof(RegisterViewModel.Email)}Error"] = "Invalid Credentials.";

                return new RedirectResponse("/register");
            }

            string hashedPassword = PasswordUtilities.GenerateHash(password);

            bool passwordIsCorrect = userToLog.PasswordHash.Equals(hashedPassword);
            if (!passwordIsCorrect)
            {
                this.ViewDataErrors[$"{nameof(RegisterViewModel.PasswordHash)}Error"] = "Invalid Credentials.";

                return this.FileViewResponse(LoginView);
            }

            this.LoginUser(model.Email);
            
            return this.RedirectResponse(HomePath);
            
        }        

        public IHttpResponse Register()
        {
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            return this.FileViewResponse(RegisterView);
        }

        public IHttpResponse Register(RegisterViewModel model)
        {
            if (!this.ValidateRegisterViewModel(model.Email, model.FullName, model.PasswordHash, model.ConfirmPasswordHash))
            {
                return this.Register();
            }

            // Add User to Database
            var success = this.userService.Create(model.Email, model.FullName, model.PasswordHash);
            if (!success)
            {
                this.AddError("This email is already taken.");

                return this.Register();
            }


            // Login User
            this.LoginUser(model.Email);

            // Redirect to Home Page
            return this.RedirectResponse(HomePath);
        }

        public IHttpResponse Logout(IHttpRequest req)
        {
            req.Session.Clear();

            return new RedirectResponse(HomePath);
        }

        private bool ValidateUserExistence(User userToLog)
        {
            if (userToLog == default(User))
            {
                return false;
            }
            return true;
        }

        private void LoginUser(string email)
        {
            this.Request.Session.Add(SessionStore.CurrentUserKey, email);
        }

        private bool ValidateLoginViewModel(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                this.ViewDataErrors[$"{nameof(RegisterViewModel.Email)}Error"] = "Please type valid email.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                this.ViewDataErrors[$"{nameof(RegisterViewModel.PasswordHash)}Error"] = "Password must be at least 6 symbols long.";
                return false;
            }

            return true;
        }

        private bool ValidateRegisterViewModel(string email, string fullName, string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                this.ViewDataErrors[$"{nameof(RegisterViewModel.Email)}Error"] = "Please type valid email.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(fullName))
            {
                this.ViewDataErrors[$"{nameof(RegisterViewModel.FullName)}Error"] = "Please type your full name.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                this.ViewDataErrors[$"{nameof(RegisterViewModel.PasswordHash)}Error"] = "Password must be at least 6 symbols long.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                this.ViewDataErrors[$"{nameof(RegisterViewModel.ConfirmPasswordHash)}Error"] = "Confirmation password must be at least 6 symbols long.";
                return false;
            }

            if (password != confirmPassword)
            {
                this.ViewDataErrors[$"{nameof(RegisterViewModel.ConfirmPasswordHash)}Error"] = "Passwords do not match.";

                return false;
            }
            string mailPattern = @"^([a-zA-Z0-9_\.\-]+)(@)([a-z]{3,11}\.[a-z]{2})$";

            Regex regex = new Regex(mailPattern);
            if (!regex.IsMatch(email))
            {
                this.ViewDataErrors[$"{nameof(RegisterViewModel.Email)}Error"] = "Provided email is not in the correct format.";

                return false;
            }

            bool passIsStrong = CheckIfPassIsStrong(password);

            if (!passIsStrong)
            {
                this.ViewDataErrors[$"{nameof(RegisterViewModel.ConfirmPasswordHash)}Error"] = "Provided password is not strong enough.";
                return false;
            }

            return true;
        }

        private bool CheckIfPassIsStrong(string password)
        {
            bool lowerCase = password.Any(x => Char.IsLower(x));
            bool upperCase = password.Any(x => Char.IsUpper(x));
            bool digit = password.Any(x => Char.IsDigit(x));

            if (!lowerCase || !upperCase || !digit)
            {
                return false;
            }

            return true;
        }
    }
}
