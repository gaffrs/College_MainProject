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
    public class CostsAPIController : ApiController
    {
        private VehicleWebAppContext db = new VehicleWebAppContext();

        // GET: api/CostsAPI
        public IList<CostDto> GetCosts()
        {
            var list = db.Costs.ToList();
            return list.Select(c => new CostDto
            {
                CostID = c.CostID,
                VehicleID = c.VehicleID,
                CostDate = c.CostDate,
                CostOdometerMileage = c.CostOdometerMileage,
                CostTitle = c.CostTitle,
                //CostRunningCost = c.CostRunningCost,
                CostStartDate = c.CostStartDate,
                CostEndDate = c.CostEndDate
            }).ToList();
        }

/*
        //Original Code
        // GET: api/CostsAPI
        public IQueryable<Cost> GetCosts()
        {
            return db.Costs;
        }
*/

        // GET: api/CostsAPI/5
        [ResponseType(typeof(CostDto))]
        public async Task<IHttpActionResult> GetCost(int id)
        {
            var list = await db.Costs.Include(p => p.CostID).Select(c => new CostDto()
            {
                CostID = c.CostID,
                VehicleID = c.VehicleID,
                CostDate = c.CostDate,
                CostOdometerMileage = c.CostOdometerMileage,
                CostTitle = c.CostTitle,
                CostRunningCost = c.CostRunningCost,
                CostStartDate = c.CostStartDate,
                CostEndDate = c.CostEndDate
            }).SingleOrDefaultAsync(p => p.CostID == id);
            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        /*
                // GET: api/CostsAPI/5
                [ResponseType(typeof(Cost))]
                public async Task<IHttpActionResult> GetCost(int id)
                {
                    Cost cost = await db.Costs.FindAsync(id);
                    if (cost == null)
                    {
                        return NotFound();
                    }

                    return Ok(cost);
                }
        */

        // PUT: api/CostsAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCost(int id, Cost cost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cost.CostID)
            {
                return BadRequest();
            }

            db.Entry(cost).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CostExists(id))
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

        // POST: api/CostsAPI
        [ResponseType(typeof(Cost))]
        public async Task<IHttpActionResult> PostCost(Cost cost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Costs.Add(cost);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cost.CostID }, cost);
        }

        // DELETE: api/CostsAPI/5
        [ResponseType(typeof(Cost))]
        public async Task<IHttpActionResult> DeleteCost(int id)
        {
            Cost cost = await db.Costs.FindAsync(id);
            if (cost == null)
            {
                return NotFound();
            }

            db.Costs.Remove(cost);
            await db.SaveChangesAsync();

            return Ok(cost);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CostExists(int id)
        {
            return db.Costs.Count(e => e.CostID == id) > 0;
        }
    }
}