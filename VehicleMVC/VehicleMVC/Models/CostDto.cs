using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"

namespace VehicleMVC.Models
{
    public class CostDto
    {
        //Property			                    //auto-implemented ReadWrite
        public int CostID { get; set; }                     //PK
        public int VehicleID { get; set; }                  //FK    Vehicle.VehicleID

        [Display(Name = "Cost Date")]
        public DateTime CostDate { get; set; }

        [Display(Name = "Cost Odometer")]
        public int CostOdometerMileage { get; set; }

        [Display(Name = "Cost Title")]
        public eCostTitle CostTitle { get; set; }           //Enum Type

        [Display(Name = "Running Cost")]
        public double CostRunningCost { get; set; }

        [Display(Name = "Running Cost Start Date")]
        public DateTime CostStartDate { get; set; }
        [Display(Name = "Running Cost End Date")]
        public DateTime CostEndDate { get; set; }

        //Calculations
        [Display(Name = "Running Cost Year")]
        public DateTime CostYear { get; set; }

        //Navigation Property
        public virtual Vehicle Vehicle { get; set; }                  //NOT a Collection, as a Cost associated to only One Vehicle


        //ToString()
        public override string ToString()
        {
            return "Cost ID: " + CostID + ", Cost Date: " + CostDate + ", Cost Odometer: " + CostOdometerMileage +
                ", Cost Title: " + CostTitle + ", Running Cost: " + CostRunningCost + ", Cost Year: " + CostYear +
                ", Cost Start Date: " + CostStartDate + ", Cost End Date: " + CostEndDate;
        }
    }
}