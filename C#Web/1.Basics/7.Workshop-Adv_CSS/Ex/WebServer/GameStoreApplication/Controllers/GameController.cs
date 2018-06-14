namespace HTTPServer.GameStoreApplication.Controllers
{
    using GameStore.Data;
    using GameStore.Models;
    using HTTPServer.Server.Http;
    using Server.Http.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameStore.Models.ViewModels;
    using System.Text.RegularExpressions;
    using HTTPServer.GameStoreApplication.Services.Contracts;
    using HTTPServer.GameStoreApplication.Services;
    using HTTPServer.Server.Http.Response;
    using Microsoft.EntityFrameworkCore;
    using System.Text;

    public class GameController : BaseController
    {
        private const string AdminGamesConst = @"game\admin-games";
        private const string LoginRedirectLink = @"/login";
        private const string AddGame = @"game\add-game";
        private const string DeleteGame = @"game\delete-game";
        private const string EditGame = @"game\edit-game";
        private const string DetailGame = @"game\game-details";
        private const string GameIdKey = "gameId";
        private const string IdKey = @"id";
        private const string TitleKey = "title";
        private const string DescriptionKey = "description";
        private const string ImageUrlKey = "imageUrl";
        private const string PriceKey = "price";
        private const string SizeKey = "size";
        private const string TrailerKey = "trailer";
        private const string ReleaseDateKey = "released";

        private bool AdminIsLogged => this.CheckIfAdminIsLogged();
        private bool UserIsLogged => this.CheckIfUserIsLogged();
        private bool GuestUser => this.CheckIfGuestUser();

        private readonly IUserService userService;
        private readonly IGameService gameService;

        public GameController(IHttpRequest request) : base(request)
        {
            this.userService = new UserService();
            this.gameService = new GameService();
        }

        public IHttpResponse Add()
        {
            this.ViewData["showResult"] = "none";
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            if (!AdminIsLogged)
            {
                return this.RedirectResponse(LoginRedirectLink);
            }

            return this.FileViewResponse(AddGame);
        }

        public IHttpResponse Add(AdminAddGameViewModel model)
        {
            string title = model.Title;
            string description = model.Description;
            string imageUrl = model.ImageURL;
            decimal price = model.Price;
            double size = model.Size;
            DateTime releaseDate = model.ReleaseDate;
            string trailer = model.Trailer;

            bool isDataValid = ValidateGameInput(title, description, imageUrl, price, size, releaseDate, trailer);

            if (!isDataValid)
            {
                return this.FileViewResponse(AddGame);
            }
            
            using (var db = new GameStoreDbContext())
            {
                Game gameToAdd = new Game
                {
                    Title = title,
                    Description = description,
                    Price = price,
                    Size = size,
                    Trailer = trailer,
                    ReleaseDate = releaseDate
                };

                if (!string.IsNullOrWhiteSpace(imageUrl))
                {
                    gameToAdd.ImageURL = imageUrl;
                }

                db.Games.Add(gameToAdd);
                db.SaveChanges();
            };

            return this.RedirectResponse(HomePath);
        }

        public IHttpResponse Delete()
        {
            var gameId = int.Parse(this.Request.UrlParameters[IdKey]);

            Game game = default(Game);

            if (!AdminIsLogged)
            {
                return this.FileViewResponse(LoginRedirectLink);
            }

            using (var db = new GameStoreDbContext())
            {
                game = db.Games.FirstOrDefault(x => x.Id == gameId);
            }

            this.ViewData[TitleKey] = game.Title;
            this.ViewData[DescriptionKey] = game.Description;
            this.ViewData[ImageUrlKey] = game.ImageURL;
            this.ViewData[PriceKey] = game.Price.ToString("F2");
            this.ViewData[SizeKey] = game.Size.ToString();
            this.ViewData[TrailerKey] = game.Trailer;
            this.ViewData[ReleaseDateKey] = game.ReleaseDate.ToString("yyyy-MM-dd");

            return this.FileViewResponse(DeleteGame);
        }

        public IHttpResponse Delete(int id)
        {
            if (!this.Authenticate.IsAdmin)
            {
                return this.RedirectResponse(HomePath);
            }

            using(var db = new GameStoreDbContext())
            {
                Game gameToDelete = db.Games.FirstOrDefault(x => x.Id == id);

                db.Games.Remove(gameToDelete);
                db.SaveChanges();
            }

            return this.RedirectResponse(HomePath);
        }

        public IHttpResponse Edit()
        {
            var gameId = int.Parse(this.Request.UrlParameters[IdKey]);

            Game game = default(Game);

            if (!AdminIsLogged)
            {
                return this.FileViewResponse(LoginRedirectLink);
            }

            using (var db = new GameStoreDbContext())
            {
                game = db.Games.FirstOrDefault(x => x.Id == gameId);
            }

            this.ViewData[TitleKey] = game.Title;
            this.ViewData[DescriptionKey] = game.Description;
            this.ViewData[ImageUrlKey] = game.ImageURL;
            this.ViewData[PriceKey] = game.Price.ToString("F2");
            this.ViewData[SizeKey] = game.Size.ToString();
            this.ViewData[TrailerKey] = game.Trailer;
            this.ViewData[ReleaseDateKey] = game.ReleaseDate.ToString("yyyy-MM-dd");

            return this.FileViewResponse(EditGame);
        }

        public IHttpResponse Edit(AdminGameViewModel model)
        {
            if (!this.Authenticate.IsAdmin)
            {
                return this.RedirectResponse(HomePath);
            }
            
            bool isDataValid = ValidateGameInput(model.Title, model.Description, model.ImageUrl, model.Price, model.Size, model.ReleaseDate, model.Trailer);

            if (!isDataValid)
            {
                return this.FileViewResponse(EditGame);
            }

            using (var db = new GameStoreDbContext())
            {
                Game gameToDelete = db.Games.FirstOrDefault(x => x.Id == model.Id);

                gameToDelete.Title = model.Title;
                gameToDelete.Description = model.Description;
                gameToDelete.ImageURL = model.ImageUrl;
                gameToDelete.Price = model.Price;
                gameToDelete.Size = model.Size;
                gameToDelete.Trailer = model.Trailer;
                gameToDelete.ReleaseDate = model.ReleaseDate;
                
                db.SaveChanges();
            }

            return this.RedirectResponse(HomePath);
        }

        public IHttpResponse AdminGames()
        {
            if (!AdminIsLogged)
            {
                return this.FileViewResponse(LoginRedirectLink);
            }

            string tableHeaders = @"<table class=""table table-striped table-hover"">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Name</th>
                        <th>Size</th>
                        <th>Price</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>";

            List<Game> games = new List<Game>();

            using (var db = new GameStoreDbContext())
            {
                games = db.Games.ToList();
            }
            StringBuilder adminGames = new StringBuilder();
            adminGames.AppendLine(tableHeaders);

            int rowIndex = 1;

            foreach (Game game in games)
            {
                if(rowIndex % 2 != 0)
                {
                    adminGames.AppendLine($@"<tr class=""table-warning"">");
                }
                else
                {
                    adminGames.AppendLine($@"<tr>");
                }

                adminGames.AppendLine($@"<th scope=""row"">{rowIndex}</th>
                        <td>{game.Title}</td>
                        <td>{game.Size} GB</td>
                        <td>{game.Price:F2} &euro;</td>
                        <td>
                            <a href=""/edit-game/{game.Id}"" class=""btn btn-warning btn-sm"">Edit</a>
                            <a href=""/delete-game/{game.Id}"" class=""btn btn-danger btn-sm"">Delete</a>
                        </td>
                    </tr>");

                rowIndex++;
            }

            adminGames.AppendLine(@"</tbody>
            </table>");

            this.ViewData["adminGames"] = adminGames.ToString();

            return this.FileViewResponse(AdminGamesConst);
        }
        
        public IHttpResponse GameDetails()
        {
            var id = int.Parse(this.Request.UrlParameters[IdKey]);
             ;
            bool thereIsUserLogged = CheckIfUserIsLogged();


            AdminGameViewModel gameToView = this.gameService.Find(id);

            if (gameToView == default(AdminGameViewModel))
            {
                this.ViewData["error"] = "No such game.";
                this.ViewData["showError"] = "block";
                this.ViewData["authDisplay"] = "none";

                return this.RedirectResponse(HomePath);
            }

            if (!this.ViewData.ContainsKey("error") &&
                !this.ViewData.ContainsKey("showError"))
            {
                this.ViewData["error"] = "none";
                this.ViewData["showError"] = "none";
            }


            this.ViewData[TitleKey] = gameToView.Title;
            this.ViewData[DescriptionKey] = gameToView.Description;
            this.ViewData[ImageUrlKey] = gameToView.ImageUrl;
            this.ViewData[PriceKey] = gameToView.Price.ToString("F2");
            this.ViewData[SizeKey] = gameToView.Size.ToString();
            this.ViewData[TrailerKey] = gameToView.Trailer;
            this.ViewData[ReleaseDateKey] = gameToView.ReleaseDate.ToString("yyyy-MM-dd");
            this.ViewData[GameIdKey] = id.ToString();

            if (AdminIsLogged)
            {
                this.ViewData["adminButtons"] = $@"<a class=""btn btn-warning"" name=""edit"" href=""/edit-game/{id}"">Edit</a>
                <a class=""btn btn-danger"" name=""delete"" href=""/delete-game/{id}"">Delete</a>
                 <a class=""card-button btn btn-primary"" name=""buy"" href=""/add-to-cart/{id}"">Buy</a>";

                this.ViewData["displayUserBtn"] = "none";
                this.ViewData["displayGuestBtn"] = "none";

            }
            else if (GuestUser)
            {
                this.ViewData["guestButtons"] = $@"<a class=""card-button btn btn-primary"" name=""buy"" href=""/login"">Buy</a>";


                this.ViewData["displayAdminBtn"] = "none";
                this.ViewData["displayUserBtn"] = "none";
            }
            else
            {
                this.ViewData["userButtons"] = $@"<a class=""card-button btn btn-primary"" name=""buy"" href=""/add-to-cart/{id}"">Buy</a>";

                this.ViewData["displayAdminBtn"] = "none";
                this.ViewData["displayGuestBtn"] = "none";

            }
            return this.FileViewResponse(DetailGame);
        }
        
        public IHttpResponse AddToCart(IHttpRequest req)
        {
            string userMail = this.Request.Session.Get<string>(SessionStore.CurrentUserKey);
            var gameId = int.Parse(this.Request.UrlParameters["id"]);

            if (!AdminIsLogged && !UserIsLogged)
            {
                return this.FileViewResponse(LoginRedirectLink);
            }

            User user = default(User);
            Game game = default(Game);

            using (var db = new GameStoreDbContext())
            {
                user = db.Users.Include(x => x.ShoppingCart).ThenInclude(x => x.Game)
                    .Include(x => x.Games).ThenInclude(x => x.Game).FirstOrDefault(x => x.Email == userMail);
                
                if (user == default(User))
                {
                    return new NotFoundResponse();
                }

                game = db.Games.FirstOrDefault(x => x.Id == gameId);

                bool gameIsOwnedAlready = user.Games.Any(x => x.GameId == gameId);
                bool gameIsInCartAlready = user.ShoppingCart.Any(x => x.GameId == gameId);
                
                if (gameIsInCartAlready || gameIsOwnedAlready)
                {
                    this.ViewData["showError"] = "block";
                    this.ViewData["error"] = "This game is already added to your cart or your gamelist.";


                    this.ViewData[TitleKey] = game.Title;
                    this.ViewData[DescriptionKey] = game.Description;
                    this.ViewData[ImageUrlKey] = game.ImageURL;
                    this.ViewData[PriceKey] = game.Price.ToString("F2");
                    this.ViewData[SizeKey] = game.Size.ToString();
                    this.ViewData[TrailerKey] = game.Trailer;
                    this.ViewData[ReleaseDateKey] = game.ReleaseDate.ToString("yyyy-MM-dd");

                    return this.GameDetails();
                }

                user.ShoppingCart.Add(new ShoppingCart
                {
                    GameId = game.Id,
                    UserId = user.Id
                });

                db.SaveChanges();
            }

            this.ViewData["showError"] = "inline";
            this.ViewData["error"] = "Added to cart successfully!";


            this.ViewData[TitleKey] = game.Title;
            this.ViewData[DescriptionKey] = game.Description;
            this.ViewData[ImageUrlKey] = game.ImageURL;
            this.ViewData[PriceKey] = game.Price.ToString("F2");
            this.ViewData[SizeKey] = game.Size.ToString();
            this.ViewData[TrailerKey] = game.Trailer;
            this.ViewData[ReleaseDateKey] = game.ReleaseDate.ToString("yyyy-MM-dd");

            return this.GameDetails();
        }

        public IHttpResponse Search(IHttpRequest req)
        {
            int userId = req.Session.Get<int>(SessionStore.CurrentUserKey);

            const string searchTermKey = "searchTerm";

            var urlParameters = req.UrlParameters;

            this.ViewData["results"] = string.Empty;
            this.ViewData["searchTerm"] = string.Empty;

            if (urlParameters.ContainsKey(searchTermKey))
            {
                var searchTerm = urlParameters[searchTermKey];

                this.ViewData["searchTerm"] = searchTerm;

                var savedCakesDivs = new List<string>();

                using (var db = new GameStoreDbContext())
                {
                    if (searchTerm != "*")
                    {
                        var lowerSearchTerm = searchTerm.ToLower();
                        savedCakesDivs = db.Games.Where(cake => cake.Title.ToLower().Contains(lowerSearchTerm))
                        .Select(c =>
                        $@"<div>
                        <a href=""/cake-details/{c.Id}"" target=""_blank"">{c.Title}</a> - ${c.Price:F2} 
                        <a href=""/shopping/add/{c.Id}?searchTerm={searchTerm}"">Order</a>
                    </div>")
                        .ToList();
                    }
                    else
                    {
                        savedCakesDivs = db.Games
                            .Select(c =>
                            $@"<div>
                        <a href=""/cake-details/{c.Id}"" target=""_blank"">{c.Title}</a> - ${c.Price:F2} 
                        <a href=""/shopping/add/{c.Id}?searchTerm={searchTerm}"">Order</a>
                    </div>")
                            .ToList();
                    }
                }
                
                var results = "No cakes found";

                if (savedCakesDivs.Any())
                {
                    results = string.Join(Environment.NewLine, savedCakesDivs);
                }

                this.ViewData["results"] = results;
            }
            else
            {
                this.ViewData["results"] = "Please, enter search term";
            }

            this.ViewData["showCart"] = "none";

            //var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            //if (shoppingCart.Orders.Any())
            //{
            //    var totalProducts = shoppingCart.Orders.Count;
            //    var totalProductsText = totalProducts != 1 ? "products" : "product";

            //    this.ViewData["showCart"] = "block";
            //    this.ViewData["products"] = $"{totalProducts} {totalProductsText}";
            //}

            return this.FileViewResponse(@"cakes\search");
        }

        private bool ValidateGameInput(string title, string description, string imageUrl, decimal price, double size, DateTime releaseDate, string trailer)
        {
            string titlePattern = @"^[A-Z].{3,100}$";

            Regex regex = new Regex(titlePattern);

            if (string.IsNullOrWhiteSpace(title) || !regex.IsMatch(title))
            {
                this.ViewDataErrors[$"{nameof(AdminAddGameViewModel.Title)}Error"] = "Please type valid title.";
                return false;
            }
            if (description.Length < 20)
            {
                this.ViewDataErrors[$"{nameof(AdminAddGameViewModel.Description)}Error"] = "Please type valid description.";
                return false;
            }
            if (price < 0)
            {
                this.ViewDataErrors[$"{nameof(AdminAddGameViewModel.Price)}Error"] = "Please type valid price.";
                return false;
            }
            if (size < 0)
            {
                this.ViewDataErrors[$"{nameof(AdminAddGameViewModel.Size)}Error"] = "Please type valid size.";
                return false;
            }

            if (trailer.Length != 11)
            {
                this.ViewDataErrors[$"{nameof(AdminAddGameViewModel.Trailer)}Error"] = "Please type valid trailer URL.";
                return false;
            }

            if (releaseDate == default(DateTime))
            {
                this.ViewDataErrors[$"{nameof(AdminAddGameViewModel.ReleaseDate)}Error"] = "Please type valid release date.";
                return false;
            }
            int smt = title.Length;
            return true;
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
