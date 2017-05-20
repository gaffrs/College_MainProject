using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
//CG: Added
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System;
using System.ComponentModel;

namespace VehicleAppMVC.Models
{

    public enum eVehicleUnits           //Enum Type
    {                
        [Display(Name = "€ - Km - Litres - L/100Km")] KM,
        [Display(Name = "£ - Miles - UK Gal - UK Mpg")] MilesUK,
        [Display(Name = "$ - Miles - US Gal - US Mpg")] MilesUS
    }


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




        //Navigation Property       //CG added
        /*
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; } //Collection and refers to Notification
        */

        //CG added
        //vehicle Category  
        [Required(ErrorMessage = "Required field")]
        [DisplayName("Vehicle Unit Setting")]
        public eVehicleUnits VehicleUnit { get; set; }

        public string StripeToken { get; set; }
        public string StripeEmail { get; set; }

        //Below Added to get user to fill in settings on registration, so settings are for ALL their vehicles
        /*
                //Units settings
                const string Km = "Km";
                const string Litres = "Litres";
                const string Lper100Km = "L/100Km";

                const string Miles = "Miles";
                const string UK_Gal = "UK Gal";
                const string UK_Mpg = "UK Mpg";

                const string US_Gal = "US Gal";
                const string US_Mpg = "US Mpg";
        */
        /*       
                       //Vehicle category's
                       public static String[] VehicleUnits       //array of Strings
                       {
                           get
                           {
                               return new String[] { "Km - Litres - L/100Km", "Miles - UK Gal - UK Mpg", "Miles - US Gal - US Mpg" };
                           }

                       }

               //vehicle Category  
               [Required(ErrorMessage = "Required field")]
               [DisplayName("Vehicle Unit Setting")]
               public String VehicleUnit { get; set; }
         */




    }
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>    //Original code
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