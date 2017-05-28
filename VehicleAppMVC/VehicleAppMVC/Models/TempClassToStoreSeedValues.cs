using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleAppMVC.Models
{
    public class TempClassToStoreSeedValues
    {
        //Collection in Memory, list
        List<Vehicle> Vehicles;         //<Vehicle> is the name of the Class in Model
        //List<User> Users;
        List<Cost> Costs;
        List<Fuel> FuelFills;
        List<Notification> Notifications;

        public TempClassToStoreSeedValues()
        {
            // Create a list of customers.
            //Users = new List<User>()      //strongly typed list of objects that can be accessed by index.
            {
            };

            // Create a list of vehicles.
            Vehicles = new List<Vehicle>()  //strongly typed list of objects that can be accessed by index.
            {
            };

            // Create a list of Notifications.
            Notifications = new List<Notification>()  //strongly typed list of objects that can be accessed by index.
            {

            };

            // Create a list of costs.
            Costs = new List<Cost>()  //strongly typed list of objects that can be accessed by index.
            {
            };

            // Create a list of Fuelfills.
            FuelFills = new List<Fuel>()  //strongly typed list of objects that can be accessed by index.
            {
            };




            //Option1....need to use: using Microsoft.AspNet.Identity;
            /*
            //using Microsoft.AspNet.Identity;            
                        var hasher = new PasswordHasher();
                        context.Users.AddOrUpdate(u => u.UserName,
                            new ApplicationUser { UserName = "paul@gmail.com", Email = "paul@gmail.com", PhoneNumber = "0871234568", PasswordHash = hasher.HashPassword("$Password1") },
                            new ApplicationUser { UserName = "colm@gmail.com", Email = "colm@gmail.com", PhoneNumber = "0871234567", PasswordHash = hasher.HashPassword("$Password1") }
                        );
            */

            //Option2 (update-database....using seed data
            /*
                        if (!context.Users.Any(u => u.UserName == "colm"))
                        {
                            var roleStore = new RoleStore<IdentityRoles>.(context);
                            var roleManager = new RoleManager<IdentityRoles>(roleStore);

                            var userStore = new UserStore<ApplicationUser>.(context);
                            var userManager = new UserManager<ApplicationUser>(userStore);
                            var user = new ApplicationUser { UserName = "colm" };

                            userManager.Create(user, "password");
                            roleManager.Create(new IdentityRole { Name = "admin" });
                            userManager.AddToRole(user.Id, "admin");
                        }
            */







            //*********************************************************************
            /*
                        //Setting up seed data from Scratch
                        //Delete ALL Tables
                        //1)Register User Paul
                        //2)Register User Colm

            /*

                        //Create a list of Vehicles (x2 Users)

                            context.Vehicles.AddOrUpdate(v => v.VehicleID,
                               new Vehicle { ApplicationUserId = "8ad230ab-0758-4066-952b-e0f163c648f4", VehicleMake = "Paul Subaru", VehicleModel = "Paul Impreza", VehicleRegistrationNumber = "Paul1", VehicleOdometerMileage = 500, SettingFuelType = eSettingFuelType.Petrol, SettingDistance = eSettingDistance.Miles, SettingVolume = eSettingVolume.UK_Gal, SettingConsumption = eSettingConsumption.UK_Mpg },  //User Paul 
                               new Vehicle { ApplicationUserId = "8ad230ab-0758-4066-952b-e0f163c648f4", VehicleMake = "Paul Volkswagen", VehicleModel = "Paul Polo", VehicleRegistrationNumber = "Paul2", VehicleOdometerMileage = 1500, SettingFuelType = eSettingFuelType.Petrol, SettingDistance = eSettingDistance.Miles, SettingVolume = eSettingVolume.US_Gal, SettingConsumption = eSettingConsumption.US_Mpg }, //User Paul 
                               new Vehicle { ApplicationUserId = "dde3844d-46cf-49d7-80a9-5b60f22b4697", VehicleMake = "Colm Opel", VehicleModel = "Colm Vectra", VehicleRegistrationNumber = "Colm1", VehicleOdometerMileage = 1000, SettingFuelType = eSettingFuelType.Petrol, SettingDistance = eSettingDistance.Km, SettingVolume = eSettingVolume.Litres, SettingConsumption = eSettingConsumption.Lper100km },     //User Colm 
                               new Vehicle { ApplicationUserId = "dde3844d-46cf-49d7-80a9-5b60f22b4697", VehicleMake = "Colm Mercedes", VehicleModel = "Colm C-Class", VehicleRegistrationNumber = "Colm2", VehicleOdometerMileage = 1300, SettingFuelType = eSettingFuelType.Diesel, SettingDistance = eSettingDistance.Km, SettingVolume = eSettingVolume.Litres, SettingConsumption = eSettingConsumption.Lper100km } //User Colm 
                             );



                        //Create a list of Notifications (x2 Users)


                            context.Notifications.AddOrUpdate(n => n.NotificationID,
                                 new Notification { ApplicationUserId = "8ad230ab-0758-4066-952b-e0f163c648f4", NotificationDate = new DateTime(2018, 2, 28), NotificationSendDate = new DateTime(2018, 2, 20), NotificationType = eNotificationType.Email, NotificationTitle = Notification.eNotificationTitle.InsuranceDateRenewal },        //User Paul
                                 new Notification { ApplicationUserId = "8ad230ab-0758-4066-952b-e0f163c648f4", NotificationDate = new DateTime(2018, 10, 01), NotificationSendDate = new DateTime(2018, 09, 20), NotificationType = eNotificationType.SMS, NotificationTitle = Notification.eNotificationTitle.MotorTaxDateRenewal },           //User Paul
                                 new Notification { ApplicationUserId = "dde3844d-46cf-49d7-80a9-5b60f22b4697", NotificationDate = new DateTime(2018, 7, 01), NotificationSendDate = new DateTime(2018, 1, 01), NotificationType = eNotificationType.Email, NotificationTitle = Notification.eNotificationTitle.ServiceDateNotification },     //User Colm 
                                 new Notification { ApplicationUserId = "dde3844d-46cf-49d7-80a9-5b60f22b4697", NotificationDate = new DateTime(2018, 7, 01), NotificationSendDate = new DateTime(2018, 1, 01), NotificationType = eNotificationType.Email, NotificationTitle = Notification.eNotificationTitle.ServiceMileageNotification }   //User Colm 
                             );

                        //Create a list of Costs

                        context.Costs.AddOrUpdate(c => c.CostID,
                        new Cost { VehicleID = 1, CostDate = new DateTime(2017, 3, 01), CostOdometerMileage = 500, CostTitle = eCostTitle.Insurance, CostRunningCost = 700 },   //User Paul Vehicle 1
                        new Cost { VehicleID = 1, CostDate = new DateTime(2017, 8, 01), CostOdometerMileage = 3000, CostTitle = eCostTitle.Service, CostRunningCost = 400 },    //User Paul Vehicle 1
                        new Cost { VehicleID = 1, CostDate = new DateTime(2017, 10, 01), CostOdometerMileage = 4000, CostTitle = eCostTitle.Tax, CostRunningCost = 250 },       //User Paul Vehicle 1
                        new Cost { VehicleID = 2, CostDate = new DateTime(2017, 3, 01), CostOdometerMileage = 1500, CostTitle = eCostTitle.Insurance, CostRunningCost = 1500 },   //User Paul Vehicle 2
                        new Cost { VehicleID = 2, CostDate = new DateTime(2017, 8, 01), CostOdometerMileage = 4000, CostTitle = eCostTitle.Service, CostRunningCost = 1000 },    //User Paul Vehicle 2
                        new Cost { VehicleID = 2, CostDate = new DateTime(2017, 10, 01), CostOdometerMileage = 5000, CostTitle = eCostTitle.Tax, CostRunningCost = 1200 },       //User Paul Vehicle 2
                        new Cost { VehicleID = 3, CostDate = new DateTime(2017, 4, 01), CostOdometerMileage = 2500, CostTitle = eCostTitle.Insurance, CostRunningCost = 400 },   //User Colm Vehicle 3
                        new Cost { VehicleID = 3, CostDate = new DateTime(2017, 9, 01), CostOdometerMileage = 5000, CostTitle = eCostTitle.Service, CostRunningCost = 1000 },    //User Colm Vehicle 3
                        new Cost { VehicleID = 3, CostDate = new DateTime(2017, 11, 01), CostOdometerMileage = 6000, CostTitle = eCostTitle.Tax, CostRunningCost = 500 }        //User Colm Vehicle 3
                        );


                        //Create a list of Fuel fills

                        context.Fuels.AddOrUpdate(f => f.FuelID,
                        new Fuel { VehicleID = 1, FuelDate = new DateTime(2017, 3, 01), FuelOdometerMileage = 800,  FuelQuantity = 35, FuelUnitPrice = 1.35, FuelPartialFill = false },
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