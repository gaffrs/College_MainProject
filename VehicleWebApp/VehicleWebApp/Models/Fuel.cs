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
        [Display(Name = "Date")]
        public DateTime FuelDate { get; set; }
        [Display(Name = "Odometer")]
        public int FuelOdometerMileage { get; set; }
        [Display(Name = "Qty")]
        public int FuelQuantity { get; set; }
        [Display(Name = "Price")]
        public double FuelUnitPrice { get; set; }
        [Display(Name = "Partial Fill")]
        public bool FuelPartialFill { get; set; }                       //TODO Have this in as Enum ??????????????
        [Display(Name = "Consumption")]
        public double FuelConsumption { get; set; }
        [Display(Name = "Cost")]
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
            return "Fuel ID: " + FuelID + ", Date: " + FuelDate + ", Odometer: " + FuelOdometerMileage +
                ", Quantity: " + FuelQuantity + ", Unit Price: " + FuelUnitPrice + ", Partial Fill: " + FuelPartialFill
                 + ", Consumption: " + FuelConsumption + ", Cost: " + FuelCost;
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
