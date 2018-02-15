using Microsoft.Owin;
using Owin;
using AspBlog.Migrations;
using AspBlog.Models;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(AspBlog.Startup))]
namespace AspBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BlogDbContext, Configuration>());

            ConfigureAuth(app);
        }
    }
}
