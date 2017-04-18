namespace VehicleAppMVC.Migrations.ApplicationDbMigration
{
    using Microsoft.AspNet.Identity;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VehicleAppMVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ApplicationDbMigration";
        }

        protected override void Seed(VehicleAppMVC.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            /*
                        var hasher = new PasswordHasher();
                        context.Users.AddOrUpdate(u => u.UserName,
                        new ApplicationUser { UserName = "colm@gmail.com", Email = "colm@gmail.com", PhoneNumber = "0871234567", PasswordHash = hasher.HashPassword("$Password1") },
                        new ApplicationUser { UserName = "paul@gmail.com", Email = "paul@gmail.com", PhoneNumber = "0871234568", PasswordHash = hasher.HashPassword("$Password1") },
                        new ApplicationUser { UserName = "john@gmail.com", Email = "john@gmail.com", PhoneNumber = "0871234569", PasswordHash = hasher.HashPassword("$Password1") }
                        );
                        */
            context.Vehicles.AddOrUpdate(v => v.VehicleID,
  new Vehicle { Email = "colm@gmail.com", VehicleMake = "Opel", VehicleModel = "Vectra", VehicleRegistrationNumber = "161D171", VehicleOdometerMileage = 1600, SettingFuelType = eSettingFuelType.Petrol, SettingDistance = eSettingDistance.Km, SettingVolume = eSettingVolume.Litres_L, SettingConsumption = eSettingConsumption.Lper100km },
  new Vehicle { Email = "colm@gmail.com", VehicleMake = "Mercedes", VehicleModel = "C-Class", VehicleRegistrationNumber = "161D181", VehicleOdometerMileage = 1300, SettingFuelType = eSettingFuelType.Diesel, SettingDistance = eSettingDistance.Km, SettingVolume = eSettingVolume.Litres_L, SettingConsumption = eSettingConsumption.Lper100km },
  new Vehicle { Email = "paul@gmail.com", VehicleMake = "Subaru", VehicleModel = "Impreza", VehicleRegistrationNumber = "161D200", VehicleOdometerMileage = 2500, SettingFuelType = eSettingFuelType.Petrol, SettingDistance = eSettingDistance.Miles, SettingVolume = eSettingVolume.UK_Gal, SettingConsumption = eSettingConsumption.Mpg_UK },
  new Vehicle { Email = "paul@gmail.com", VehicleMake = "Volkswagen", VehicleModel = "Polo", VehicleRegistrationNumber = "161D250", VehicleOdometerMileage = 1000, SettingFuelType = eSettingFuelType.Petrol, SettingDistance = eSettingDistance.Miles, SettingVolume = eSettingVolume.US_Gal, SettingConsumption = eSettingConsumption.Mpg_US }
  );
        }
    }
}
