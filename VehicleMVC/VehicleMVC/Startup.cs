using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VehicleMVC.Startup))]
namespace VehicleMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
