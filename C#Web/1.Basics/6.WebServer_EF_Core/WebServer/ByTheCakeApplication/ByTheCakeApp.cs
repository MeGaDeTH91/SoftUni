namespace HTTPServer.ByTheCakeApplication
{
    using ByTheCake.Data;
    using Controllers;
    using Server.Contracts;
    using Server.Routing.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class ByTheCakeApp : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            //ConfigureDatabase();

            ConfigureRoutes(appRouteConfig);
        }

        private static void ConfigureRoutes(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig
                .Get("/", req => new HomeController().Index());

            appRouteConfig
                .Get("/about", req => new HomeController().About());

            appRouteConfig
                .Get("/add", req => new CakesController().Add());

            appRouteConfig
                .Post(
                    "/add",
                    req => new CakesController().Add(req));

            appRouteConfig
                .Get(
                    "/search",
                    req => new CakesController().Search(req));

            appRouteConfig
                .Get(
                    "/login",
                    req => new AccountController().Login());

            appRouteConfig
                .Post(
                    "/login",
                    req => new AccountController().Login(req));

            appRouteConfig
                .Get(
                    "/register",
                    req => new AccountController().Register());

            appRouteConfig
                .Post(
                    "/register",
                    req => new AccountController().Register(req));

            appRouteConfig
                .Get(
                    "/my-orders",
                    req => new AccountController().Orders(req));

            appRouteConfig
                .Get(
                    "/orderDetails/{(?<id>[0-9]+)}",
                    req => new AccountController().OrderDetails(req));

            appRouteConfig
                .Post(
                    "/logout",
                    req => new AccountController().Logout(req));

            appRouteConfig
                .Get(
                    "/profile",
                    req => new AccountController().Profile(req));

            appRouteConfig
                .Get(
                    "/shopping/add/{(?<id>[0-9]+)}",
                    req => new ShoppingController().AddToCart(req));
            
            appRouteConfig
                .Get(
                    "/cake-details/{(?<id>[0-9]+)}",
                    req => new CakesController().CakeDetails(req));

            appRouteConfig
                .Get(
                    "/cart",
                    req => new ShoppingController().ShowCart(req));

            appRouteConfig
                .Post(
                    "/shopping/finish-order",
                    req => new ShoppingController().FinishOrder(req));
        }

        private static void ConfigureDatabase()
        {
            using (var context = new ByTheCakeContext())
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
            }
        }
    }
}
