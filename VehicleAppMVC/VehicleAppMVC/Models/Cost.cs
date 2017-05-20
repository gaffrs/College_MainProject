using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"

namespace VehicleAppMVC.Models
{
//Enum costs
public enum eCostTitle { Insurance, Service, Tax, [Display(Name = "Testing: NCT or DOE")]Testing , Tyres }

    public class Cost
    {
        //Property			                    //auto-implemented ReadWrite
        public int CostID { get; set; }                     //PK
        public int VehicleID { get; set; }                  //FK    Vehicle.VehicleID

        [Required(ErrorMessage = "Cost Title is required")] //Not null or empty string
        [Display(Name = "Cost Description")]
        public eCostTitle CostTitle { get; set; }           //Enum Type

        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Cost Date")]
        public DateTime CostDate { get; set; }

        [Required(ErrorMessage = "Vehicle Odometer Mileage is required")] //Not null or empty string
        [Display(Name = "Odometer")]
        public int CostOdometerMileage { get; set; }

        //[DisplayFormat(NullDisplayText = "", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        [Display(Name = "Cost amount")]
        public double CostRunningCost { get; set; }
 
        //Navigation Property
        public virtual Vehicle Vehicle { get; set; }                  //NOT a Collection, as a Cost associated to only One Vehicle

    }
}