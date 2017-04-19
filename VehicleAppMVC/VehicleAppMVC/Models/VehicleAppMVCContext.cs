using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace VehicleAppMVC.Models
{
    public class VehicleAppMVCContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public VehicleAppMVCContext() : base("DefaultConnection")
        {
        }

        public DbSet<VehicleAppMVC.Models.User> Users { get; set; }
        public DbSet<VehicleAppMVC.Models.Vehicle> Vehicles { get; set; }
        public DbSet<VehicleAppMVC.Models.Cost> Costs { get; set; }
        public DbSet<VehicleAppMVC.Models.Fuel> Fuels { get; set; }
        public DbSet<VehicleAppMVC.Models.Notification> Notifications { get; set; }

        //public DbSet<ApplicationUser> ApplicationUser { get; set; }

        //public System.Data.Entity.DbSet<VehicleAppMVC.Models.User> Users { get; set; }

        //public System.Data.Entity.DbSet<VehicleAppMVC.Models.Vehicle> Vehicles { get; set; }
        /*
                protected override void OnModelCreating(DbModelBuilder modelBuilder)
                {
                    base.OnModelCreating(modelBuilder);
                    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                }
        */
        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //one-to-many 
            modelBuilder.Entity<User>()
                        .HasRequired<ApplicationUser>(s => s.ApplicationUsers)
                        .WithMany(s => s.Users)
                        .HasForeignKey(s => s.);

        }
*/
    }

}
