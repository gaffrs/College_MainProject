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
    public class NotificationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Notifications
        public async Task<ActionResult> Index()
        {
            var currentUserId = User.Identity.GetUserId();  //CG: Get the UserId of user logged in 
            var notifications = db.Notifications.Where(v => v.ApplicationUserId == currentUserId);    //CG: Edited
            return View(await notifications.ToListAsync());
        }
        /*
        {

            var vehicles = db.Vehicles.Where(v => v.ApplicationUserId == currentUserId);    //CG: Edited
            return View(await vehicles.ToListAsync());
        }*/

        /*      // Original
                // GET: Notifications
                public async Task<ActionResult> Index()
                {
                    var notifications = db.Notifications.Include(n => n.ApplicationUser);
                    return View(await notifications.ToListAsync());
                }
        */

        // GET: Notifications/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notification notification = await db.Notifications.FindAsync(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        // GET: Notifications/Create
        public ActionResult Create()
        {
            var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email").Where(v => v.Value == currentUserId);   //CG: Edited;
            return View();
        }

        /*//Original Code
                // GET: Notifications/Create
                public ActionResult Create()
                {
                    ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email");
                    return View();
                } 
        */


        // POST: Notifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NotificationID,ApplicationUserId,NotificationDate,NotificationSendDate,NotificationType,NotificationTitle")] Notification notification)
        {

            if (notification.NotificationSendDate <= notification.NotificationDate)
            {
                ModelState.AddModelError("NotificationSendDate", "Send Date must be earlier than Notification Date");
            }

            if (notification.NotificationSendDate <= DateTime.Now)
            {
                ModelState.AddModelError("NotificationSendDate", "Send Date must occur after current Date");
            }

            if (ModelState.IsValid)
            {
                db.Notifications.Add(notification);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", notification.ApplicationUserId);
            return View(notification);
        }

        // GET: Notifications/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notification notification = await db.Notifications.FindAsync(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", notification.ApplicationUserId).Where(v => v.Value == currentUserId); //CG: Edited;
            return View(notification);
        }

        /*      //Original Code
                // GET: Notifications/Edit/5
                public async Task<ActionResult> Edit(int? id)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Notification notification = await db.Notifications.FindAsync(id);
                    if (notification == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", notification.ApplicationUserId);
                    return View(notification);
                }        
        */

        // POST: Notifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NotificationID,ApplicationUserId,NotificationDate,NotificationSendDate,NotificationType,NotificationTitle")] Notification notification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notification).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", notification.ApplicationUserId);
            return View(notification);
        }

        // GET: Notifications/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notification notification = await db.Notifications.FindAsync(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Notification notification = await db.Notifications.FindAsync(id);
            db.Notifications.Remove(notification);
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
