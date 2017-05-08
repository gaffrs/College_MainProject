using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"	

namespace VehicleAppMVC.Models
{
    public class Fuel
    {
        //Property			                    //auto-implemented ReadWrite
        public int FuelID { get; set; }                     //PK    

        public int VehicleID { get; set; }                  //FK    Vehicle.VehicleID

        [Required(ErrorMessage = "Fuel Date is required")]       //Not null or empty string
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fuel Date")]
        public DateTime FuelDate { get; set; }

        [Required(ErrorMessage = "Fuel Odometer is required")]   //Not null or empty string
        [Display(Name = "Fuel Odometer")]
        public int FuelOdometerMileage { get; set; }

        [Required(ErrorMessage = "Fuel Odometer is required")]   //Not null or empty string
        [Display(Name = "Fuel Qty")]
        public int FuelQuantity { get; set; }

        [Required(ErrorMessage = "Fuel price is required")]   //Not null or empty string
        [Display(Name = "Fuel Unit Price")]
        public double FuelUnitPrice { get; set; }

        [Display(Name = "Partial Fill")]
        public bool FuelPartialFill { get; set; }                       //TODO Have this in as Enum ??????????????




        //Calculations
        [Display(Name = "Fuel Consumption")]
        public double FuelConsumption                                   //need to adjust this for Partial fills *********************************
        {

            get

            {

                double consumption;
                int previousOdo = 0;
                int previousQty = 0;
                int consumptionOdo = 0;
                int consumptionQty = 0;

                if (FuelPartialFill == false)
                {
                    consumptionOdo = FuelOdometerMileage - previousOdo;
                    consumptionQty = FuelQuantity - previousQty;


                    if ((consumptionOdo < 1) && (consumptionQty < 1))
                    {
                        consumption = 0;
                        previousOdo = FuelOdometerMileage;
                        previousQty = FuelQuantity;
        
                    }
                    else
                    {
                        consumption = consumptionOdo / consumptionQty;   //need to adjust this New-Old mileage *******
                    }

                    previousOdo = consumptionOdo;
                    previousQty = consumptionQty;

                    return previousOdo + previousQty;
                }
                else
                {
                    FuelOdometerMileage += FuelOdometerMileage;
                    FuelQuantity += FuelQuantity;
                    consumption = 0;
                }
                return consumption;
            }
        }

        [Display(Name = "Fuel Cost")]
        public double FuelCost
        {
            get
            {
                double cost = 0;
                cost = FuelQuantity * FuelUnitPrice;
                return cost;
            }
        }

        [Display(Name = "Total Fuel Cost: €")]
        public double FuelTotalFuelCost { get; }

        //Navigation Property

        public virtual Vehicle Vehicle { get; set; }                  //NOT a Collection, as a Fuel associated to only One Vehicle
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
        /*
        public double CalcFuelConsumption()
        {
            return FuelConsumption = FuelOdometerMileage / FuelQuantity;
        }
        */
/*
        public double CalcFuelCost()
        {
            return FuelCost = FuelQuantity * FuelUnitPrice;
        }
*/

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
