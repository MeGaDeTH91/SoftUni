namespace HTTPServer.GameStoreApplication
{
    using GameStore.Data;
    using Controllers;
    using Server.Contracts;
    using Server.Routing.Contracts;
    using Microsoft.EntityFrameworkCore;
    using GameStore.Models.ViewModels;
    using System;
    using System.Globalization;

    public class GameStoreAppAppClass : IApplication
    {
        private const string RegisterRoute = @"/register";
        private const string LoginRoute = @"/login";
        private const string ProfileRoute = @"/profile";

        private const string HomeAdminRoute = @"home\admin-home";
        private const string HomeUserRoute = @"home\user-home";
        private const string HomeGuesRoute = @"home\guest-home";

        const string formEmailKey = "email";
        const string formPasswordKey = "password";
        private const string formFullNameKey = "fullName";
        private const string confirmPasswordKey = "confirmPassword";

        public void Configure(IAppRouteConfig appRouteConfig)
        {
            //ConfigureDatabase();

            ConfigureRoutes(appRouteConfig);
        }

        private static void ConfigureRoutes(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig
                .Get(
                    "/register",
                    req => new AccountController(req).Register());

            appRouteConfig
                .Post(
                    "/register",
                    req => new AccountController(req).Register(new RegisterViewModel
                    {
                        Email = req.FormData[formEmailKey],
                        FullName = req.FormData[formFullNameKey],
                        PasswordHash = req.FormData[formPasswordKey],
                        ConfirmPasswordHash = req.FormData[confirmPasswordKey]
                    }));

            appRouteConfig
                .Get(
                    "/login",
                    req => new AccountController(req).Login());

            appRouteConfig
                .Post(
                    "/login",
                    req => new AccountController(req).Login(new LoginViewModel
                    {
                        Email = req.FormData[formEmailKey],
                        Password = req.FormData[formPasswordKey]
                    }));

            appRouteConfig
                .Get(
                "/logout",
                req => new AccountController(req).Logout(req));

            appRouteConfig
                .Get("/", req => new HomeController(req).Index());

            appRouteConfig
                .Get("/owned-games", req => new HomeController(req).OwnedGames());

            appRouteConfig
                .Get("/add-game", req => new GameController(req).Add());

            appRouteConfig
                .Post("/add-game", req => new GameController(req).Add(new AdminAddGameViewModel
                {
                    Title = req.FormData["title"],
                    Description = req.FormData["description"],
                    ImageURL = req.FormData["imageUrl"],
                    Price = decimal.Parse(string.IsNullOrWhiteSpace(req.FormData["price"]) ? "-1" : req.FormData["price"]),
                    Size = double.Parse(string.IsNullOrWhiteSpace(req.FormData["size"]) ? "-1" : req.FormData["size"]),
                    ReleaseDate = string.IsNullOrWhiteSpace(req.FormData["released"]) ? default(DateTime): DateTime.Parse(req.FormData["released"]),
                    Trailer = req.FormData["trailer"]
                }));

            appRouteConfig
                .Get(
                "/delete-game/{(?<id>[0-9]+)}",
                req => new GameController(req).Delete());

            appRouteConfig
                .Post(
                "/delete-game/{(?<id>[0-9]+)}",
                req => new GameController(req).Delete(
                    int.Parse(req.UrlParameters["id"])));

            appRouteConfig
                .Get(
                "/edit-game/{(?<id>[0-9]+)}",
                req => new GameController(req).Edit());

            appRouteConfig
                .Post(
                "/edit-game/{(?<id>[0-9]+)}",
                req => new GameController(req).Edit(
                    new AdminGameViewModel
                    {
                        Id = int.Parse(req.UrlParameters["id"]),
                        Title = req.FormData["title"],
                        Description = req.FormData["description"],
                        ImageUrl = req.FormData["imageUrl"],
                        Trailer = req.FormData["trailer"],
                        ReleaseDate = DateTime.ParseExact(
                                          req.FormData["released"],
                                          "yyyy-MM-dd",
                                          CultureInfo.InvariantCulture),
                        Price = decimal.Parse(req.FormData["price"]),
                        Size = double.Parse(req.FormData["size"]),
                    }));

            appRouteConfig
                .Get("/game-details/{(?<id>[0-9]+)}", req => new GameController(req).GameDetails());

            appRouteConfig
                .Get("/add-to-cart/{(?<id>[0-9]+)}", req => new GameController(req).AddToCart(req));

            appRouteConfig
                .Get("/show-cart", req => new ShoppingController(req).ShowCart());

            appRouteConfig
                .Post("/show-cart", req => new ShoppingController(req).FinishOrder(req));

            appRouteConfig
                .Get("/removeGame/{(?<id>[0-9]+)}", req => new ShoppingController(req).RemoveFromCart(int.Parse(req.UrlParameters["id"])));

            appRouteConfig
                .Get("/admin-games", req => new GameController(req).AdminGames());
        }

        private static void ConfigureDatabase()
        {
            using (var context = new GameStoreDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
            }
        }
    }
}
