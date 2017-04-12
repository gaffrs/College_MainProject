using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using VehicleWebApp.Models;

namespace VehicleWebApp.Controllers
{
    public class NotificationsAPIController : ApiController
    {
        private VehicleWebAppContext db = new VehicleWebAppContext();
        // GET: api/NotificationsAPI
        public IList<NotificationDto> GetNotifications()
        {
            var list = db.Notifications.ToList();
            return list.Select(d => new NotificationDto
            {
                NotificationID = d.NotificationID,
                NotificationDate = d.NotificationDate,
                NotificationSendDate = d.NotificationSendDate,
                NotificationType = d.NotificationType,
                NotificationTitle = d.NotificationTitle
            }).ToList();
        }

/*
        //Original Code
        // GET: api/NotificationsAPI
        public IQueryable<Notification> GetNotifications()
        {
            return db.Notifications;
        }
*/

        // GET: api/NotificationsAPI/5
        [ResponseType(typeof(Notification))]
        public async Task<IHttpActionResult> GetNotification(int id)
        {
            Notification notification = await db.Notifications.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }

            return Ok(notification);
        }

        // PUT: api/NotificationsAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNotification(int id, Notification notification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notification.NotificationID)
            {
                return BadRequest();
            }

            db.Entry(notification).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/NotificationsAPI
        [ResponseType(typeof(Notification))]
        public async Task<IHttpActionResult> PostNotification(Notification notification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Notifications.Add(notification);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = notification.NotificationID }, notification);
        }

        // DELETE: api/NotificationsAPI/5
        [ResponseType(typeof(Notification))]
        public async Task<IHttpActionResult> DeleteNotification(int id)
        {
            Notification notification = await db.Notifications.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }

            db.Notifications.Remove(notification);
            await db.SaveChangesAsync();

            return Ok(notification);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NotificationExists(int id)
        {
            return db.Notifications.Count(e => e.NotificationID == id) > 0;
        }
    }
}