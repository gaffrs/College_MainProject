using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VehicleWebApp.Models;

namespace VehicleWebApp.Controllers
{
    public class FuelsAPIController : ApiController
    {
        private VehicleWebAppContext db = new VehicleWebAppContext();

        // GET: api/FuelsAPI
        public IList<FuelDto> GetFuels()
        {
            var list = db.Fuels.ToList();
            return list.Select(e => new FuelDto
            {
                FuelID = e.FuelID,
                FuelDate = e.FuelDate,
                FuelOdometerMileage = e.FuelOdometerMileage,
                FuelQuantity = e.FuelQuantity,
                FuelUnitPrice = e.FuelUnitPrice,
                FuelPartialFill = e.FuelPartialFill
            }).ToList();
        }
/*
 *      // Original Code
        // GET: api/FuelsAPI
        public IQueryable<Fuel> GetFuels()
        {
            return db.Fuels;
        }
*/


    // GET: api/FuelsAPI/5
    [ResponseType(typeof(Fuel))]
        public IHttpActionResult GetFuel(int id)
        {
            Fuel fuel = db.Fuels.Find(id);
            if (fuel == null)
            {
                return NotFound();
            }

            return Ok(fuel);
        }

        // PUT: api/FuelsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFuel(int id, Fuel fuel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fuel.FuelID)
            {
                return BadRequest();
            }

            db.Entry(fuel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuelExists(id))
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

        // POST: api/FuelsAPI
        [ResponseType(typeof(Fuel))]
        public IHttpActionResult PostFuel(Fuel fuel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fuels.Add(fuel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fuel.FuelID }, fuel);
        }

        // DELETE: api/FuelsAPI/5
        [ResponseType(typeof(Fuel))]
        public IHttpActionResult DeleteFuel(int id)
        {
            Fuel fuel = db.Fuels.Find(id);
            if (fuel == null)
            {
                return NotFound();
            }

            db.Fuels.Remove(fuel);
            db.SaveChanges();

            return Ok(fuel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FuelExists(int id)
        {
            return db.Fuels.Count(e => e.FuelID == id) > 0;
        }
    }
}