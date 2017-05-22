using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"	
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleAppMVC.Models
{
    public class Fuel
    {
        //Property			                    //auto-implemented ReadWrite
        public int FuelID { get; set; }                     //PK    

        public int VehicleID { get; set; }                  //FK    Vehicle.VehicleID

        [Required(ErrorMessage = "Fuel Date is required")]       //Not null or empty string
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
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
        [NotMapped]
        [Display(Name = "Fuel Consumption")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public double FuelConsumption { get; set; }                            //need to adjust this for Partial fills *********************************

        [Display(Name = "Fuel Cost")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public double FuelCost
        {
            get
            {
                double cost = 0;
                cost = Math.Round(FuelQuantity * FuelUnitPrice,2);      //Round the result to 2 decimal places
                return cost;
            }
        }
        
        //Adding to enabling checking if user has paid
        public string StripeToken { get; set; }
        
        //Navigation Property
        public virtual Vehicle Vehicle { get; set; }                  //NOT a Collection, as a Fuel associated to only One Vehicle
                                                                      /*
                                                                      //Partial fill = true
                                                                      //Full fill = false
                                                                      //used in the calculation of the Full & Partial filles
                                                                      public double RollingFuelQuantity { get; set; }        
                                                                      public int RollingFuelMileage { get; set; }
                                                                      */



    }
}





/*        [Display(Name = "Fuel Consumption")]
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
        */


