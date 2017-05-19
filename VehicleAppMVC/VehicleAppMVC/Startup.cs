using Microsoft.Owin;
using Owin;
using Stripe;
using System.Configuration;
using System.Web.Services.Description;
using VehicleAppMVC.Models;

[assembly: OwinStartupAttribute(typeof(VehicleAppMVC.Startup))]
namespace VehicleAppMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            //Tutorial
            //StripeConfiguration.SetApiKey(Configuration.GetSection("Stripe")["SecretKey"]);

            ConfigureAuth(app);

        }
    }
}
