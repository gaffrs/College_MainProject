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
        public async Task<ActionResult> Index()
        {
            var costs = db.Costs.Include(c => c.Vehicle);
            return View(await costs.ToListAsync());
        }

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
            var currentUserId =  User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleRegistrationNumber");//.Where(db.Vehicles.Include(((v => v.Value == currentUserId)//.Where(v => v.Value == v);   //CG: Edited
            return View();       
        }

            //ViewBag.VehicleIDModel = new SelectList(db.Vehicles, "VehicleID", "VehicleModel");
            //try putting in an .Include(n => n.ApplicationUser);

            /*var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
var currentVehicleId = new SelectList(db.Users, "Id", "Email").Where(v => v.Value == currentUserId);   //CG: Edited

var viewModel = new List<>
*/
            /*
            var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
            ViewBag.VehicleIDMake = new SelectList(db.Vehicles, "VehicleID", "VehicleRegistrationNumber").Include((db.Users, "Id", "Email").Where(v => v.Value == currentUserId));//.Where(db.Vehicles.Include(((v => v.Value == currentUserId)//.Where(v => v.Value == v);   //CG: Edited
            */

        /*//Working Make & Model
        public ActionResult Create()
        {
            var currentUserId =  User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
            ViewBag.VehicleIDMake = new SelectList(db.Vehicles, "VehicleID", "VehicleMake");//.Where(db.Vehicles.Include(((v => v.Value == currentUserId)//.Where(v => v.Value == v);   //CG: Edited
            ViewBag.VehicleIDModel = new SelectList(db.Vehicles, "VehicleID", "VehicleModel");
            return View(new Vehicle());            
        }  
        */


//var currentVehicleId = new List(currentUserId.where(currentUserId
//var currentVehicleId = db.Vehicles.Where(v => v.ApplicationUserId == currentUserId);
//ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleID");//.Where(v => v.Value == currentUserId);   //CG: Edited
//ViewBag.VehicleIDMake = new SelectList(db.Vehicles, "VehicleID", "VehicleMake");//.Where(v => v.Value == currentUserId);   //CG: Edited
//ViewBag.VehicleIDModel = new SelectList(db.Vehicles, "VehicleID", "VehicleModel");



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
        public async Task<ActionResult> Create([Bind(Include = "CostID,VehicleID,CostDate,CostOdometerMileage,CostTitle,CostRunningCost,CostStartDate,CostEndDate")] Cost cost)
        {
            if (ModelState.IsValid)
            {
                db.Costs.Add(cost);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleRegistrationNumber", cost.VehicleID);  //CG: Edited
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
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleRegistrationNumber", cost.VehicleID);
            return View(cost);
        }

        // POST: Costs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CostID,VehicleID,CostDate,CostOdometerMileage,CostTitle,CostRunningCost,CostStartDate,CostEndDate")] Cost cost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cost).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleRegistrationNumber", cost.VehicleID);
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
