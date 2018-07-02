namespace SoftUni.WebServer.App.Controllers
{
    using Microsoft.EntityFrameworkCore;
    using SoftUni.WebServer.App.BindingModels;
    using SoftUni.WebServer.Common;
    using SoftUni.WebServer.Models;
    using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
    using SoftUni.WebServer.Mvc.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class UsersController : BaseController
    {
        private const string InvalidRegisterInputMessage = "Please fill all fields correctly!";
        private const string InvalidLoginInputMessage = "Invalid credentials!";
        private const string EmailTakenMessage = "The specified email is taken.";
        private const string UsernameTakenMessage = "The specified username is taken.";
        private const string AdminRoleLabel = "Admin";
        private const string UserRoleLabel = "User";

        [HttpGet]
        public IActionResult Register()
        {
            if (this.User.IsAuthenticated)
            {
                return RedirectToHome;
            }

            this.ViewData[ErrorKey] = string.Empty;

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.ViewData[ErrorKey] = InvalidRegisterInputMessage;

                return this.View();
            }

            using (this.Context)
            {
                bool usernameIsTaken = this.Context.Users.Any(x => x.Username == model.Username);
                bool emailIsTaken = this.Context.Users.Any(x => x.Email == model.Email);

                if (usernameIsTaken)
                {
                    this.ViewData[ErrorKey] = UsernameTakenMessage;
                }
                else if (emailIsTaken)
                {
                    this.ViewData[ErrorKey] = EmailTakenMessage;
                }
                else
                {
                    string passwordHash = PasswordUtilities.GetPasswordHash(model.Password);
                    bool noUsersRegistered = !this.Context.Users.Any();

                    List<Role> roles = this.Context.Roles.ToList();
                    
                    Role role = default(Role);

                    if (noUsersRegistered)
                    {
                        role = roles.FirstOrDefault(x => x.TypeName == AdminRoleLabel);
                    }
                    else
                    {
                        role = roles.FirstOrDefault(x => x.TypeName == UserRoleLabel);
                    }

                    List<Role> tempRoles = new List<Role>();

                    tempRoles.Add(role);

                    List<string> rolesStringRepresentation = tempRoles.Select(x => x.TypeName).ToList();

                    User user = new User()
                    {
                        Username = model.Username,
                        FullName = model.FullName,
                        Email = model.Email,
                        Password = passwordHash,
                        RoleId = role.Id,
                        Role = role
                    };

                    this.Context.Users.Add(user);
                    this.Context.SaveChanges();

                    this.SignIn(user.Username, user.Id, rolesStringRepresentation);
                    return RedirectToHome;
                }
            }
            return this.View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (this.User.IsAuthenticated)
            {
                return RedirectToHome;
            }

            this.ViewData[ErrorKey] = string.Empty;

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.ViewData[ErrorKey] = InvalidLoginInputMessage;

                return this.View();
            }

            using (this.Context)
            {
                string passwordHash = PasswordUtilities.GetPasswordHash(model.Password);

                bool credentialsAreValid = this.Context.Users.Any(x => x.Username == model.Username && x.Password == passwordHash);

                if (!credentialsAreValid)
                {
                    this.ViewData[ErrorKey] = InvalidLoginInputMessage;
                }
                else
                {
                    List<Role> roles = new List<Role>();
                    
                    User user = this.Context.Users.Include(x => x.Role).FirstOrDefault(x => x.Username == model.Username && x.Password == passwordHash);

                    roles.Add(user.Role);

                    List<string> rolesStringRepresentation = roles.Select(x => x.TypeName).ToList();

                    this.SignIn(user.Username, user.Id, rolesStringRepresentation);

                    return RedirectToHome;
                }
            }
            return this.View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin;
            }

            this.SignOut();

            return RedirectToHome;
        }
    }
}
