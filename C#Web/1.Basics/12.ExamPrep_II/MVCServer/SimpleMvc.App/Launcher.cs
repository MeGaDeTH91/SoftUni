namespace SimpleMvc.App
{
    using SimpleMvc.Data;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    public class Launcher
    {
        public static void Main(string[] args)
        {
            WebServer server = new WebServer(8000, new ControllerRouter(), new ResourceRouter());

            MeTubeDbContext context = new MeTubeDbContext();

            MvcEngine.Run(server, context);
        }
    }
}
