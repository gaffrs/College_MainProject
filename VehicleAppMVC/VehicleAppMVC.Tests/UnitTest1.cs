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
        public void FuelConsumptionCalcullation()
        {   
            // arrange  
            var controller = new FuelsController { };


            // act 

            // assert
            //Assert.AreEqual();
        }
    }
}




