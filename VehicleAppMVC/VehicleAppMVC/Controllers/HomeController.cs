using Microsoft.AspNet.Identity;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VehicleAppMVC.Models;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;





namespace VehicleAppMVC.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();


        //CG Removed to use Stripe
        /*
        public ActionResult Index()
        {
            return View();
        }
        */

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // Stripe
        public ActionResult Index()
        {
            //CG added for Stripe
            string stripePublishableKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            var model = new StripeSettings() { StripePublishableKey = stripePublishableKey };

            return View(model);
        }

        //Stripe
        //CG: Copied from ManageController to enable saving of Stripe details within the Chage Controller
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // Stripe 
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Charge( ChargeViewModel chargeViewModel)
        {
            Debug.WriteLine(chargeViewModel.StripeEmail);
            Debug.WriteLine(chargeViewModel.StripeToken);

            if (!ModelState.IsValid)
            {
                return View(chargeViewModel);
            }

            ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());
            user.StripeToken = chargeViewModel.StripeToken;
            user.StripeEmail = chargeViewModel.StripeEmail;
            UserManager.Update(user);
            
                return RedirectToAction("Confirmation");
        }

        /*      //Initial Charge controller method, before it was expanded to save the Token and the email address used
                // Stripe 
                [HttpPost]
                [ValidateAntiForgeryToken()]
                public ActionResult Charge(ChargeViewModel chargeViewModel)
                {
                    Debug.WriteLine(chargeViewModel.StripeEmail);
                    Debug.WriteLine(chargeViewModel.StripeToken);
                    return RedirectToAction("Confirmation");
                }
        */

        public  ActionResult Confirmation()
        {
            return View();
        }
    }
}