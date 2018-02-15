using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TODOList.Startup))]
namespace TODOList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
