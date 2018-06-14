namespace HTTPServer
{
    using HTTPServer.Server;
    using HTTPServer.Server.Routing;
    using HTTPServer.GameStoreApplication;

    public class Launcher
    {
        static void Main(string[] args)
        {
            Run(args);
        }

        static void Run(string[] args)
        {
            //TODO: Initialize application
            var application = new GameStoreAppAppClass();

            var appRouteConfig = new AppRouteConfig();
            //TODO: Configure App Route Configuration
            application.Configure(appRouteConfig);

            var server = new WebServer(8000, appRouteConfig);

            server.Run();
        }
    }
}
