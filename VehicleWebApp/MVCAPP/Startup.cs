using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCAPP.Startup))]
namespace MVCAPP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
