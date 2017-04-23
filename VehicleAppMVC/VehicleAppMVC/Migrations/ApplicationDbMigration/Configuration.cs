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

//Setting up seed data from Scratch
//Delete ALL Tables
//1)Register User Paul
//2)Register User Colm

            {
                context.Vehicles.AddOrUpdate(v => v.VehicleID,
/*User Paul*/     new Vehicle { ApplicationUserId = "9226d49c-1b87-4ddc-8a88-c26d6639fbaf", VehicleMake = "Paul Subaru", VehicleModel = "Paul Impreza", VehicleRegistrationNumber = "Paul1", VehicleOdometerMileage = 2500, SettingFuelType = eSettingFuelType.Petrol, SettingDistance = eSettingDistance.Miles, SettingVolume = eSettingVolume.UK_Gal, SettingConsumption = eSettingConsumption.UK_Mpg },
/*User Paul*/     new Vehicle { ApplicationUserId = "9226d49c-1b87-4ddc-8a88-c26d6639fbaf", VehicleMake = "Paul Volkswagen", VehicleModel = "Paul Polo", VehicleRegistrationNumber = "Paul2", VehicleOdometerMileage = 1000, SettingFuelType = eSettingFuelType.Petrol, SettingDistance = eSettingDistance.Miles, SettingVolume = eSettingVolume.US_Gal, SettingConsumption = eSettingConsumption.US_Mpg },
/*User Colm*/     new Vehicle { ApplicationUserId = "316f6ed3-d7b3-4a14-bffb-3770ce35447c", VehicleMake = "Colm Opel", VehicleModel = "Colm Vectra", VehicleRegistrationNumber = "Colm1", VehicleOdometerMileage = 1000, SettingFuelType = eSettingFuelType.Petrol, SettingDistance = eSettingDistance.Km, SettingVolume = eSettingVolume.Litres, SettingConsumption = eSettingConsumption.Lper100km },
/*User Colm*/     new Vehicle { ApplicationUserId = "316f6ed3-d7b3-4a14-bffb-3770ce35447c", VehicleMake = "Colm Mercedes", VehicleModel = "Colm C-Class", VehicleRegistrationNumber = "Colm2", VehicleOdometerMileage = 1300, SettingFuelType = eSettingFuelType.Diesel, SettingDistance = eSettingDistance.Km, SettingVolume = eSettingVolume.Litres, SettingConsumption = eSettingConsumption.Lper100km }
                  );
            };

            {

                context.Notifications.AddOrUpdate(n => n.NotificationID,
/*User Paul*/     new Notification { ApplicationUserId = "9226d49c-1b87-4ddc-8a88-c26d6639fbaf", NotificationDate = new DateTime(2017, 7, 01), NotificationSendDate = new DateTime(2017, 1, 01), NotificationType = eNotificationType.Email, NotificationTitle = Notification.eNotificationTitle.InsuranceDateRenewal },
/*User Paul*/     new Notification { ApplicationUserId = "9226d49c-1b87-4ddc-8a88-c26d6639fbaf", NotificationDate = new DateTime(2017, 7, 01), NotificationSendDate = new DateTime(2017, 1, 01), NotificationType = eNotificationType.SMS, NotificationTitle = Notification.eNotificationTitle.MotorTaxDateRenewal },
/*User Colm*/     new Notification { ApplicationUserId = "316f6ed3-d7b3-4a14-bffb-3770ce35447c", NotificationDate = new DateTime(2018, 7, 01), NotificationSendDate = new DateTime(2018, 1, 01), NotificationType = eNotificationType.Email, NotificationTitle = Notification.eNotificationTitle.ServiceDateNotification },
/*User Colm*/     new Notification { ApplicationUserId = "316f6ed3-d7b3-4a14-bffb-3770ce35447c", NotificationDate = new DateTime(2018, 7, 01), NotificationSendDate = new DateTime(2018, 1, 01), NotificationType = eNotificationType.Email, NotificationTitle = Notification.eNotificationTitle.ServiceMileageNotification }
                );
            };
        }
    }
}
