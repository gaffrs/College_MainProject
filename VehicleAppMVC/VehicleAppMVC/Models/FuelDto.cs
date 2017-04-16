using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"	

namespace VehicleAppMVC.Models
{
    public class FuelDto
    {
        //Property			                    //auto-implemented ReadWrite
        public int FuelID { get; set; }                     //PK    

        public int VehicleID { get; set; }                  //FK    

        [Display(Name = "Fuel Date")]
        public DateTime FuelDate { get; set; }

        [Display(Name = "Fuel Odometer")]
        public int FuelOdometerMileage { get; set; }

        [Display(Name = "Fuel Qty")]
        public int FuelQuantity { get; set; }

        [Display(Name = "Fuel Price")]
        public double FuelUnitPrice { get; set; }

        [Display(Name = "Partial Fill")]
        public bool FuelPartialFill { get; set; }


        //Values retuned from Methods
        [Display(Name = "Fuel Consumption")]
        public double FuelConsumption { get; set; }

        [Display(Name = "Fuel Cost")]
        public double FuelCost { get; set; }

        //Navigation Property

        public virtual Vehicle Vehicle { get; set; }

        //ToString()
        public override string ToString()
        {
            return "Fuel ID: " + FuelID + ", Fuel Date: " + FuelDate + ", Fuel Odometer: " + FuelOdometerMileage +
                ", Fuel Quantity: " + FuelQuantity + ", Fuel Price: " + FuelUnitPrice + ", Partial Fill: " + FuelPartialFill
                 + ", Fuel Consumption: " + FuelConsumption + ", Fuel Cost: " + FuelCost;
        }



        //need to adjust this for Partial fills *********************************
        public double CalcFuelConsumption()
        {
            return FuelConsumption = FuelOdometerMileage / FuelQuantity;
        }

        public double CalcFuelCost()
        {
            return FuelCost = FuelQuantity * FuelUnitPrice;
        }


    }
}

