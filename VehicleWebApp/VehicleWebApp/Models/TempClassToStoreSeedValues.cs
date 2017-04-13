using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleWebApp.Models
{
    public class TempClassToStoreSeedValues
    {
        //Collection in Memory, list
        List<Vehicle> Vehicles;         //<Vehicle> is the name of the Class in Model
        List<User> Users;
        List<Cost> Costs;
        List<Fuel> FuelFills;
        List<Notification> Notifications;

        public TempClassToStoreSeedValues()
        {
            // Create a list of vehicles.
            Vehicles = new List<Vehicle>()  //strongly typed list of objects that can be accessed by index.
            {
            
            //context.Vehicle.AddOrUpdate(v => v.VehicleID,
                new Vehicle { UserID = 1, VehicleMake = "Opel", VehicleModel = "Vectra", VehicleRegistrationNumber = "161D171", VehicleOdometerMileage = 1600, SettingFuelType = eSettingFuelType.Petrol, SettingDistance = eSettingDistance.Km, SettingVolume = eSettingVolume.Litres_L, SettingConsumption = eSettingConsumption.Lper100km },
                new Vehicle { UserID = 1, VehicleMake = "Mercedes", VehicleModel = "C-Class", VehicleRegistrationNumber = "161D181", VehicleOdometerMileage = 1300, SettingFuelType = eSettingFuelType.Diesel, SettingDistance = eSettingDistance.Km, SettingVolume = eSettingVolume.Litres_L, SettingConsumption = eSettingConsumption.Lper100km },
                new Vehicle { UserID = 2, VehicleMake = "Subaru", VehicleModel = "Impreza", VehicleRegistrationNumber = "161D200", VehicleOdometerMileage = 2500, SettingFuelType = eSettingFuelType.Petrol, SettingDistance = eSettingDistance.Miles, SettingVolume = eSettingVolume.UK_Gal, SettingConsumption = eSettingConsumption.Mpg_UK },
                new Vehicle { UserID = 2, VehicleMake = "Volkswagen", VehicleModel = "Polo", VehicleRegistrationNumber = "161D250", VehicleOdometerMileage = 1000, SettingFuelType = eSettingFuelType.Petrol, SettingDistance = eSettingDistance.Miles, SettingVolume = eSettingVolume.US_Gal, SettingConsumption = eSettingConsumption.Mpg_US }
            };

            // Create a list of customers.
            Users = new List<User>()  //strongly typed list of objects that can be accessed by index.
            {

            //context.User.AddOrUpdate(u => u.UserID,
                new User { Username = "Colm1", UserPassword = "123456", UserEmailAddress = "Colm@gmail.com", UserMobileNumber = "0871234567", UserType = eUserType.Basic  },
                new User { Username = "John1", UserPassword = "234567", UserEmailAddress = "John@gmail.com", UserMobileNumber = "0871111111", UserType = eUserType.PRO  },
                new User { Username = "Mick1", UserPassword = "345678", UserEmailAddress = "Mick@gmail.com", UserMobileNumber = "0872222222", UserType = eUserType.Basic  }
            };

            // Create a list of costs.
            Costs = new List<Cost>()  //strongly typed list of objects that can be accessed by index.
            {

            //context.Cost.AddOrUpdate(c => c.CostID,
                new Cost { VehicleID = 1, CostDate = new DateTime(2017, 1, 01), CostOdometerMileage = 1000, CostTitle = eCostTitle.Insurance, CostRunningCost = 700, CostStartDate  = new DateTime(2017, 1, 20), CostEndDate = new DateTime(2018, 1, 20) },
                new Cost { VehicleID = 1, CostDate = new DateTime(2017, 5, 01), CostOdometerMileage = 3000, CostTitle = eCostTitle.Service, CostRunningCost = 399, CostStartDate  = new DateTime(2017, 1, 20), CostEndDate = new DateTime(2018, 1, 20) },
                new Cost { VehicleID = 1, CostDate = new DateTime(2017, 6, 01), CostOdometerMileage = 4000, CostTitle = eCostTitle.Tax, CostRunningCost = 250, CostStartDate  = new DateTime(2017, 7, 20), CostEndDate = new DateTime(2018, 7, 20) }
            };

            // Create a list of Fuelfills.
            FuelFills = new List<Fuel>()  //strongly typed list of objects that can be accessed by index.
            {

            //context.Fuel.AddOrUpdate(f => f.FuelID,
                new Fuel { VehicleID = 1, FuelDate = new DateTime(2017, 3, 01), FuelOdometerMileage = 10000, FuelQuantity = 45, FuelUnitPrice = 1.35, FuelPartialFill = false,  FuelConsumption = 45555555555555555, FuelCost = 100.35555555555555 },
                new Fuel { VehicleID = 1, FuelDate = new DateTime(2017, 3, 10), FuelOdometerMileage = 10300, FuelQuantity = 40, FuelUnitPrice = 1.45, FuelPartialFill = false,  FuelConsumption = 45555555555555555, FuelCost = 100.35555555555555 },
                new Fuel { VehicleID = 1, FuelDate = new DateTime(2017, 3, 24), FuelOdometerMileage = 10600, FuelQuantity = 48, FuelUnitPrice = 1.55, FuelPartialFill = false,  FuelConsumption = 45555555555555555, FuelCost = 100.35555555555555 },
                new Fuel { VehicleID = 1, FuelDate = new DateTime(2017, 3, 29), FuelOdometerMileage = 10900, FuelQuantity = 50, FuelUnitPrice = 1.25, FuelPartialFill = false,  FuelConsumption = 45555555555555555, FuelCost = 100.35555555555555 },
                new Fuel { VehicleID = 1, FuelDate = new DateTime(2017, 4, 05), FuelOdometerMileage = 11200, FuelQuantity = 55, FuelUnitPrice = 1.15, FuelPartialFill = false,  FuelConsumption = 45555555555555555, FuelCost = 100.35555555555555 },

            };

            // Create a list of Notifications.
            Notifications = new List<Notification>()  //strongly typed list of objects that can be accessed by index.
            {

            //context.Notification.AddOrUpdate(n => n.NotificationID,
                new Notification { UserID = 1, NotificationDate = new DateTime(2017, 7, 01), NotificationSendDate = new DateTime(2017, 1, 01), NotificationType = eNotificationType.Email , NotificationTitle = eNotificationTitle.MotorTaxDateRenewal },
                new Notification { UserID = 1, NotificationDate = new DateTime(2017, 7, 01), NotificationSendDate = new DateTime(2017, 1, 01), NotificationType = eNotificationType.SMS , NotificationTitle = eNotificationTitle.VehicleTestingDateRenewal },
                new Notification { UserID = 2 ,NotificationDate = new DateTime(2018, 7, 01), NotificationSendDate = new DateTime(2018, 1, 01), NotificationType = eNotificationType.Email , NotificationTitle = eNotificationTitle.MotorTaxDateRenewal }
            };




        }
            
        }
}