using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"	

namespace VehicleWebApp.Models
{        
    public class Fuel
    {
        //Property			                    //auto-implemented ReadWrite
        public int FuelID { get; set; }                     //PK    
        [Display(Name = "vehicle ID")]
        public int VehicleID { get; set; }                  //FK    Vehicle.VehicleID

        
        [Required(ErrorMessage = "Fuel Date is required")]       //Not null or empty string
        [Display(Name = "Fuel Date")]
        public DateTime FuelDate { get; set; }

        [Required(ErrorMessage = "Fuel Odometer is required")]   //Not null or empty string
        [Display(Name = "Fuel Odometer")]
        public int FuelOdometerMileage { get; set; }

        [Required(ErrorMessage = "Fuel Odometer is required")]   //Not null or empty string
        [Display(Name = "Fuel Qty")]
        public int FuelQuantity { get; set; }

        [Required(ErrorMessage = "Fuel price is required")]   //Not null or empty string
        [Display(Name = "Fuel Price")]
        public double FuelUnitPrice { get; set; }

        [Display(Name = "Partial Fill")]
        public bool FuelPartialFill { get; set; }                       //TODO Have this in as Enum ??????????????


        //Values retuned from Methods
        [Display(Name = "Fuel Consumption")]
        public double FuelConsumption { get; set; }

        [Display(Name = "Fuel Cost")]
        public double FuelCost { get; set; }

        //Navigation Property

        public Vehicle Vehicle { get; set; }                  //NOT a Collection, as a Fuel associated to only One Vehicle
        /*
        //Partial fill = true
        //Full fill = false
        //used in the calculation of the Full & Partial filles
        public double RollingFuelQuantity { get; set; }        
        public int RollingFuelMileage { get; set; }
        */
        
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


/*
        //Method to implement
        public virtual void FuelAddFillFull()
        {
            throw new System.NotImplementedException();
        }

        public virtual void FuelAddFillPartial()
        {
            throw new System.NotImplementedException();
        }

        public virtual void FuelConsumptionBest()
        {
            throw new System.NotImplementedException();
        }

        public virtual void FuelConsumptionAverage()
        {
            throw new System.NotImplementedException();
        }

        public virtual void FuelConsumptionWorst()
        {
            throw new System.NotImplementedException();
        }

        public virtual void FuelCostTotal()
        {
            throw new System.NotImplementedException();
        }

        public virtual void FuelCostBest()
        {
            throw new System.NotImplementedException();
        }

        public virtual void FuelCostAverage()
        {
            throw new System.NotImplementedException();
        }

        public virtual void FuelCostWorst()
        {
            throw new System.NotImplementedException();
        }
        */
