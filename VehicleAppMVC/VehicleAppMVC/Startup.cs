using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VehicleAppMVC.Startup))]
namespace VehicleAppMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
