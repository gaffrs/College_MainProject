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
    public class VehiclesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Vehicles
        public async Task<ActionResult> Index()
        {
            var currentUserId = User.Identity.GetUserId();  //CG: Get the UserId of user logged in 
            var vehicles = db.Vehicles.Where(v => v.ApplicationUserId == currentUserId);    //CG: Edited
            return View(await vehicles.ToListAsync());
        }

        /*
         * Debugging
        // GET: Vehicles
        public async Task<ActionResult> Index()
        {
            var currentUserId = User.Identity.GetUserId();  //CG: Get the UserId of user logged in 
            var vehicles = await db.Vehicles.Where(v => v.ApplicationUserId == currentUserId).ToListAsync();    //CG: Edited
            foreach (var item in vehicles)
            {
                //item.SettingVolume =  item.SettingVolume.ToString();
            }
            return View(vehicles);
        }
        */

        /* Original
         
        // GET: Vehicles
        public async Task<ActionResult> Index()
        {
            var vehicles = db.Vehicles.Include(v => v.ApplicationUser);
            return View(await vehicles.ToListAsync());
        } 
         */

        // GET: Vehicles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }


        // GET: Vehicles/Create
        public ActionResult Create()
        {
            var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email").Where(v => v.Value == currentUserId);   //CG: Edited
            return View();
        }


        /*      //Original Code
                // GET: Vehicles/Create
                public ActionResult Create()
                {
                    ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email");
                    return View();
                }
        */

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VehicleID,ApplicationUserId,VehicleMake,VehicleModel,VehicleRegistrationNumber,VehicleOdometerMileage,SettingFuelType,SettingDistance,SettingVolume,SettingConsumption")] Vehicle vehicle)
        {
/*
            var currentUserId = User.Identity.GetUserId();            //CG: Get the UserId of user logged in 
            var vehicles = db.Vehicles.Where(v => v.ApplicationUserId == currentUserId).ToList();

            // Validation check to ensure Registration Number has not been already used on Create
            var previousVehicleRegistrationNumber = vehicles.Select(x => x.VehicleRegistrationNumber).ToList();

            if (vehicle.VehicleRegistrationNumber.Equals(previousVehicleRegistrationNumber))
            {
                ModelState.AddModelError("VehicleRegistrationNumber", "Registration Number already exists");
            }
*/

            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", vehicle.ApplicationUserId);
            return View(vehicle);
        }


    // GET: Vehicles/Edit/5
    public async Task<ActionResult> Edit(int? id)
        {
            var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", vehicle.ApplicationUserId).Where(v => v.Value == currentUserId); //CG: Edited
            return View(vehicle);
        }
/*  //Original Code
        // GET: Vehicles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", vehicle.ApplicationUserId);
            return View(vehicle);
        }
*/


        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VehicleID,ApplicationUserId,VehicleMake,VehicleModel,VehicleRegistrationNumber,VehicleOdometerMileage,SettingFuelType,SettingDistance,SettingVolume,SettingConsumption")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", vehicle.ApplicationUserId);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            db.Vehicles.Remove(vehicle);
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
