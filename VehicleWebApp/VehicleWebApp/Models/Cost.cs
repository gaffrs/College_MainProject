using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"

namespace VehicleWebApp.Models
{
    //Enum costs
    public enum eCostTitle { Tyres, Tax, Service, NCTorDOE, Insurance, Testing }

    public class Cost
    {
        //Property			                    //auto-implemented ReadWrite
        public int CostID { get; set; }                     //PK
        public int VehicleID { get; set; }                  //FK    Vehicle.VehicleID

        [Display(Name = "Cost Date")]
        public DateTime CostDate { get; set; }

        [Required(ErrorMessage = "Vehicle Odometer Mileage is required")] //Not null or empty string
        [Display(Name = "Cost Odometer")]
        public int CostOdometerMileage { get; set; }

        [Required(ErrorMessage = "Cost Title is required")] //Not null or empty string
        [Display(Name = "Cost Title")]
        public eCostTitle CostTitle { get; set; }           //Enum Type

        [Display(Name = "Running Cost Start Date")]
        public DateTime CostStartDate { get; set; }
        [Display(Name = "Running Cost End Date")]
        public DateTime CostEndDate { get; set; }


        //Values retuned from Methods
        [Display(Name = "Running Cost")]
        public double CostRunningCost { get; }
        [Display(Name = "Running Cost Year")]
        public DateTime CostYear { get; }


        //Navigation Property
        public virtual Vehicle Vehicle { get; set; }                  //NOT a Collection, as a Cost associated to only One Vehicle


        //ToString()
        public override string ToString()
        {
            return "Cost ID: " + CostID + ", Cost Date: " + CostDate + ", Cost Odometer: " + CostOdometerMileage +
                ", Cost Title: " + CostTitle + ", Running Cost: " + CostRunningCost + ", Cost Year: " + CostYear + 
                ", Cost Start Date: " + CostStartDate + ", Cost End Date: " + CostEndDate;
        }

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
