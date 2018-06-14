namespace HTTPServer.GameStoreApplication.Controllers
{
    using Server.Http.Contracts;
    using System.Linq;
    using System;
    using HTTPServer.Server.Http;
    using GameStore.Data;
    using System.Collections.Generic;
    using GameStore.Models;
    using HTTPServer.GameStoreApplication.Services.Contracts;
    using HTTPServer.GameStoreApplication.Services;
    using Microsoft.EntityFrameworkCore;
    using GameStore.GameStoreApplication.Common;
    using System.Text;

    public class ShoppingController : BaseController
    {
        private const string BuyPath = @"\shopping\show-cart";
        private const string BuyPathRedirect = @"\show-cart";
        private const string AddGameToCart = @"/add-to-cart";

        private const string TitleKey = "title";
        private const string DescriptionKey = "description";
        private const string ImageUrlKey = "imageUrl";
        private const string PriceKey = "price";
        private const string SizeKey = "size";
        private const string TrailerKey = "trailer";
        private const string ReleaseDateKey = "released";
        private const string NoItemPrice = "0";

        private bool AdminIsLogged => this.CheckIfAdminIsLogged();
        private bool UserIsLogged => this.CheckIfUserIsLogged();
        private bool GuestUser => this.CheckIfGuestUser();

        private readonly IGameService gameService;
        private readonly IUserService userService;

        public ShoppingController(IHttpRequest request) : base(request)
        {
            this.gameService = new GameService();
            this.userService = new UserService();
        }
        
        public IHttpResponse ShowCart()
        {
            string userEmail = this.Request.Session.Get<string>(SessionStore.CurrentUserKey);

            User user = default(User);

            using (var db = new GameStoreDbContext())
            {
                user = db.Users
                    .Include(x => x.ShoppingCart)
                    .ThenInclude(x => x.Game)
                    .FirstOrDefault(x => x.Email == userEmail);
            }

            bool thereIsUserLoggerd = user != default(User);

            // Get games from db
            List<Game> games = new List<Game>();

            if(thereIsUserLoggerd)
            {
                games = user.ShoppingCart.Select(x => x.Game).ToList();
            }

            // Prepare HTML
            var gamesHtml = new StringBuilder();

            for (int i = 0; i < games.Count; i += 3)
            {
                gamesHtml.AppendLine(@"<div class=""list-group"">");

                var maxGameCount = Math.Min(i + 3, games.Count);
                for (int j = i; j < maxGameCount; j++)
                {
                    var game = games[j];

                    string gameDescription = game.Description.Substring(0, Math.Min(game.Description.Length, ValidationConstants.GameConstraints.DescriptionHomeMaxLength));
                    gamesHtml
                        .AppendLine(@"<div class=""list-group-item"">")
                        .AppendLine(@"<div class=""media"">")
                        .AppendLine($@"<a class=""btn btn-outline-danger btn-lg align-self-center mr-3"" name=""removeGame"" href=""/removeGame/{game.Id}"">X</a>")
                        .AppendLine($@"<img class=""d-flex mr-4 align-self-center img-thumbnail"" height =""127"" src =""https://i.ytimg.com/vi/{game.Trailer}/maxresdefault.jpg""
                                        width =""227"" alt =""Generic placeholder image"">")
                        .AppendLine($@"<div class=""media-body align-self-center"">
                                <a href=""#"">
                                    <h4 class=""mb-1 list-group-item-heading"">{game.Title}</h4>
                                </a>
                                <p>
                                    {game.Description}
                                </p>
                            </div>
                            <div class=""col-md-2 text-center align-self-center mr-auto"">
                                <h2>{game.Price:F2}&euro; </h2>
                            </div>
                        </div>
                    </div>"); 
                }
            }

            var totalPrice = games.Sum(x => x.Price);
            this.ViewData["totalPrice"] = totalPrice.ToString("F2");

            if (games.Count > 0)
            {
                if (!this.ViewData.ContainsKey("showError"))
                {
                    this.ViewData["showError"] = "none";
                }

                this.ViewData["games"] = gamesHtml.ToString();
            }
            else
            {
                if (!this.ViewData.ContainsKey("showError"))
                {
                    this.ViewData["showError"] = "none";
                }

                this.ViewData["games"] = string.Empty;
            }
            
            return this.FileViewResponse(BuyPath);
        }

        public IHttpResponse RemoveFromCart(int gameId)
        {
            string userEmail = this.Request.Session.Get<string>(SessionStore.CurrentUserKey);

            User user = default(User);

            using (var db = new GameStoreDbContext())
            {
                user = db.Users
                    .Include(x => x.ShoppingCart)
                    .ThenInclude(x => x.Game)
                    .FirstOrDefault(x => x.Email == userEmail);

                ShoppingCart gameToRemoveFromCart = user.ShoppingCart.FirstOrDefault(x => x.GameId == gameId && x.UserId == user.Id);

                user.ShoppingCart.Remove(gameToRemoveFromCart);

                db.SaveChanges();
            }

            return this.RedirectResponse(BuyPathRedirect);
        }

        public IHttpResponse FinishOrder(IHttpRequest req)
        {
            string userEmail = this.Request.Session.Get<string>(SessionStore.CurrentUserKey);
            
            User user = default(User);

            HashSet<Game> products = new HashSet<Game>();

            using (var db = new GameStoreDbContext())
            {
                user = db.Users.
                    Include(x => x.ShoppingCart)
                    .ThenInclude(x => x.Game).FirstOrDefault(x => x.Email == userEmail);

                if (user == default(User))
                {
                    this.ViewData["error"] = "Nice try to hack me.";
                    this.ViewData["showError"] = "block";
                    this.ViewData["authDisplay"] = "none";

                    return this.FileViewResponse(@"account\register");
                }

                DateTime exactTime = DateTime.UtcNow;

                var tempCart = user.ShoppingCart.ToList();

                foreach (var cartItem in tempCart)
                {
                    UserGame gameToAdd = new UserGame
                    {
                        GameId = cartItem.GameId,
                        Game = cartItem.Game,
                        UserId = cartItem.UserId,
                        User = cartItem.User
                    };

                    user.Games.Add(gameToAdd);
                    user.ShoppingCart.Remove(cartItem);
                }
                db.SaveChanges();
            }

            this.ViewData["showError"] = "block";
            this.ViewData["error"] = "Thank you for your purchase!";

            this.ViewData["totalPrice"] = NoItemPrice;
            this.ViewData["games"] = string.Empty;

            return this.FileViewResponse(@"shopping\show-cart");
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
