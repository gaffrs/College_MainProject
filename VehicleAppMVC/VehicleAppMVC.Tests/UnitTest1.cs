// Create Unit Tests:                    Add New Project - Test - Unit Test Project
// Need to add a reference to link it:   Right click the UnitTest File - Add - Reference - Project - Select the Project
// How to run the Unit Tests:            Test - Run - All Tests
// Check for Code Coverage:              Test - Analyze Code Coverage for all tests
// Debug                                 Test - Debug - All tests

// Assert Class https://msdn.microsoft.com/en-us/library/ms182530.aspx 
// Assert
// Collection Assert
// String Assert

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehicleAppMVC.Controllers;

using VehicleAppMVC.Models; //required to access the models
using System.Web.Mvc;
//using System.ComponentModel.DataAnnotations; //required in order to use ValidationException

namespace VehicleAppMVC.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FuelCostTest()
        {
            // arrange  
            Fuel b = new Fuel();

            // act 
            b.FuelQuantity = 45;
            b.FuelUnitPrice = 1.15;
            // assert
            Assert.AreEqual(b.FuelCost,51.75);
        }

        [TestMethod]
        public void VehicleFieldsTest()
        {
            // arrange           
            Vehicle b = new Vehicle();
            // act 
            b.ApplicationUserId = "8ad230ab-0758-4066-952b-e0f163c648f4";
            b.VehicleID = 1;
            b.VehicleMake = ("Skoda");
            b.VehicleModel = ("Octavia");
            b.VehicleOdometerMileage = 7777;
            b.VehicleRegistrationNumber = "Paul1";
            b.SettingFuelType = eSettingFuelType.Diesel;

            // assert
            Assert.AreEqual(b.ApplicationUserId, ("8ad230ab-0758-4066-952b-e0f163c648f4"));
            Assert.AreEqual(b.VehicleID, (1));
            Assert.AreEqual(b.VehicleMake, ("Skoda"));
            Assert.AreEqual(b.VehicleModel, ("Octavia"));
            Assert.AreEqual(b.VehicleOdometerMileage, (7777));
            Assert.AreEqual(b.VehicleRegistrationNumber, ("Paul1"));
            Assert.AreEqual(b.SettingFuelType, (eSettingFuelType.Diesel)); 
        }

        [TestMethod]
        public void FuelFieldsTest()
        {
            // arrange           
            Fuel b = new Fuel();
            // act 
            b.FuelID = 1;
            b.VehicleID = 3;
            b.FuelDate = new DateTime(2017, 03, 01);
            b.FuelOdometerMileage = 7777;
            b.FuelQuantity= 45;
            b.FuelUnitPrice = 1.45;
            b.FuelPartialFill = true;
            b.FuelConsumption = 45;

            // assert
            Assert.AreEqual(b.FuelID, (1));
            Assert.AreEqual(b.VehicleID, (3));
            Assert.AreEqual(b.FuelDate, (new DateTime(2017, 03, 01)));
            Assert.AreEqual(b.FuelOdometerMileage, (7777));
            Assert.AreEqual(b.FuelQuantity, (45));
            Assert.AreEqual(b.FuelUnitPrice, (1.45));
            Assert.AreEqual(b.FuelPartialFill, (true));
            Assert.AreEqual(b.FuelConsumption, (45));
        }

        [TestMethod]
        public void CostFieldsTest()
        {
            // arrange           
            Cost b = new Cost();
            // act 
            b.CostID = 1;
            b.VehicleID = 3;
            b.CostDate = new DateTime(2017, 03, 01);
            b.CostOdometerMileage = 7777;
            b.CostRunningCost = 450;
            b.CostTitle = eCostTitle.Insurance;


            // assert
            Assert.AreEqual(b.CostID, (1));
            Assert.AreEqual(b.VehicleID, (3));
            Assert.AreEqual(b.CostDate, (new DateTime(2017, 03, 01)));
            Assert.AreEqual(b.CostOdometerMileage, (7777));
            Assert.AreEqual(b.CostRunningCost, (450));
            Assert.AreEqual(b.CostTitle, (eCostTitle.Insurance));
        }

        [TestMethod]
        public void NotificationsFieldsTest()
        {
            // arrange           
            Notification b = new Notification();
            // act 
            b.ApplicationUserId = "8ad230ab-0758-4066-952b-e0f163c648f4";
            b.NotificationID = 1;
            b.NotificationDate = (new DateTime(2027, 03, 01));
            b.NotificationSendDate = (new DateTime(2017, 03, 01));
            b.NotificationTitle = eNotificationTitle.VehicleBirthday;
            b.NotificationType = eNotificationType.Email;


            // assert
            Assert.AreEqual(b.ApplicationUserId, ("8ad230ab-0758-4066-952b-e0f163c648f4"));
            Assert.AreEqual(b.NotificationID, (1));
            Assert.AreEqual(b.NotificationDate, (new DateTime(2027, 03, 01)));
            Assert.AreEqual(b.NotificationSendDate, (new DateTime(2017, 03, 01)));
            Assert.AreEqual(b.NotificationTitle, (eNotificationTitle.VehicleBirthday));
            Assert.AreEqual(b.NotificationType, (eNotificationType.Email));

        }
        /*
        [TestMethod]
        public void FuelConsumptionCalculationTest()
        {
            // arrange  
            var controller = new FuelsController { };
            }
        */

        [TestMethod]
        public void FuelConsumptionCalculationTest()
        {   
            // arrange  
            var controller = new FuelsController {  };
            Fuel b = new Fuel();

            b.FuelQuantity = 45;
            b.FuelPartialFill = false;
            b.FuelOdometerMileage = 100;
            b.FuelQuantity = 45;
            b.FuelPartialFill = false;
            b.FuelOdometerMileage = 1000;


            // act 



            // assert
            Assert.AreEqual(b.FuelConsumption, (1000));
            //Assert.AreEqual();
        }
        /*
        [TestMethod]
        public void ReturnsDetailsView()
        {
            FuelsController controllerUnderTest = new FuelsController();
            var result = controllerUnderTest.Details("a1") as ViewResult;
            Assert.AreEqual("fooview", result.ViewName);
        }
        */


    }
}




