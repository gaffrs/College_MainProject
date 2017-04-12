using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


using System.Data.Entity.ModelConfiguration.Conventions;    //CG: Added to remove Pluralisation from Table names
        
namespace VehicleWebApp.Models
{
    public class VehicleWebAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public VehicleWebAppContext() : base("name=VehicleWebAppContext")
        {
        }

        //CG: Added to remove Pluralisation from Table names
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<VehicleWebApp.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<VehicleWebApp.Models.Vehicle> Vehicles { get; set; }

        public System.Data.Entity.DbSet<VehicleWebApp.Models.Cost> Costs { get; set; }

        public System.Data.Entity.DbSet<VehicleWebApp.Models.Fuel> Fuels { get; set; }

        public System.Data.Entity.DbSet<VehicleWebApp.Models.Notification> Notifications { get; set; }
    }
}
