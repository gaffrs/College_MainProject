//colm 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"	

namespace VehicleWebApp.Models
{
    public class Cost
    {
        public enum eCostTitle
        {
            Tyres, Tax, Service, NCTorDOE, Insurance, Testing,
        }

        //Property			                    //auto-implemented ReadWrite
        
        public int costID { get; set; }
        public DateTime costDate { get; set; }
        public int costOdometerMileage { get; set; }
        public eCostTitle costTitle { get; set; }       //Enum Type
        public double costRunningCost { get; set; }
        public DateTime costYear { get; set; }
        public DateTime costStartDate { get; set; }
        public DateTime costEndDate { get; set; }

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