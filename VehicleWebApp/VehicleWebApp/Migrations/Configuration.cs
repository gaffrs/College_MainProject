using VehicleWebApp.Models;

namespace VehicleWebApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VehicleWebApp.Models.VehicleWebAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VehicleWebApp.Models.VehicleWebAppContext context)
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

            //Configuration file

/*
//                       // Create a list of customers.
//                       Users = new List<User>()  //strongly typed list of objects that can be accessed by index.
//                       {

            context.Users.AddOrUpdate(u => u.UserID,
                new User { Username = "Colm1", UserPassword = "123456", UserEmailAddress = "Colm@gmail.com", UserMobileNumber = "0871234567", UserType = eUserType.Basic },
                new User { Username = "John1", UserPassword = "234567", UserEmailAddress = "John@gmail.com", UserMobileNumber = "0871111111", UserType = eUserType.PRO },
                new User { Username = "Mick1", UserPassword = "345678", UserEmailAddress = "Mick@gmail.com", UserMobileNumber = "0872222222", UserType = eUserType.Basic }
            );

            // Create a list of vehicles.
            //Vehicles = new List<Vehicle>()  //strongly typed list of objects that can be accessed by index.
            //            {

            context.Vehicles.AddOrUpdate(v => v.VehicleID,
                new Vehicle { UserID = 1, VehicleMake = "Opel", VehicleModel = "Vectra", VehicleRegistrationNumber = "161D171", VehicleOdometerMileage = 1600, SettingFuelType = eSettingFuelType.Petrol, SettingDistance = eSettingDistance.Km, SettingVolume = eSettingVolume.Litres_L, SettingConsumption = eSettingConsumption.Lper100km },
                new Vehicle { UserID = 1, VehicleMake = "Mercedes", VehicleModel = "C-Class", VehicleRegistrationNumber = "161D181", VehicleOdometerMileage = 1300, SettingFuelType = eSettingFuelType.Diesel, SettingDistance = eSettingDistance.Km, SettingVolume = eSettingVolume.Litres_L, SettingConsumption = eSettingConsumption.Lper100km },
                new Vehicle { UserID = 2, VehicleMake = "Subaru", VehicleModel = "Impreza", VehicleRegistrationNumber = "161D200", VehicleOdometerMileage = 2500, SettingFuelType = eSettingFuelType.Petrol, SettingDistance = eSettingDistance.Miles, SettingVolume = eSettingVolume.UK_Gal, SettingConsumption = eSettingConsumption.Mpg_UK },
                new Vehicle { UserID = 2, VehicleMake = "Volkswagen", VehicleModel = "Polo", VehicleRegistrationNumber = "161D250", VehicleOdometerMileage = 1000, SettingFuelType = eSettingFuelType.Petrol, SettingDistance = eSettingDistance.Miles, SettingVolume = eSettingVolume.US_Gal, SettingConsumption = eSettingConsumption.Mpg_US }
);



                        // Create a list of costs.
                        // Costs = new List<Cost>()  //strongly typed list of objects that can be accessed by index.
                        {

            context.Costs.AddOrUpdate(c => c.CostID,
                new Cost { VehicleID = 1, CostDate = new DateTime(2017, 01, 01), CostOdometerMileage = 1000, CostTitle = eCostTitle.Insurance, CostStartDate = new DateTime(2017, 01, 20), CostEndDate = new DateTime(2018, 01, 20) },
                new Cost { VehicleID = 1, CostDate = new DateTime(2017, 05, 01), CostOdometerMileage = 3000, CostTitle = eCostTitle.Service, CostStartDate = new DateTime(2017, 01, 20), CostEndDate = new DateTime(2018, 01, 20) },
                new Cost { VehicleID = 1, CostDate = new DateTime(2017, 06, 01), CostOdometerMileage = 4000, CostTitle = eCostTitle.Tax, CostStartDate = new DateTime(2017, 07, 20), CostEndDate = new DateTime(2018, 07, 20) }
            );

                        // Create a list of Fuelfills.
                        //FuelFills = new List<Fuel>()  //strongly typed list of objects that can be accessed by index.
                        {

            context.Fuels.AddOrUpdate(f => f.FuelID,
                new Fuel { VehicleID = 1, FuelDate = new DateTime(2017, 03, 01), FuelOdometerMileage = 10000, FuelQuantity = 45, FuelUnitPrice = 1.35, FuelPartialFill = false, FuelConsumption = 45555555555555555, FuelCost = 100.35555555555555 },
                new Fuel { VehicleID = 1, FuelDate = new DateTime(2017, 03, 10), FuelOdometerMileage = 10300, FuelQuantity = 40, FuelUnitPrice = 1.45, FuelPartialFill = false, FuelConsumption = 45555555555555555, FuelCost = 100.35555555555555 },
                new Fuel { VehicleID = 1, FuelDate = new DateTime(2017, 03, 24), FuelOdometerMileage = 10600, FuelQuantity = 48, FuelUnitPrice = 1.55, FuelPartialFill = false, FuelConsumption = 45555555555555555, FuelCost = 100.35555555555555 },
                new Fuel { VehicleID = 1, FuelDate = new DateTime(2017, 03, 29), FuelOdometerMileage = 10900, FuelQuantity = 50, FuelUnitPrice = 1.25, FuelPartialFill = false, FuelConsumption = 45555555555555555, FuelCost = 100.35555555555555 },
                new Fuel { VehicleID = 1, FuelDate = new DateTime(2017, 04, 05), FuelOdometerMileage = 11200, FuelQuantity = 55, FuelUnitPrice = 1.15, FuelPartialFill = false, FuelConsumption = 45555555555555555, FuelCost = 100.35555555555555 }

            );

            // Create a list of Notifications.
            //Notifications = new List<Notification>()  //strongly typed list of objects that can be accessed by index.
            //{

            context.Notifications.AddOrUpdate(n => n.NotificationID,
                new Notification { UserID = 1, NotificationDate = new DateTime(2017, 07, 01), NotificationSendDate = new DateTime(2017, 01, 01), NotificationType = eNotificationType.Email, NotificationTitle = eNotificationTitle.MotorTaxDateRenewal },
                new Notification { UserID = 1, NotificationDate = new DateTime(2017, 07, 01), NotificationSendDate = new DateTime(2017, 01, 01), NotificationType = eNotificationType.SMS, NotificationTitle = eNotificationTitle.VehicleTestingDateRenewal },
                new Notification { UserID = 2, NotificationDate = new DateTime(2018, 07, 01), NotificationSendDate = new DateTime(2018, 01, 01), NotificationType = eNotificationType.Email, NotificationTitle = eNotificationTitle.MotorTaxDateRenewal }
            );
            */

        }
    }
}