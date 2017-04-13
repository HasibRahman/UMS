using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StationaryManagement.Startup))]
namespace StationaryManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
