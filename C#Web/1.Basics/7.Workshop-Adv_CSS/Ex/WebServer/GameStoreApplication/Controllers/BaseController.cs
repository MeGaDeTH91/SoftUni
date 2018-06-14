namespace HTTPServer.GameStoreApplication.Controllers
{
    using Services.Contracts;
    using Infrastructure;
    using HTTPServer.GameStoreApplication.Services;
    using HTTPServer.Server.Http.Contracts;
    using HTTPServer.Server.Http;
    using HTTPServer.GameStoreApplication.Common;
    using GameStore.Models;

    public class BaseController : Controller
    {
        protected const string HomePath = "/";

        private readonly IUserService users;
        
        protected BaseController(IHttpRequest request)
        {
            this.Request = request;
            this.users = new UserService();

            this.ApplyAuthentication();
        }

        protected IHttpRequest Request { get; private set; }

        protected Authenticate Authenticate { get; private set; }

        protected override string ApplicationDirectory => "GameStoreApplication";

        private void ApplyAuthentication()
        {
            // Anonymous Users
            var anonymousDisplay = "flex";
            var authDisplay = "none";
            var adminDisplay = "none";

            var authenticatedUserEmail = this.Request
                .Session
                .Get<string>(SessionStore.CurrentUserKey);

            // Logged in user
            if (authenticatedUserEmail != null)
            {
                anonymousDisplay = "none";
                authDisplay = "flex";

                // Admin user
                var isAdmin = this.users.IsAdmin(authenticatedUserEmail);
                if (isAdmin)
                {
                    adminDisplay = "flex";
                }

                this.Authenticate = new Authenticate(true, isAdmin);
            }

            this.ViewData["anonymousDisplay"] = anonymousDisplay;
            this.ViewData["authDisplay"] = authDisplay;
            this.ViewData["adminDisplay"] = adminDisplay;
        }
    }
}
