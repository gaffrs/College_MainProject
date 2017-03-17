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
        public DateTime CostDate { get; set; }
        public int CostOdometerMileage { get; set; }
        public eCostTitle CostTitle { get; set; }           //Enum Type
        public double CostRunningCost { get; set; }
        public DateTime CostYear { get; set; }
        public DateTime CostStartDate { get; set; }
        public DateTime CostEndDate { get; set; }

        //Navigation Property
        public Vehicle Vehicle { get; set; }                  //NOT a Collection, as a Cost associated to only One Vehicle


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
