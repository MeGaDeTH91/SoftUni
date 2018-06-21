namespace SimpleMvc.App
{
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.Data;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    public class Launcher
    {
        static void Main(string[] args)
        {
            ConfigureDatabase();

            var server = new WebServer(8000, new ControllerRouter(), new ResourceRouter());

            while (true)
            {
                MvcEngine.Run(server);
            }
        }

        private static void ConfigureDatabase()
        {
            using(var db = new NotesDbContext())
            {
                //db.Database.EnsureDeleted();
                db.Database.Migrate();
            }
        }
    }
}
