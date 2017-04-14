using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VehicleWebAppMVC.Startup))]
namespace VehicleWebAppMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
