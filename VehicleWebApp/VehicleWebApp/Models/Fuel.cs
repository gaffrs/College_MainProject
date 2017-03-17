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
        public int VehicleID { get; set; }                  //FK    Vehicle.VehicleID
        public DateTime FuelDate { get; set; }
        public int FuelOdometerMileage { get; set; }
        public int FuelQuantity { get; set; }
        public double FuelUnitPrice { get; set; }
        public bool FuelPartialFill { get; set; }                       //TODO Have this in as Enum ??????????????
        public double FuelConsumption { get; set; }
        public double FuelCost { get; set; }

        //Navigation Property
        public Vehicle Vehicle { get; set; }                  //NOT a Collection, as a Fuel associated to only One Vehicle


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
