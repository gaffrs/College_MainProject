using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using VehicleWebApp.Models;  //need to add the namespace for the Models, to access the Class

namespace VehicleWebApp.Controllers
{
    // Route Prefix
    [RoutePrefix("api")]     //Route Prefix, added to enable attribute based Routing

    public class VehicleEmptyController : ApiController
    {
        //Collection in Memory, list
        List<Vehicle> vehicles;         //<Vehicle> is the name of the Class in Model
        List<Customer> customers;
        List<Cost> costs;
        List<Fuel> fuelfills;
        List<Notification> notifications;

        //Create Default constructor ‘ctor’ to return whole collection
        public VehicleEmptyController()
        {
            // Create a list of vehicles.
            vehicles = new List<Vehicle>()  //strongly typed list of objects that can be accessed by index.
            {
                new Vehicle { VehicleMake = "Opel", VehicleModel = "Vectra", VehicleRegistrationNumber = "161D171", VehicleOdometerMileage = 1600, SettingFuelType = Vehicle.eSettingFuelType.Petrol, SettingDistance = Vehicle.eSettingDistance.Km, SettingVolume = Vehicle.eSettingVolume.Litres_L, SettingConsumption = Vehicle.eSettingConsumption.Lper100km },
                new Vehicle { VehicleMake = "Mercedes", VehicleModel = "C-Class", VehicleRegistrationNumber = "161D181", VehicleOdometerMileage = 1300, SettingFuelType = Vehicle.eSettingFuelType.Diesel, SettingDistance = Vehicle.eSettingDistance.Km, SettingVolume = Vehicle.eSettingVolume.Litres_L, SettingConsumption = Vehicle.eSettingConsumption.Lper100km },
                new Vehicle { VehicleMake = "Subaru", VehicleModel = "Impreza", VehicleRegistrationNumber = "161D200", VehicleOdometerMileage = 2500, SettingFuelType = Vehicle.eSettingFuelType.Petrol, SettingDistance = Vehicle.eSettingDistance.Miles, SettingVolume = Vehicle.eSettingVolume.UK_Gal, SettingConsumption = Vehicle.eSettingConsumption.Mpg_UK },
                new Vehicle { VehicleMake = "Volkswagen", VehicleModel = "Polo", VehicleRegistrationNumber = "161D250", VehicleOdometerMileage = 1000, SettingFuelType = Vehicle.eSettingFuelType.Petrol, SettingDistance = Vehicle.eSettingDistance.Miles, SettingVolume = Vehicle.eSettingVolume.US_Gal, SettingConsumption = Vehicle.eSettingConsumption.Mpg_US }
            };

            // Create a list of customers.
            customers = new List<Customer>()  //strongly typed list of objects that can be accessed by index.
            {
                new Customer { Username = "Colm1", UserPassword = "123456", UserEmailAddress = "Colm@gmail.com", UserMobileNumber = 0871234567, UserType = Customer.eUserType.Basic  },
                new Customer { Username = "John1", UserPassword = "234567", UserEmailAddress = "John@gmail.com", UserMobileNumber = 0871111111, UserType = Customer.eUserType.PRO  },
                new Customer { Username = "Mick1", UserPassword = "345678", UserEmailAddress = "Mick@gmail.com", UserMobileNumber = 0872222222, UserType = Customer.eUserType.Basic  }
            };

            // Create a list of costs.
            costs = new List<Cost>()  //strongly typed list of objects that can be accessed by index.
            {
                new Cost { costDate = new DateTime(2017, 1, 01), costOdometerMileage = 100, costTitle = Cost.eCostTitle.Insurance, costRunningCost = 100.55, costYear = new DateTime(2018),  costStartDate  = new DateTime(2017, 1, 20), costEndDate = new DateTime(2018, 1, 20) },
                new Cost { costDate = new DateTime(2017, 6, 01), costOdometerMileage = 100, costTitle = Cost.eCostTitle.Insurance, costRunningCost = 100.55, costYear = new DateTime(2018),  costStartDate  = new DateTime(2017, 7, 20), costEndDate = new DateTime(2018, 7, 20) }
            };

            // Create a list of Fuelfills.
            fuelfills = new List<Fuel>()  //strongly typed list of objects that can be accessed by index.
            {
                new Fuel { fuelDate = DateTime.UtcNow, fuelOdometerMileage = 10000, fuelQuantity = 45, fuelUnitPrice = 1.35, fuelPartialFill = Fuel.efuelPartialFill.False,  fuelConsumption = 45555555555555555, fuelCost = 100.35 },
            
            };

            // Create a list of Notifications.
            notifications = new List<Notification>()  //strongly typed list of objects that can be accessed by index.
            {
                new Notification { notificationDate = new DateTime(2017, 7, 01), notificationSendDate = new DateTime(2017, 1, 01), notificationType = Notification.eNotificationType.Email , notificationTitle = Notification.eNotificationTitle.MotorTaxDateRenewal },
                new Notification { notificationDate = new DateTime(2017, 7, 01), notificationSendDate = new DateTime(2017, 1, 01), notificationType = Notification.eNotificationType.Email , notificationTitle = Notification.eNotificationTitle.MotorTaxDateRenewal }
            };
    }

    [Route("all")]
        public  IHttpActionResult GetAll()
        {
            return Ok(vehicles);
            //return Ok(customers);
        }

        [Route("all/vehicles")]
        public IHttpActionResult GetAllVehicles()
        {
            return Ok(vehicles);
        }

        [Route("all/customers")]
        public IHttpActionResult GetAllCustomers()
        {
            return Ok(customers);
        }

        [Route("all/costs")]
        public IHttpActionResult GetAllCosts()
        {
            return Ok(costs);
        }

        [Route("all/fuelfills")]
        public IHttpActionResult GetAllFuelFills()
        {
            return Ok(fuelfills);
        }

        [Route("all/notifications")]
        public IHttpActionResult GetAllNotifications()
        {
            return Ok(notifications);
        }
    }
}
