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
using VehicleAppMVC.services;
using System.Configuration;
using System.Net.Mail;
using System.Net.Configuration;

namespace VehicleAppMVC.Controllers
{
    [Authorize]         //CG: added
    public class NotificationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Notifications
        public async Task<ActionResult> Index(string sortOrder, string searchString, DateTime? startDate, DateTime? finishDate)
        {
            //var currentUserId = User.Identity.GetUserId();  //CG: Get the UserId of user logged in 
            //var notifications = db.Notifications.Where(v => v.ApplicationUserId == currentUserId);    //CG: Edited

            //Add Filtering
            ViewBag.NameSortParmNotificationTitle = sortOrder == "NotificationTitle_ascending" ? "NotificationTitle_descending" : "NotificationTitle_ascending";               // ViewBag.NameSortParmNotificationTitle = String.IsNullOrEmpty(sortOrder) ? "NotificationTitle_ascending" : "NotificationTitle_descending";  
            ViewBag.NameSortParmNotificationType = sortOrder == "NotificationType_ascending" ? "NotificationType_descending" : "NotificationType_ascending" ;                  // ViewBag.NameSortParmNotificationType = String.IsNullOrEmpty(sortOrder) ? "NotificationType_ascending" : "NotificationType_descending";
            ViewBag.DateSortParmNotificationDate = sortOrder == "NotificationDate_ascending" ? "NotificationDate_descending" : "NotificationDate_ascending";


            var currentUserId = User.Identity.GetUserId();     //CG: Get the UserId of user logged in 
            //To return Notificals for Vehicles for ONLY the Logged in User
            var notifications = from s in db.Notifications.Where(v => v.ApplicationUserId == currentUserId)    //CG: Edited
                                select s;



            //Add a Search Box to the Cost View  (Search by Title, Type or Year)
            if (!String.IsNullOrEmpty(searchString))
            {
                notifications = notifications.Where(s => s.NotificationTitle.ToString().Contains(searchString.ToUpper())
                                            ||
                                         s.NotificationType.ToString().ToUpper().Contains(searchString.ToUpper())
                                            ||
                                         s.NotificationDate.ToString().Contains(searchString.ToUpper())
                ); ;
            }

            //Add a Dynamic Date Range             
            if (((startDate != null)) && ((finishDate != null)))
            {
                notifications = notifications.Where(s => s.NotificationDate >= startDate).Where(s => s.NotificationDate <= finishDate);
            }


            switch (sortOrder)
            {
                case "NotificationTitle_ascending":
                    notifications = notifications.OrderBy(s => s.NotificationTitle);
                    break;

                case "NotificationTitle_descending":
                    notifications = notifications.OrderByDescending(s => s.NotificationTitle);
                    break;

                case "NotificationType_ascending":
                    notifications = notifications.OrderBy(s => s.NotificationType);
                    break;

                case "NotificationType_descending":
                    notifications = notifications.OrderByDescending(s => s.NotificationType);
                    break;

                case "NotificationDate_ascending":
                    notifications = notifications.OrderBy(s => s.NotificationDate);
                    break;

                case "NotificationDate_descending":
                    notifications = notifications.OrderByDescending(s => s.NotificationDate);
                    break;

                default:
                    notifications = notifications.OrderBy(s => s.NotificationID);
                    break;
            }

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

            if (notification.NotificationSendDate >= notification.NotificationDate)
            {
                ModelState.AddModelError("NotificationSendDate", "Send Date must be before Notification Date");
            }

            if (notification.NotificationSendDate <= DateTime.Now)
            {
                ModelState.AddModelError("NotificationSendDate", "Send Date must occur after today");
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
            if (notification.NotificationSendDate >= notification.NotificationDate)
            {
                ModelState.AddModelError("NotificationSendDate", "Send Date must be before Notification Date");
            }

            if (notification.NotificationSendDate <= DateTime.Now)
            {
                ModelState.AddModelError("NotificationSendDate", "Send Date must occur after today");
            }

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

        // GET: Send notifications
        //public ActionResult SendNotifications()
        public ActionResult SendNotifications()

        {
            var today = DateTime.Today;
            var mailMessages = new List<MailMessage>();
            var emailSender = new EmailSender();
            var dueNotifications = db.Notifications.Where(n => n.NotificationSendDate == today && n.NotificationType == eNotificationType.Email).ToList();

            foreach(Notification notification in dueNotifications)
            {
                var mailSettings = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;
                var emailTo = db.Users.Where(u => u.Id == notification.ApplicationUserId).Select(u => u.Email).FirstOrDefault();

                // Create a Mail Message
                var mailMessage = new MailMessage();

                // Receiver’s E-Mail address. 
                mailMessage.To.Add(emailTo);

                // Subject of Email
                mailMessage.Subject = "Reminder " + notification.NotificationTitle;

                mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                mailMessage.Body = "This is a reminder notification about " + notification.NotificationTitle; // Message Body
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.Normal; // Email priority
                mailMessage.From = new MailAddress(mailSettings.From, "my vehicle web app reminder", System.Text.Encoding.UTF8);

                mailMessages.Add(mailMessage);

            }

            // Send Email Asynchronously
            emailSender.SendEmail(mailMessages);

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
