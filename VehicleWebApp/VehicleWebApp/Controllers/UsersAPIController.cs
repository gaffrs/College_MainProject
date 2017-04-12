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
//Colm: This manages all the Basic CRUD Operations
{
    public class UsersAPIController : ApiController
    {
        private VehicleWebAppContext db = new VehicleWebAppContext();

        // GET: api/UsersAPI
        public IList<UserDto> GetUsers()
        {
            var list = db.Users.ToList();
            return list.Select(a => new UserDto
            {
                UserID = a.UserID,
                Username = a.Username,
                UserPassword = a.UserPassword,
                UserEmailAddress = a.UserEmailAddress,
                UserMobileNumber = a.UserMobileNumber,
                UserType = a.UserType

            }).ToList();
        }

        /*
                //Original Code
                // GET: api/UsersAPI
                public IQueryable<User> GetUsers()
                {
                    return db.Users;
                }
        */

        // GET: api/UsersAPI/5
        [ResponseType(typeof(UserDto))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            var list = await db.Users.Include(p => p.UserID).Select(a => new UserDto()
            {
                UserID = a.UserID,
                Username = a.Username,
                UserPassword = a.UserPassword,
                UserEmailAddress = a.UserEmailAddress,
                UserMobileNumber = a.UserMobileNumber,
                UserType = a.UserType
            }).SingleOrDefaultAsync(p => p.UserID == id);
            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

/*
                //Original Code
                // GET: api/UsersAPI/5
                [ResponseType(typeof(User))]
                public async Task<IHttpActionResult> GetUser(int id)
                {
                    User user = await db.Users.FindAsync(id);
                    if (user == null)
                    {
                        return NotFound();
                    }

                    return Ok(user);
                }
*/

        // PUT: api/UsersAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserID)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/UsersAPI
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = user.UserID }, user);
        }

        // DELETE: api/UsersAPI/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserID == id) > 0;
        }
    }
}
 