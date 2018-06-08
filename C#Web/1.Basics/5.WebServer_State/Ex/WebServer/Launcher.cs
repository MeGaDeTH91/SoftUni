namespace WebServer
{
    using Server.Contracts;
    using Server;
    using Server.Routing.Contracts;
    using Server.Routing;
    using WebServer.ByTheCakeApplication;

    public class Launcher : IRunnable
    {
        private WebServer webServer;

        public static void Main(string[] args)
        {
            new Launcher().Run();
        }

        public void Run()
        {
            IApplication app = new ByTheCakeApplication.ByTheCakeApplication();

            IAppRouteConfig routeConfig = new AppRouteConfig();

            app.Start(routeConfig);

            this.webServer = new WebServer(8457, routeConfig);
            this.webServer.Run();
        }
    }
}
