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
        //Enums
        public enum efuelPartialFill
        {
            True, False
        }
        //Property			                    //auto-implemented ReadWrite
        public int fuelID { get; set; }
        public DateTime fuelDate { get; set; }
        public int fuelOdometerMileage { get; set; }
        public int fuelQuantity { get; set; }
        public double fuelUnitPrice { get; set; }
        public efuelPartialFill fuelPartialFill { get; set; }                       //TODO Have this in as Enum ??????????????
        public double fuelConsumption { get; set; }
        public double fuelCost { get; set; }


        //need to adjust this for Partial fills *********************************
        public double CalcFuelConsumption()
        {
            return fuelConsumption = fuelOdometerMileage/fuelQuantity;
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
