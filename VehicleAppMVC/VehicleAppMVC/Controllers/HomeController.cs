using Microsoft.AspNet.Identity;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VehicleAppMVC.Models;




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

/*
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

        // Stripe 
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Charge(ChargeViewModel chargeViewModel)
        {
            Debug.WriteLine(chargeViewModel.StripeEmail);
            Debug.WriteLine(chargeViewModel.StripeToken);
/*
            if (ModelState.IsValid)
            {

                db.Entry(chargeViewModel).State = System.Data.Entity.EntityState.Modified;
                            //.Users.Add(chargeViewModel.StripeEmail);
                            //db.Users.Add(chargeViewModel.StripeToken);
                db.SaveChangesAsync();
            }
*/
            
                return RedirectToAction("Confirmation");
        }



    public  ActionResult Confirmation()
        {
            return View();
        }


            /*
            //OPTION 1

                    // GET: Stripe GET THE TOKEN
                    private static async Task<string> GetTokenId(ClientModelModel model)
                    {
                        return await System.Threading.Tasks.Task.Run(() =>
                        {
                            var myToken = new StripeTokenCreateOptions
                            {
                                CardAddressCountry = model.CardAddressCountry,
                                CardAddressLine1 = model.CardAddressLine1,
                                CardAddressLine2 = model.CardAddressLine2,
                                CardAddressCity = model.CardAddressCity,
                                CardAddressZip = model.CardAddressZip,
                                CardCvc = model.CardCvc.ToString(CultureInfo.CurrentCulture),
                                CardExpirationMonth = model.CardExpirationMonth,
                                CardExpirationYear = model.CardExpirationYear,
                                CardName = model.CardName,
                                CardNumber = model.CardNumber
                            };

                            var tokenService = new StripeTokenService();
                            var stripeToken = tokenService.Create(myToken);

                            return stripeToken.Id;
                        });
                    }

                    // GET: Stripe MAKE A CHARGE
                    private static async Task<string> ChargeCustomer(string tokenId)
                    {
                        return await System.Threading.Tasks.Task.Run(() =>
                        {
                            var myCharge = new StripeChargeCreateOptions
                            {
                                Amount = 50,
                                Currency = "gbp",
                                Description = "Charge for property sign and postage",
                                TokenId = tokenId
                            };

                            var chargeService = new StripeChargeService();
                            var stripeCharge = chargeService.Create(myCharge);

                            return stripeCharge.Id;
                        });
                    }

                    // GET: Stripe PROCESS THE PAYMENT
                    public async Task<ActionResult> BuySign(BuySignModel model)
                    {
                        var errorMessage = string.Empty;
                        var validationError = string.Empty;
                        var chargeId = string.Empty;

                        if (ModelState.IsValid)
                        {
                            try
                            {
                                var tokenId = await GetTokenId(model);
                                chargeId = await ChargeCustomer(tokenId);
                            }
                            catch (Exception e)
                            {
                                errorMessage = e.Message;
                            }
                        }
                        //...rest of the code omitted for clarity
                    }

                */


            /*
        //OPTION 2
            public IActionResult Charge(string stripeEmail, string stripeToken)
            {
                var customers = new StripeCustomerService();
                var charges = new StripeChargeService();

                var customer = customers.Create(new StripeCustomerCreateOptions
                {
                    Email = stripeEmail,
                    SourceToken = stripeToken
                });

                var charge = charges.Create(new StripeChargeCreateOptions
                {
                    Amount = 500,
                    Description = "Sample Charge",
                    Currency = "usd",
                    CustomerId = customer.Id
                });

                return View();
            }

            public IActionResult Index()
            {
                return View();
            }

            public IActionResult Error()
            {
                return View();
            }

        */
        }
}