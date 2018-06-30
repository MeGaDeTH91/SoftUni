namespace SimpleMvc.App
{
    using SimpleMvc.Data;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using System;
    using WebServer;

    public class Launcher
    {
        public static void Main(string[] args)
        {
            var server = new WebServer(8000, new ControllerRouter(), new ResourceRouter());

            KittenDbContext context = new KittenDbContext();

            MvcEngine.Run(server, context);
        }
    }
}
