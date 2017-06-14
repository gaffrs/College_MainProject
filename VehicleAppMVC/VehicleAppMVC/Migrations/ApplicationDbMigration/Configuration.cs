namespace VehicleAppMVC.Migrations.ApplicationDbMigration
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VehicleAppMVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //CG added due to Azure error
            AutomaticMigrationDataLossAllowed = true;
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
            //Create a list of Vehicles (x1 Users)

            context.Vehicles.AddOrUpdate(v => v.VehicleID,
               new Vehicle { ApplicationUserId = "8ad230ab-0758-4066-952b-e0f163c648f4", VehicleMake = "Paul Subaru", VehicleModel = "Paul Impreza", VehicleRegistrationNumber = "Paul1", VehicleOdometerMileage = 500, SettingFuelType = eSettingFuelType.Petrol },  //User Colm 
               new Vehicle { ApplicationUserId = "8ad230ab-0758-4066-952b-e0f163c648f4", VehicleMake = "Paul Volkswagen", VehicleModel = "Paul Polo", VehicleRegistrationNumber = "Paul2", VehicleOdometerMileage = 1500, SettingFuelType = eSettingFuelType.Petrol } //User Colm 
             );



            //Create a list of Notifications (x1 Users)


            context.Notifications.AddOrUpdate(n => n.NotificationID,
                 new Notification { ApplicationUserId = "8ad230ab-0758-4066-952b-e0f163c648f4", NotificationDate = new DateTime(2018, 2, 28), NotificationSendDate = new DateTime(2018, 2, 20), NotificationType = eNotificationType.Email, NotificationTitle = eNotificationTitle.InsuranceDateRenewal },        //User Colm
                 new Notification { ApplicationUserId = "8ad230ab-0758-4066-952b-e0f163c648f4", NotificationDate = new DateTime(2018, 10, 01), NotificationSendDate = new DateTime(2018, 09, 20), NotificationType = eNotificationType.SMS, NotificationTitle = eNotificationTitle.MotorTaxDateRenewal }           //User Colm
             );

            //Create a list of Costs

            context.Costs.AddOrUpdate(c => c.CostID,
            new Cost { VehicleID = 1, CostDate = new DateTime(2017, 3, 01), CostOdometerMileage = 500, CostTitle = eCostTitle.Insurance, CostRunningCost = 700 },   //User Colm Vehicle 1
            new Cost { VehicleID = 1, CostDate = new DateTime(2017, 8, 01), CostOdometerMileage = 3000, CostTitle = eCostTitle.Service, CostRunningCost = 400 },    //User Colm Vehicle 1
            new Cost { VehicleID = 1, CostDate = new DateTime(2017, 10, 01), CostOdometerMileage = 4000, CostTitle = eCostTitle.Tax, CostRunningCost = 250 },       //User Colm Vehicle 1
            new Cost { VehicleID = 2, CostDate = new DateTime(2017, 3, 01), CostOdometerMileage = 1500, CostTitle = eCostTitle.Insurance, CostRunningCost = 1500 },   //User Colm Vehicle 2
            new Cost { VehicleID = 2, CostDate = new DateTime(2017, 8, 01), CostOdometerMileage = 4000, CostTitle = eCostTitle.Service, CostRunningCost = 1000 },    //User Colm Vehicle 2
            new Cost { VehicleID = 2, CostDate = new DateTime(2017, 10, 01), CostOdometerMileage = 5000, CostTitle = eCostTitle.Tax, CostRunningCost = 1200 }       //User Colm Vehicle 2
            );


            //Create a list of Fuel fills

            context.Fuels.AddOrUpdate(f => f.FuelID,
            new Fuel { VehicleID = 1, FuelDate = new DateTime(2017, 3, 01), FuelOdometerMileage = 800, FuelQuantity = 35, FuelUnitPrice = 1.35, FuelPartialFill = false },
            new Fuel { VehicleID = 1, FuelDate = new DateTime(2017, 3, 10), FuelOdometerMileage = 1800, FuelQuantity = 40, FuelUnitPrice = 1.45, FuelPartialFill = false },
            new Fuel { VehicleID = 1, FuelDate = new DateTime(2017, 3, 24), FuelOdometerMileage = 2550, FuelQuantity = 29, FuelUnitPrice = 1.55, FuelPartialFill = false },
            new Fuel { VehicleID = 1, FuelDate = new DateTime(2017, 3, 29), FuelOdometerMileage = 3550, FuelQuantity = 35, FuelUnitPrice = 1.25, FuelPartialFill = false },
            new Fuel { VehicleID = 1, FuelDate = new DateTime(2017, 4, 05), FuelOdometerMileage = 4250, FuelQuantity = 30, FuelUnitPrice = 1.15, FuelPartialFill = false },
            new Fuel { VehicleID = 1, FuelDate = new DateTime(2017, 5, 05), FuelOdometerMileage = 4800, FuelQuantity = 25, FuelUnitPrice = 1.15, FuelPartialFill = false },
            new Fuel { VehicleID = 2, FuelDate = new DateTime(2017, 4, 01), FuelOdometerMileage = 1500, FuelQuantity = 45, FuelUnitPrice = 1.35, FuelPartialFill = false },
            new Fuel { VehicleID = 2, FuelDate = new DateTime(2017, 4, 10), FuelOdometerMileage = 2500, FuelQuantity = 35, FuelUnitPrice = 1.45, FuelPartialFill = false },
            new Fuel { VehicleID = 2, FuelDate = new DateTime(2017, 4, 24), FuelOdometerMileage = 3000, FuelQuantity = 18, FuelUnitPrice = 1.55, FuelPartialFill = false },
            new Fuel { VehicleID = 2, FuelDate = new DateTime(2017, 4, 29), FuelOdometerMileage = 4000, FuelQuantity = 40, FuelUnitPrice = 1.25, FuelPartialFill = false },
            new Fuel { VehicleID = 2, FuelDate = new DateTime(2017, 5, 05), FuelOdometerMileage = 4700, FuelQuantity = 25, FuelUnitPrice = 1.15, FuelPartialFill = false }
        );
*/

        }
    } 
}
