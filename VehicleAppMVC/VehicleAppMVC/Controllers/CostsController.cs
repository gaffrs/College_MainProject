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
    public class CostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Costs
        public async Task<ActionResult> Index(string sortOrder, string searchString, DateTime? startDate, DateTime? finishDate)
        {

            //Add Filtering

            ViewBag.NameSortParmReg = String.IsNullOrEmpty(sortOrder) ? "vehicle_registration_ascending" : "vehicle_registration_descending";                  // "vehicle_registration_descending"
            ViewBag.NameSortParmTitle = String.IsNullOrEmpty(sortOrder) ? "cost_title_ascending" : "cost_title_descending";                      // "cost_title_descending"
            ViewBag.DateSortParmDate = sortOrder == "Date" ? "date_descending" : "Date";

            var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
            //To return Costs for Vehicles for ONLY the Logged in User
            var costs = from s in db.Costs.Include(c => c.Vehicle).Where(v => v.Vehicle.ApplicationUserId == currentUserId)    //CG: Edited
            select s;
            
            //Add a Search Box to the Cost View  (Search by Reg or Title or Year)
            if (!String.IsNullOrEmpty(searchString))
            {
                costs = costs.Where(s => s.CostTitle.ToString().Contains(searchString.ToUpper())
                                            ||
                                         s.Vehicle.VehicleRegistrationNumber.ToUpper().Contains(searchString.ToUpper())
                                            ||
                                         s.CostDate.ToString().Contains(searchString.ToUpper())
                ); ;
            }

            //Add a Dynamic Date Range             
            if (((startDate != null)) && ((finishDate != null)))
            {
                costs = costs.Where(s => s.CostDate >= startDate).Where(s => s.CostDate <= finishDate);
            }


            switch (sortOrder)
            {
                case "vehicle_registration_ascending":
                    costs = costs.OrderBy(s => s.Vehicle.VehicleRegistrationNumber);
                    break;

                case "vehicle_registration_descending":
                    costs = costs.OrderByDescending(s => s.Vehicle.VehicleRegistrationNumber);
                    break;

                case "cost_title_ascending":
                    costs = costs.OrderBy(s => s.CostTitle);
                    break;

                case "cost_title_descending":
                    costs = costs.OrderByDescending(s => s.CostTitle);
                    break;

                case "Date":
                    costs = costs.OrderBy(s => s.CostDate);
                    break;

                case "date_descending":
                    costs = costs.OrderByDescending(s => s.CostDate);
                    break;

                default:
                    costs = costs.Include(c => c.Vehicle).OrderBy(s => s.CostDate);
                    break;
            }
            
            return View(await costs.ToListAsync());
        }



/*
//Original Code
        // GET: Costs
        public async Task<ActionResult> Index()
        {
            var costs = db.Costs.Include(c => c.Vehicle);
            return View(await costs.ToListAsync());
        }
*/

        // GET: Costs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cost cost = await db.Costs.FindAsync(id);
            if (cost == null)
            {
                return HttpNotFound();
            }
            return View(cost);
        }

        // GET: Costs/Create
        public ActionResult Create()
        {
            //WORKING reg no.
            var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
            ViewBag.VehicleID = new SelectList(db.Vehicles.Where(v => v.ApplicationUserId == currentUserId), "VehicleID", "VehicleRegistrationNumber");
            return View();
        }

/* // Original Code
        // GET: Costs/Create
        public ActionResult Create()
        {
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "ApplicationUserId");
            return View();
        }
*/

        // POST: Costs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CostID,VehicleID,CostTitle,CostDate,CostOdometerMileage,CostRunningCost,CostStartDate,CostEndDate")] Cost cost)		
		{

            // Validation check to ensure value is > 0 last CostRunningCost
            if (cost.CostRunningCost == 0)
            {
                ModelState.AddModelError("CostRunningCost", "Must be greater than 0");
            }

            // Validation check to ensure value is > 0 last CostOdometerMileage
            if (cost.CostOdometerMileage == 0)
            {
                ModelState.AddModelError("CostOdometerMileage", "Must be greater than 0");
            }

            if (ModelState.IsValid)
            {
                db.Costs.Add(cost);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
            ViewBag.VehicleID = new SelectList(db.Vehicles.Where(v => v.ApplicationUserId == currentUserId), "VehicleID", "VehicleRegistrationNumber", cost.VehicleID);  //CG: Edited
            //ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "ApplicationUserId", cost.VehicleID);

            return View(cost);
        }

        // GET: Costs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cost cost = await db.Costs.FindAsync(id);

            if (cost == null)
            {
                return HttpNotFound();
            }
            var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
            ViewBag.VehicleID = new SelectList(db.Vehicles.Where(v => v.ApplicationUserId == currentUserId), "VehicleID", "VehicleRegistrationNumber", cost.VehicleID);
            return View(cost);
        }

        // POST: Costs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CostID,VehicleID,CostTitle,CostDate,CostOdometerMileage,CostRunningCost,CostStartDate,CostEndDate")] Cost cost)
        {

            // Validation check to ensure value is > 0 last CostRunningCost
            if (cost.CostRunningCost == 0)
            {
                ModelState.AddModelError("CostRunningCost", "Must be greater than 0");
            }

            // Validation check to ensure value is > 0 last CostOdometerMileage
            if (cost.CostOdometerMileage == 0)
            {
                ModelState.AddModelError("CostOdometerMileage", "Must be greater than 0");
            }

            if (ModelState.IsValid)
            {
                db.Entry(cost).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
            ViewBag.VehicleID = new SelectList(db.Vehicles.Where(v => v.ApplicationUserId == currentUserId), "VehicleID", "VehicleRegistrationNumber", cost.VehicleID);
            return View(cost);
        }

        // GET: Costs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cost cost = await db.Costs.FindAsync(id);
            if (cost == null)
            {
                return HttpNotFound();
            }
            return View(cost);
        }

        // POST: Costs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cost cost = await db.Costs.FindAsync(id);
            db.Costs.Remove(cost);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        /*

                    [HttpGet]
                    public ActionResult ChartDataQuery()
                    {


                        var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
                        //To return Costs for Vehicles for ONLY the Logged in User
                        var costs = from s in db.Costs.Include(c => c.Vehicle).Where(v => v.Vehicle.ApplicationUserId == currentUserId).Select( v => v.CostRunningCost).ToArray()    //CG: Edited
                                    select s;

                                return View(costs);
                    }
         */
        /*
        [HttpGet]
        public ActionResult ChartDataQuery()
        {


            var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
                                                               //To return Costs for Vehicles for ONLY the Logged in User
            var costs = from s in db.Costs.Include(c => c.Vehicle).Where(v => v.Vehicle.ApplicationUserId == currentUserId).ToArray()    //CG: Edited
                        select s;

            return View(costs);
        }
        */


        /*//To try get Chart working
        public async Task<ActionResult> ChartDataQuery()
        {

            var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
            //To return Costs for Vehicles for ONLY the Logged in User
            var costs = from s in db.Costs.Include(c => c.Vehicle).Where(v => v.Vehicle.ApplicationUserId == currentUserId)    //CG: Edited
                        select s;

            return View(await costs.ToListAsync());
        }
        */
        /*
                public ActionResult ChartDataQuery()
                {
                    List<string[]> data = new List<string[]>();
                    data.Add(new[] { "Day", "Kasse", "Bonds", "Stocks", "Futures", "Options" });
                    data.Add(new[] { "01.03.", "200", "500", "100", "0", "10" });
                    data.Add(new[] { "01.03.", "300", "450", "150", "50", "30" });
                    data.Add(new[] { "01.03.", "350", "200", "180", "80", "40" });
                    return View(data);
                }
                */
        /*
                public JsonResult ChartDataQuery()
                {
                    List<string[]> data = new List<string[]>();
                    data.Add(new[] { "name", "score" });
                    data.Add(new[] { "xyz", "30" });
                    data.Add(new[] { "aaa", "135", });
                    //return Json(data);
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                */
        /*
                    namespace Kendo.Mvc.Examples.Controllers
            {
                public partial class Line_ChartsController : Controller
                {

                    public ActionResult Index()
                    {
                        return View();
                    }
                }
            }*/


        /*
               public async Task<ActionResult> ChartDataQuery(string sortOrder, string searchString, DateTime? startDate, DateTime? finishDate)
               {
                   var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
                   //To return Costs for Vehicles for ONLY the Logged in User
                   var costs = from s in db.Costs.Include(c => c.Vehicle).Where(v => v.Vehicle.ApplicationUserId == currentUserId)    //CG: Edited
                               select s;

                  return View(await costs.ToListAsync());
               }
       */
        /*
                public async Task<ActionResult> ChartDataQuery(string sortOrder, string searchString, DateTime? startDate, DateTime? finishDate)
                {
                    var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
                                                                       //To return Costs for Vehicles for ONLY the Logged in User
                    var costs = from s in db.Costs.Include(c => c.Vehicle).Where(v => v.Vehicle.ApplicationUserId == currentUserId).Select(s => s.CostRunningCost)    //CG: Edited
                                select s;

                    return View(await costs.ToListAsync());
                }
                */

        /*
                public async Task<ActionResult> ChartDataQuery(string sortOrder, string searchString, DateTime? startDate, DateTime? finishDate)
                {
                    var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
                    //To return Costs for Vehicles for ONLY the Logged in User
                    var costs = from s in db.Costs.Include(c => c.Vehicle).Where(v => v.Vehicle.ApplicationUserId == currentUserId).Select(s => s.CostRunningCost)    //CG: Edited
                                select s;
                    return View(await costs.ToListAsync());
                }
        */
        /*
                public ActionResult ChartDataQuery()

            {

                int[] test = { 3, 5, 6, 7, 8, 9, 0 };
                ViewBag.intArray = test;

                return View();

            }*/

        public async Task<ActionResult> ChartDataQuery(string sortOrder, string searchString, DateTime? startDate, DateTime? finishDate)
        {
            var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
            //To return Costs for Vehicles for ONLY the Logged in User
            var costs = from s in db.Costs.Where(v => v.Vehicle.ApplicationUserId == currentUserId)   //CG: Edited
                        select s;

            return View(await costs.ToListAsync());
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
