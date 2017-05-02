using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"


namespace VehicleAppMVC.Models
{
    //Enum costs
    public enum eCostTitle { Tyres, Tax, Service, [Display(Name = "NCT or DOE")] NCTorDOE, Insurance, Testing }

    public class Cost
    {
        //Property			                    //auto-implemented ReadWrite
        public int CostID { get; set; }                     //PK
        public int VehicleID { get; set; }                  //FK    Vehicle.VehicleID

        [Required(ErrorMessage = "Cost Title is required")] //Not null or empty string
        [Display(Name = "Cost Description")]
        public eCostTitle CostTitle { get; set; }           //Enum Type

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Cost Date")]
        public DateTime CostDate { get; set; }

        [Required(ErrorMessage = "Vehicle Odometer Mileage is required")] //Not null or empty string
        [Display(Name = "Odometer")]
        public int CostOdometerMileage { get; set; }
       
        [Display(Name = "Cost amount")]
        public double CostRunningCost { get; set; }

        /* //Removed as not required
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime CostStartDate { get; set; }
        */

        /* //Removed as not required
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime CostEndDate { get; set; }
        */

        [Display(Name = "Total Running Cost: €")]
        public double CostTotalRunningCost { get; }


        /* Old
        [Display(Name = "Total running cost")]
        public double CostTotalRunningCost
        {
             get
             {
                 double totalCost = 0;
                 totalCost += CostRunningCost;
                 return totalCost;
             }
         }
         * */


        //Navigation Property
        public virtual Vehicle Vehicle { get; set; }                  //NOT a Collection, as a Cost associated to only One Vehicle


        //ToString()
        public override string ToString()
        {
            return "Cost ID: " + CostID + ", Cost Date: " + CostDate + ", Cost Odometer: " + CostOdometerMileage +
                ", Cost Title: " + CostTitle + ", Running Cost: " + CostRunningCost + ", Cost Year: " + CostYear;
        }

        //Values retuned from Methods
        [Display(Name = "Running Cost Year")]
        public DateTime CostYear { get; }

        /*
        //Method
        public virtual void CostsAddRunning()
        {
            throw new System.NotImplementedException();
        }

        public virtual void CostTotal()
        {
            throw new System.NotImplementedException();
        }

        public virtual void CostAnnual()
        {
            throw new System.NotImplementedException();
        }

        public virtual void CostDynamic()
        {
            throw new System.NotImplementedException();
        }*/
    }
}