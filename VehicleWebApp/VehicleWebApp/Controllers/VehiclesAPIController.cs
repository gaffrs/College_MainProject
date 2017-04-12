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
    public class VehiclesAPIController : ApiController
    {
        private VehicleWebAppContext db = new VehicleWebAppContext();

        // GET: api/VehiclesAPI
        public IList<VehicleDto> GetVehicles()
        {
            var list = db.Vehicles.ToList();
            return list.Select(b => new VehicleDto
            {
                VehicleID = b.VehicleID,
                UserID = b.UserID,
                VehicleMake = b.VehicleMake,
                VehicleModel = b.VehicleModel,
                VehicleRegistrationNumber = b.VehicleRegistrationNumber,
                VehicleOdometerMileage = b.VehicleOdometerMileage,
                SettingFuelType = b.SettingFuelType,
                SettingDistance = b.SettingDistance,
                SettingVolume = b.SettingVolume,
                SettingConsumption = b.SettingConsumption

            }).ToList();
        }

        /*
                //Original Code
                // GET: api/VehiclesAPI
                public IQueryable<Vehicle> GetVehicles()
                {
                    return db.Vehicles;
                }
        */

        // GET: api/VehiclesAPI/5
        [ResponseType(typeof(Vehicle))]
        public async Task<IHttpActionResult> GetVehicle(int id)
        {
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        // PUT: api/VehiclesAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVehicle(int id, Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicle.VehicleID)
            {
                return BadRequest();
            }

            db.Entry(vehicle).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
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

        // POST: api/VehiclesAPI
        [ResponseType(typeof(Vehicle))]
        public async Task<IHttpActionResult> PostVehicle(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vehicles.Add(vehicle);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vehicle.VehicleID }, vehicle);
        }

        // DELETE: api/VehiclesAPI/5
        [ResponseType(typeof(Vehicle))]
        public async Task<IHttpActionResult> DeleteVehicle(int id)
        {
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            db.Vehicles.Remove(vehicle);
            await db.SaveChangesAsync();

            return Ok(vehicle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleExists(int id)
        {
            return db.Vehicles.Count(e => e.VehicleID == id) > 0;
        }
    }
}