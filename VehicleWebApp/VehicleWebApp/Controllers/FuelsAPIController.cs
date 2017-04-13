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
                VehicleID = e.VehicleID,
                FuelDate = e.FuelDate,
                FuelOdometerMileage = e.FuelOdometerMileage,
                FuelQuantity = e.FuelQuantity,
                FuelUnitPrice = e.FuelUnitPrice,
                FuelPartialFill = e.FuelPartialFill
            }).ToList();
        }

        /*
                //Original Code
                // GET: api/FuelsAPI
                public IQueryable<Fuel> GetFuels()
                {
                    return db.Fuels;
                }
        */

        // GET: api/FuelsAPI/5
        [ResponseType(typeof(FuelDto))]
        public async Task<IHttpActionResult> GetFuel(int id)
        {
            Fuel fuel = await db.Fuels.FindAsync(id);
            var list = await db.Fuels.Include(p => p.FuelID).Select(e => new FuelDto()
            {
                FuelID = e.FuelID,
                VehicleID = e.VehicleID,
                FuelDate = e.FuelDate,
                FuelOdometerMileage = e.FuelOdometerMileage,
                FuelQuantity = e.FuelQuantity,
                FuelUnitPrice = e.FuelUnitPrice,
                FuelPartialFill = e.FuelPartialFill
            }).SingleOrDefaultAsync(p => p.FuelID == id);
            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        /*
                //Original Code 
                // GET: api/FuelsAPI/5
                [ResponseType(typeof(Fuel))]
                public async Task<IHttpActionResult> GetFuel(int id)
                {
                    Fuel fuel = await db.Fuels.FindAsync(id);
                    if (fuel == null)
                    {
                        return NotFound();
                    }

                    return Ok(fuel);
                }
        */

        // PUT: api/FuelsAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFuel(int id, Fuel fuel)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostFuel(Fuel fuel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fuels.Add(fuel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = fuel.FuelID }, fuel);
        }

        // DELETE: api/FuelsAPI/5
        [ResponseType(typeof(Fuel))]
        public async Task<IHttpActionResult> DeleteFuel(int id)
        {
            Fuel fuel = await db.Fuels.FindAsync(id);
            if (fuel == null)
            {
                return NotFound();
            }

            db.Fuels.Remove(fuel);
            await db.SaveChangesAsync();

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