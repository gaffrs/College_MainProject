using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
//CG: Added
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc

namespace VehicleAppMVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual List<Vehicle> Vehicles { get; set; }          //Collection and refers to Vehicle
        public virtual List<Notification> Notifications { get; set; }//Collection and refers to Notification


        //public virtual User User { get; set; }

        //CG: added 
        //[ForeignKey("Users")]
        //public int UserId { get; set; }

        /*
        [ForeignKey("VehicleID")]
        public int VehicleID { get; set; }
        [ForeignKey("NotificationID")]
        public int NotificationID { get; set; }
        */

        //Navigation Property       //CG added
        /*
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; } //Collection and refers to Notification
        */

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }

                public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }

        //Navigation Property of Model Classes
        public DbSet<VehicleAppMVC.Models.Vehicle> Vehicles { get; set; }
        public DbSet<VehicleAppMVC.Models.Cost> Costs { get; set; }
        public DbSet<VehicleAppMVC.Models.Fuel> Fuels { get; set; }
        public DbSet<VehicleAppMVC.Models.Notification> Notifications { get; set; }

        /*
                //CG NEW 20/04/17
                protected override void OnModelCreating(DbModelBuilder modelBuilder)
                {
                    base.OnModelCreating(modelBuilder);

                    // one-to-zero or one relationship between ApplicationUser and Customer
                    // UserId column in Customers table will be foreign key
                    modelBuilder.Entity<ApplicationUser>()
                        .HasOptional(m => m.User)
                        .WithRequired(m => m.ApplicationUser)
                        .Map(p => p.MapKey("UserId"));
                }
        */


        /* 
         //CG:18/04/17
         public System.Data.Entity.DbSet<VehicleAppMVC.Models.Vehicle> Vehicles { get; set; }
         public System.Data.Entity.DbSet<VehicleAppMVC.Models.Cost> Costs { get; set; }
         public System.Data.Entity.DbSet<VehicleAppMVC.Models.Fuel> Fuels { get; set; }
         public System.Data.Entity.DbSet<VehicleAppMVC.Models.Notification> Notifications { get; set; }
         */



    }
}