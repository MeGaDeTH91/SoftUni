using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookLib.Startup))]
namespace BookLib
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
