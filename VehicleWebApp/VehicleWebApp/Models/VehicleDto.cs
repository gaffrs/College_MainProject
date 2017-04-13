using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"	

namespace VehicleWebApp.Models
{
     public class VehicleDto
    {
        [Key]                                   //implies Primary Key PK
        public int VehicleID { get; set; }

        public int UserID { get; set; }                             //FK    Customer.UserID

        [Display(Name = "Vehicle Make")]
        public String VehicleMake { get; set; }

        [Display(Name = "Vehicle Model")]
        public String VehicleModel { get; set; }

        [Display(Name = "Vehicle Registration No.")]
        public String VehicleRegistrationNumber { get; set; }

        [Display(Name = "Vehicle Odometer")]
        public int VehicleOdometerMileage { get; set; }

        [Display(Name = "Vehicle Fuel type")]
        public eSettingFuelType SettingFuelType { get; set; }       //Enum Type

        [Display(Name = "Distance unit")]
        public eSettingDistance SettingDistance { get; set; }       //Enum Type

        [Display(Name = "Volume unit")]
        public eSettingVolume SettingVolume { get; set; }           //Enum Type

        [Display(Name = "Consumption unit")]
        public eSettingConsumption SettingConsumption { get; set; } //Enum Type

        //Navigation Property
        public virtual User User { get; set; }                  //NOT a Collection, as a Vehicle associated to only One User
        public virtual List<CostDto> Costs { get; set; }    
        public virtual List<FuelDto> Fuels { get; set; }  

//        public virtual List<CostDto> Costs { get; set; }    
//        public virtual List<FuelDto> Fuels { get; set; }  

        //ToString()
        public override string ToString()
        {
            return "Vehicle ID: " + VehicleID + ", Vehicle  Make: " + VehicleMake + ", Vehicle  Model: " + VehicleModel +
                ", Vehicle Registration Number: " + VehicleRegistrationNumber + ", Vehicle Odometer: " + VehicleOdometerMileage +
                ", Vehicle Fuel Type: " + SettingFuelType + ", Distance unit: " + SettingDistance + ", Volume unit: " + SettingVolume +
                ", Consumption Unit: " + SettingConsumption;
        }
    }
}