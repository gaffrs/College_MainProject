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

namespace VehicleAppMVC.Controllers
{
    public class Costs1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Costs1
        public async Task<ActionResult> Index()
        {
            var costs = db.Costs.Include(c => c.Vehicle);
            return View(await costs.ToListAsync());
        }

        // GET: Costs1/Details/5
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

        // GET: Costs1/Create
        public ActionResult Create()
        {
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "ApplicationUserId");
            return View();
        }

        // POST: Costs1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CostID,VehicleID,CostTitle,CostDate,CostOdometerMileage,CostRunningCost,CostStartDate,CostEndDate")] Cost cost)
        {
            if (ModelState.IsValid)
            {
                db.Costs.Add(cost);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "ApplicationUserId", cost.VehicleID);
            return View(cost);
        }

        // GET: Costs1/Edit/5
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
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "ApplicationUserId", cost.VehicleID);
            return View(cost);
        }

        // POST: Costs1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CostID,VehicleID,CostTitle,CostDate,CostOdometerMileage,CostRunningCost,CostStartDate,CostEndDate")] Cost cost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cost).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "ApplicationUserId", cost.VehicleID);
            return View(cost);
        }

        // GET: Costs1/Delete/5
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

        // POST: Costs1/Delete/5
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
