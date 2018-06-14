namespace HTTPServer.GameStoreApplication.Controllers
{
    using HTTPServer.GameStoreApplication.Services;
    using HTTPServer.GameStoreApplication.Services.Contracts;
    using Server.Http.Contracts;
    using System.Text;
    using System.Linq;
    using System;
    using GameStore.GameStoreApplication.Common;
    using HTTPServer.Server.Http;
    using GameStore.Data;
    using GameStore.Models;
    using System.Collections.Generic;
    using GameStore.Models.ViewModels;

    public class HomeController : BaseController
    {
        private readonly IGameService gameService;
        private readonly IUserService userService;

        private bool AdminIsLogged => this.CheckIfAdminIsLogged();
        private bool UserIsLogged => this.CheckIfUserIsLogged();
        private bool GuestUser => this.CheckIfGuestUser();

        public HomeController(IHttpRequest request) : base(request)
        {
            this.gameService = new GameService();
            this.userService = new UserService();
        }

        public IHttpResponse Index()
        {
            string userEmail = this.Request.Session.Get<string>(SessionStore.CurrentUserKey);

            User user = this.userService.FindByEmail(userEmail);

            // Search filter
            var adminFilter = false;

            bool thereIsUserLoggerd = user != default(User);

            if (thereIsUserLoggerd)
            {
                adminFilter = this.Authenticate.IsAuthenticated &&
                              this.Authenticate.IsAdmin;
            }
            
            // Get games from db
            var games = this.gameService
                .All().ToList();

            // Prepare HTML
            var gamesHtml = new StringBuilder();

            for (int i = 0; i < games.Count; i += 3)
            {
                gamesHtml.AppendLine(@"<div class=""card-group"">");

                var maxGameCount = Math.Min(i + 3, games.Count);
                for (int j = i; j < maxGameCount; j++)
                {
                    var game = games[j];

                    string gameDescription = game.Description.Substring(0, Math.Min(game.Description.Length, ValidationConstants.GameConstraints.DescriptionHomeMaxLength));
                    gamesHtml
                        .AppendLine(@"<div class=""card col-4 thumbnail"">")
                        .AppendLine($@"<img
                                        class=""card-image-top img-fluid img-thumbnail""
                                        onerror = ""this.src='https://i.ytimg.com/vi/{game.VideoId}/maxresdefault.jpg';""
                                        src = ""https://i.ytimg.com/vi/{game.VideoId}/maxresdefault.jpg"">")
                        .AppendLine($@"<div class=""card-body"">
                                        <h4 class=""card-title"">{game.Title}</h4>
                                        <p class=""card-text""><strong>Price</strong> - {game.Price:f2}&euro;</p>
                                        <p class=""card-text""><strong>Size</strong> - {game.Size:f1} GB</p>
                                        <p class=""card-text"">{gameDescription}</p>
                                        </div>")
                                        .AppendLine(@"<div class=""card-footer"">");

                    if (adminFilter)
                    {
                        gamesHtml.AppendLine($@"<a class=""card-button btn btn-warning"" name=""edit"" href=""/edit-game/{game.Id}"">Edit</a>
                                                <a class=""card-button btn btn-danger"" name=""delete"" href=""/delete-game/{game.Id}"">Delete</a>");
                    }
                    if (!thereIsUserLoggerd)
                    {
                        gamesHtml.AppendLine($@"<a class=""card-button btn btn-outline-primary"" name=""info"" href=""/game-details/{game.Id}"">Info</a>
                                        <a class=""card-button btn btn-primary"" name=""buy"" href=""/login"">Buy</a>
                                        </div>")
                        .AppendLine("</div>");
                    }
                    else
                    {
                        gamesHtml.AppendLine($@"<a class=""card-button btn btn-outline-primary"" name=""info"" href=""/game-details/{game.Id}"">Info</a>
                                        <a class=""card-button btn btn-primary"" name=""buy"" href=""/add-to-cart/{game.Id}"">Buy</a>
                                        </div>")
                        .AppendLine("</div>");
                    }
                }
            }
            
            this.ViewData["games"] = gamesHtml.ToString();
            
            return this.FileViewResponse(@"home\index");
        }

        public IHttpResponse OwnedGames()
        {
            string userEmail = this.Request.Session.Get<string>(SessionStore.CurrentUserKey);

            User user = this.userService.FindByEmail(userEmail);

            // Search filter
            var adminFilter = false;

            bool thereIsUserLoggerd = user != default(User);

            var gamesHtml = new StringBuilder();

            var games = new List<Game>();

            if (thereIsUserLoggerd)
            {
                adminFilter = this.Authenticate.IsAuthenticated &&
                              this.Authenticate.IsAdmin;

                games = user.Games.Select(x => x.Game).ToList();

                for (int i = 0; i < games.Count; i += 3)
                {
                    gamesHtml.AppendLine(@"<div class=""card-group"">");

                    var maxGameCount = Math.Min(i + 3, games.Count);
                    for (int j = i; j < maxGameCount; j++)
                    {
                        var game = games[j];

                        string gameDescription = game.Description.Substring(0, Math.Min(game.Description.Length, ValidationConstants.GameConstraints.DescriptionHomeMaxLength));
                        gamesHtml
                            .AppendLine(@"<div class=""card col-4 thumbnail"">")
                            .AppendLine($@"<img
                                        class=""card-image-top img-fluid img-thumbnail""
                                        onerror = ""this.src='https://i.ytimg.com/vi/{game.Trailer}/maxresdefault.jpg';""
                                        src = ""https://i.ytimg.com/vi/{game.Trailer}/maxresdefault.jpg"">")
                            .AppendLine($@"<div class=""card-body"">
                                        <h4 class=""card-title"">{game.Title}</h4>
                                        <p class=""card-text""><strong>Price</strong> - {game.Price:f2}&euro;</p>
                                        <p class=""card-text""><strong>Size</strong> - {game.Size:f1} GB</p>
                                        <p class=""card-text"">{gameDescription}</p>
                                        </div>")
                                            .AppendLine(@"<div class=""card-footer"">");

                        if (adminFilter)
                        {
                            gamesHtml.AppendLine($@"<a class=""card-button btn btn-warning"" name=""edit"" href=""/edit-game/{game.Id}"">Edit</a>
                                                <a class=""card-button btn btn-danger"" name=""delete"" href=""/delete-game/{game.Id}"">Delete</a>");
                        }
                        if (!thereIsUserLoggerd)
                        {
                            gamesHtml.AppendLine($@"<a class=""card-button btn btn-outline-primary"" name=""info"" href=""/game-details/{game.Id}"">Info</a>
                                        <a class=""card-button btn btn-primary"" name=""buy"" href=""/login"">Buy</a>
                                        </div>")
                            .AppendLine("</div>");
                        }
                        else
                        {
                            gamesHtml.AppendLine($@"<a class=""card-button btn btn-outline-primary"" name=""info"" href=""/game-details/{game.Id}"">Info</a>
                                        <a class=""card-button btn btn-primary"" name=""buy"" href=""/add-to-cart/{game.Id}"">Buy</a>
                                        </div>")
                            .AppendLine("</div>");
                        }
                    }
                }

                this.ViewData["games"] = gamesHtml.ToString();

                return this.FileViewResponse(@"home\index");
            }
            


            this.ViewData["games"] = gamesHtml.ToString();

            return this.FileViewResponse(@"home\index");
        }

        private bool CheckIfAdminIsLogged()
        {
            string userEmail = this.Request.Session.Get<string>(SessionStore.CurrentUserKey);

            User user = this.userService.FindByEmail(userEmail);

            return user != default(User) && user.IsAdmin;
        }

        private bool CheckIfUserIsLogged()
        {
            string userEmail = this.Request.Session.Get<string>(SessionStore.CurrentUserKey);

            User user = this.userService.FindByEmail(userEmail);

            return user != default(User) && !user.IsAdmin;
        }

        private bool CheckIfGuestUser()
        {
            string userEmail = this.Request.Session.Get<string>(SessionStore.CurrentUserKey);

            User user = this.userService.FindByEmail(userEmail);

            return user == default(User);
        }
    }
}
