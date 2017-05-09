using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VehicleAppMVC.Models;

using Microsoft.AspNet.Identity;    //CG added

namespace VehicleAppMVC.Controllers
{

    [Authorize]         //CG: added
    public class FuelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Fuels
        public async Task<ActionResult> Index(string sortOrder, string searchString)
        {

        //Add Filtering

            ViewBag.NameSortParmReg = String.IsNullOrEmpty(sortOrder) ? "vehicle_registration_ascending" : "vehicle_registration_descending";                  // "vehicle_registration_descending"
            ViewBag.DateSortParmDate = sortOrder == "Date" ? "date_descending" : "Date";

            var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
            //To return Fuels for Vehicles for ONLY the Logged in User
            var fuels = from s in db.Fuels.Include(f => f.Vehicle).Where(v => v.Vehicle.ApplicationUserId == currentUserId).OrderBy(t => t.VehicleID)    //CG: Edited //.OrderBy(t => t.VehicleID) added to enable fuel consumption calculation.
                        select s;

        //**************************************************
        //CG: added to iterate through the Fuel consumption
        //*****************************************************
        // Iteration 4: Enhanced the calculation:
        // Iterates through the fuel fills (BOTH Full & Partial).
        // Orders by VehicleID, to have all calculations completed for the same vehicle.
        // Consumptions needs at least 1 full fill to commence calculations, below does work for the 1st Vehicle having a Partial fill
        // NEED to adjust code so that the 2nd Vehicle can cope with 1st fill being Full or Empty

            int lastVehicleId = 0;
            int currentVehicleId = 0;

            int lastMileage = 0;          
            int mileageDelta = 0;

            double partialFuelQty = 0;         
            double partialFuelQtyTotal = 0;

            bool firstFullFillComplete = false;         //To ensure user makes initial FULL tank of fuel

            double consumption = 0;

            foreach (var fuel in fuels)
            {
                // Partial Fill & No previous Full fills (Consumption = 0 & No data tracked)
                if ((fuel.FuelPartialFill == true) && (firstFullFillComplete == false))                             
                {
                    consumption = 0;
                }
                else
                {
                
                // Partial Fill & Previous Full fills (Consumption = 0 & FuelQty used tracked)
                if (fuel.FuelPartialFill == true)
                {
                    partialFuelQty = fuel.FuelQuantity;
                    partialFuelQtyTotal += partialFuelQty;
                }

                //Full Fill up
                else
                {
                currentVehicleId = fuel.VehicleID;
                
                // Calculation for Each VehicleID
                if (currentVehicleId != lastVehicleId)                              // Initial Full fill will NOT have a consumption, so consumption = 0
                {
                    consumption = 0;
 /*may need to change these to cope with Vehicle2 starting with Partial Fill*/ firstFullFillComplete = true;                                  // Resets to false for new VehicleID, until user has filled the tank
                }
                else                                                                // Calculate the consumption, based on the delta to previous "Full fill" mileage and "Fuel qty" used 
                {
                    mileageDelta = fuel.FuelOdometerMileage - lastMileage;  
                    consumption = mileageDelta / (fuel.FuelQuantity + partialFuelQtyTotal);
                    partialFuelQtyTotal = 0;                                        // Resets partialFuelQtyTotal attribute to 0 if a full fill has been complete after 1 or many Partial-fills
                    firstFullFillComplete = true;                                   // Indicates the user has made a full fill
                 }                                                                   // Used to set the values for the last vehicle
                    lastVehicleId = fuel.VehicleID;
                    lastMileage = fuel.FuelOdometerMileage;

                    fuel.FuelConsumption = consumption;
                }
            }
            }





            //*****************************************************
            //
            /*//Iteration 1: Initial calculation: NOTE this iterates through the fuel fills BUT does NOT take the VehicleID into account.
            var mileagePrevious = 0;          
            var mileageDelta = 0;
            double consumption = 0;

            foreach (var fuel in fuels)
            {
                if (mileagePrevious == 0)                           //Initial fuel fill will NOT have a consumption
                {
                    consumption = 0;
                }
                else                                                //Calculate the consumption
                {
                    mileageDelta = fuel.FuelOdometerMileage - mileagePrevious;
                    consumption = mileageDelta / fuel.FuelQuantity;
                }
                mileagePrevious = fuel.FuelOdometerMileage;         //Holds a record of the last Odo for the next fuel fill
            }
            */
            //*****************************************************

            //**************************************************
            /* // Iteration 2: Enhanced the calculation: NOTE this iterates through the fuel fills AND takes the VehicleID into account. ****May need to account for Vehicle Order***
                        
            var fuels = from s in db.Fuels.Include(f => f.Vehicle).Where(v => v.Vehicle.ApplicationUserId == currentUserId).OrderBy(t => t.VehicleID)    //CG: Edited //.OrderBy(t => t.VehicleID) added to enable fuel consumption calculation.
            select s;


            var lastVehicleId = 0;
            var currentVehicleId = 0;

            var lastMileage = 0;
            var mileageDelta = 0;
            double consumption = 0;

            foreach (var fuel in fuels)
            {
                currentVehicleId = fuel.VehicleID;
                // Calculation: for Each VehicleID
                if (currentVehicleId != lastVehicleId)                              // Initial fuel fill will NOT have a consumption, so consumption = 0
                {
                    consumption = 0;
                }
                else                                                                // Calculate the consumption, based on the delta to previous mileage and current qty 
                {
                    mileageDelta = fuel.FuelOdometerMileage - lastMileage;
                    consumption = mileageDelta / fuel.FuelQuantity;
                }                                                                   // Used to set the values for the last vehicle
                lastVehicleId = fuel.VehicleID;
                lastMileage = fuel.FuelOdometerMileage;

            }
            */
            //*****************************************************

            /*          //*****************************************************
                        // Iteration 3: Enhanced the calculation: 
                        // Iterates through the fuel fills (BOTH Full & Partial).
                        // Orders by VehicleID, to have all calculations completed for the same vehicle.
                        // Note: Doesn't account for the Vehicle starting with 1 or more partial fills....the Consumptions needs at least 1 full fill to commence calculations.


                        var fuels = from s in db.Fuels.Include(f => f.Vehicle).Where(v => v.Vehicle.ApplicationUserId == currentUserId).OrderBy(t => t.VehicleID)    //CG: Edited //.OrderBy(t => t.VehicleID) added to enable fuel consumption calculation.
                                    select s;



                        int lastVehicleId = 0;
                        int currentVehicleId = 0;

                        int lastMileage = 0;
                        int mileageDelta = 0;

                        double partialFuelQty = 0;
                        double partialFuelQtyTotal = 0;

                        double consumption = 0;

                        foreach (var fuel in fuels)
                        {
                            if (fuel.FuelPartialFill == true)
                            {
                                partialFuelQty = fuel.FuelQuantity;
                                partialFuelQtyTotal += partialFuelQty;
                            }
                            else
                            {

                                currentVehicleId = fuel.VehicleID;
                                // Calculation: for Each VehicleID
                                if (currentVehicleId != lastVehicleId)                              // Initial fuel fill will NOT have a consumption, so consumption = 0
                                {
                                    consumption = 0;
                                }
                                else                                                                // Calculate the consumption, based on the delta to previous mileage and current qty 
                                {


                                    mileageDelta = fuel.FuelOdometerMileage - lastMileage;
                                    consumption = mileageDelta / (fuel.FuelQuantity + partialFuelQtyTotal);
                                    partialFuelQtyTotal = 0;                                        // Resets partialFuelQtyTotal attribute to 0 after Partial-fills calculation
                                }                                                               // Used to set the values for the last vehicle
                                lastVehicleId = fuel.VehicleID;
                                lastMileage = fuel.FuelOdometerMileage;

                                fuel.FuelConsumption = consumption;
                            }
                        }
                        */
            //*****************************************************


            //**************************************************/
            //CG: added to iterate through the Fuel consumption
            //*****************************************************/
            // Iteration 4: Enhanced the calculation:
            // Iterates through the fuel fills (BOTH Full & Partial).
            // Orders by VehicleID, to have all calculations completed for the same vehicle.
            // Consumptions needs at least 1 full fill to commence calculations, below does work for the 1st Vehicle having a Partial fill
            // NEED to adjust code so that the 2nd Vehicle can cope with 1st fill being Full or Empty
            /*

                        var fuels = from s in db.Fuels.Include(f => f.Vehicle).Where(v => v.Vehicle.ApplicationUserId == currentUserId).OrderBy(t => t.VehicleID)    //CG: Edited //.OrderBy(t => t.VehicleID) added to enable fuel consumption calculation.
                                    select s;

                        int lastVehicleId = 0;
                        int currentVehicleId = 0;

                        int lastMileage = 0;          
                        int mileageDelta = 0;

                        double partialFuelQty = 0;         
                        double partialFuelQtyTotal = 0;

                        bool firstFullFillComplete = false;         //To ensure user makes initial FULL tank of fuel

                        double consumption = 0;

                        foreach (var fuel in fuels)
                        {
                            // Partial Fill & No previous Full fills (Consumption = 0 & No data tracked)
                            if ((fuel.FuelPartialFill == true) && (firstFullFillComplete == false))                             
                            {
                                consumption = 0;
                            }
                            else
                            {

                            // Partial Fill & Previous Full fills (Consumption = 0 & FuelQty used tracked)
                            if (fuel.FuelPartialFill == true)
                            {
                                partialFuelQty = fuel.FuelQuantity;
                                partialFuelQtyTotal += partialFuelQty;
                            }

                            //Full Fill up
                            else
                            {
                            currentVehicleId = fuel.VehicleID;

                            // Calculation for Each VehicleID
                            if (currentVehicleId != lastVehicleId)                              // Initial Full fill will NOT have a consumption, so consumption = 0
                            {
                                consumption = 0;

firstFullFillComplete = true;   //may need to change these to cope with Vehicle 2 starting with Partial Fill                               // Resets to false for new VehicleID, until user has filled the tank
        }
                else                                                                // Calculate the consumption, based on the delta to previous "Full fill" mileage and "Fuel qty" used 
                {
                    mileageDelta = fuel.FuelOdometerMileage - lastMileage;  
                    consumption = mileageDelta / (fuel.FuelQuantity + partialFuelQtyTotal);
                    partialFuelQtyTotal = 0;                                        // Resets partialFuelQtyTotal attribute to 0 if a full fill has been complete after 1 or many Partial-fills
                    firstFullFillComplete = true;                                   // Indicates the user has made a full fill
                 }                                                                   // Used to set the values for the last vehicle
                    lastVehicleId = fuel.VehicleID;
                    lastMileage = fuel.FuelOdometerMileage;

                    fuel.FuelConsumption = consumption;
                }
            }
            }

*/
            //*****************************************************






            //Add a Search Box to the Fuel View  (Search by Reg or Year)
            if (!String.IsNullOrEmpty(searchString))
            {
                fuels = fuels.Where(s => s.Vehicle.VehicleRegistrationNumber.ToUpper().Contains(searchString.ToUpper())
                                            ||
                                         s.FuelDate.ToString().Contains(searchString.ToUpper())
                ); ;
            }


            switch (sortOrder)
            {
                case "vehicle_registration_ascending":
                    fuels = fuels.OrderBy(s => s.Vehicle.VehicleRegistrationNumber);
                    break;

                case "vehicle_registration_descending":
                    fuels = fuels.OrderByDescending(s => s.Vehicle.VehicleRegistrationNumber);
                break;

                case "Date":
                    fuels = fuels.OrderBy(s => s.FuelDate);
                    break;

                case "date_descending":
                    fuels = fuels.OrderByDescending(s => s.FuelDate);
                    break;

                default:
                    fuels = fuels.Include(f => f.Vehicle).OrderBy(s => s.VehicleID).ThenBy(s => s.FuelID);      //Default Order by VehicleID then by FuelID
                    break;
            }


            return View(await fuels.ToListAsync());
        }

    /*
    //Original Code
            // GET: Fuels
            public async Task<ActionResult> Index()
            {
                var fuels = db.Fuels.Include(f => f.Vehicle);
                return View(await fuels.ToListAsync());
            }
    */

    // GET: Fuels/Details/5
    public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fuel fuel = await db.Fuels.FindAsync(id);
            if (fuel == null)
            {
                return HttpNotFound();
            }
            return View(fuel);
        }

        // GET: Fuels/Create
        public ActionResult Create()
        {
            var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
            ViewBag.VehicleID = new SelectList(db.Vehicles.Where(v => v.ApplicationUserId == currentUserId), "VehicleID", "VehicleRegistrationNumber");//.Where(db.Vehicles.Include(((v => v.Value == currentUserId)//.Where(v => v.Value == v);   //CG: Edited
            return View();
        }

/*      //Original 
        // GET: Fuels/Create
        public ActionResult Create()
        {
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "ApplicationUserId");
            return View();
        } 
*/

        // POST: Fuels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FuelID,VehicleID,FuelDate,FuelOdometerMileage,FuelQuantity,FuelUnitPrice,FuelPartialFill,FuelConsumption,FuelCost")] Fuel fuel)
        {
            if (ModelState.IsValid)
            {
                db.Fuels.Add(fuel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
            ViewBag.VehicleID = new SelectList(db.Vehicles.Where(v => v.ApplicationUserId == currentUserId), "VehicleID", "VehicleRegistrationNumber", fuel.VehicleID);      //CG: Edited
            //ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "ApplicationUserId", fuel.VehicleID);

            return View(fuel);
        }

        // GET: Fuels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fuel fuel = await db.Fuels.FindAsync(id);
            if (fuel == null)
            {
                return HttpNotFound();
            }
            var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
            ViewBag.VehicleID = new SelectList(db.Vehicles.Where(v => v.ApplicationUserId == currentUserId), "VehicleID", "VehicleRegistrationNumber", fuel.VehicleID);      //CG: Edited
            //ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "ApplicationUserId", fuel.VehicleID); 
            return View(fuel);
        }

        // POST: Fuels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FuelID,VehicleID,FuelDate,FuelOdometerMileage,FuelQuantity,FuelUnitPrice,FuelPartialFill,FuelConsumption,FuelCost")] Fuel fuel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fuel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
            ViewBag.VehicleID = new SelectList(db.Vehicles.Where(v => v.ApplicationUserId == currentUserId), "VehicleID", "VehicleRegistrationNumber", fuel.VehicleID);
            return View(fuel);
        }

        // GET: Fuels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fuel fuel = await db.Fuels.FindAsync(id);
            if (fuel == null)
            {
                return HttpNotFound();
            }
            return View(fuel);
        }

        // POST: Fuels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Fuel fuel = await db.Fuels.FindAsync(id);
            db.Fuels.Remove(fuel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
