namespace SoftUni.WebServer.App
{
    using Microsoft.EntityFrameworkCore;
    using SoftUni.WebServer.Data;
    using SoftUni.WebServer.Mvc;
    using SoftUni.WebServer.Mvc.Routers;
    using SoftUni.WebServer.Server;

    public class Launcher
    {
        public static void Main(string[] args)
        {
            WebServer server = new WebServer(8000, new ControllerRouter(), new ResourceRouter());

            ChushkaDbContext context = new ChushkaDbContext();

            ConfigureDataBase(context);

            MvcEngine.Run(server);
        }

        private static void ConfigureDataBase(ChushkaDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
