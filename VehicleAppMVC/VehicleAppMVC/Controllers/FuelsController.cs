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

            var fuels = from s in db.Fuels.Include(f => f.Vehicle)
                        select s;
            //Add a Search Box to the Cost View  (Search by Reg or Year)
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
                    fuels = fuels.Include(f => f.Vehicle).OrderBy(s => s.FuelID);
                    break;
            }
/*
//CG: calculation 5th May

            var fuellist = db.Fuels.ToArray();
            foreach (var item in fuellist)
            {
                Fuel
            }
  */              
               
            
             


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
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleRegistrationNumber");//.Where(db.Vehicles.Include(((v => v.Value == currentUserId)//.Where(v => v.Value == v);   //CG: Edited
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
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleRegistrationNumber", fuel.VehicleID);      //CG: Edited
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
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleRegistrationNumber", fuel.VehicleID);      //CG: Edited
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
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleRegistrationNumber", fuel.VehicleID);
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
