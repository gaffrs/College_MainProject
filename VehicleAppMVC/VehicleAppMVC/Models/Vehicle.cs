using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"	
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace VehicleAppMVC.Models
{
    //Enums
    public enum eSettingFuelType { Petrol, Diesel }

    public enum eSettingDistance { Km, Miles }

    public enum eSettingVolume
    {
        //Litres = 0,
        //[EnumMember(Value = "UK Gal")]
        //UKGal = 1,
        //[EnumMember(Value = "US Gal")]
        //USGal = 2
        [Display(Name = "Litres")] Litres_L,
        [Display(Name = "UK Gal")] UK_Gal,
        [Display(Name = "US Gal")] US_Gal
    }
    

    public enum eSettingConsumption
    {
        [Display(Name = "L/100Km")] Lper100km,
        [Display(Name = "Mpg US")] Mpg_US,
        [Display(Name = "Mpg UK")] Mpg_UK
    }

    public class Vehicle
    {

        [Key]                                   //implies Primary Key PK
        public int VehicleID { get; set; }
        public string ApplicationUserId { get; set; }               //FK to AspNetUsers UserId 
        //public int UserID { get; set; }                           //FK    Customer.UserID  

        [Required(ErrorMessage = "Vehicle Make is required")]       //Not null or empty string
        [Display(Name = "Vehicle Make")]
        public String VehicleMake { get; set; }

        [Required(ErrorMessage = "Vehicle Model is required")]      //Not null or empty string
        [Display(Name = "Vehicle Model")]
        public String VehicleModel { get; set; }

        [Required(ErrorMessage = "Vehicle Registration Number is required")] //Not null or empty string
        [Display(Name = "Vehicle Registration No.")]
        public String VehicleRegistrationNumber { get; set; }

        [Required(ErrorMessage = "Vehicle Odometer Mileage is required")] //Not null or empty string
        [Display(Name = "Vehicle Odometer")]
        public int VehicleOdometerMileage { get; set; }

        [Required(ErrorMessage = "Fuel Type Setting is required")]  //Not null or empty string
        [Display(Name = "Vehicle Fuel type")]
        public eSettingFuelType SettingFuelType { get; set; }       //Enum Type

        [Required(ErrorMessage = "Distance Setting is required")]   //Not null or empty string
        [Display(Name = "Distance unit")]
        public eSettingDistance SettingDistance { get; set; }       //Enum Type

        [Required(ErrorMessage = "Volume Setting is required")]     //Not null or empty string
        [Display(Name = "Volume unit")]
        public eSettingVolume SettingVolume { get; set; }           //Enum Type

        [Required(ErrorMessage = "Consumption Setting is required")] //Not null or empty string
        [Display(Name = "Consumption unit")]
        public eSettingConsumption SettingConsumption { get; set; } //Enum Type

        //Navigation Property
        public virtual ApplicationUser ApplicationUser { get; set; }       //NOT a Collection, as a Vehicle associated to only One User     
        public virtual List<Cost> Costs { get; set; }           //Collection and refers to Cost
        public virtual List<Fuel> Fuels { get; set; }           //Collection and refers to Fuel

        //ToString()
        public override string ToString()
        {
            return "Vehicle ID: " + VehicleID + ", Vehicle  Make: " + VehicleMake + ", Vehicle  Model: " + VehicleModel +
                ", Vehicle Registration Number: " + VehicleRegistrationNumber + ", Vehicle Odometer: " + VehicleOdometerMileage +
                ", Vehicle Fuel Type: " + SettingFuelType + ", Distance unit: " + SettingDistance + ", Volume unit: " + SettingVolume +
                ", Consumption Unit: " + SettingConsumption;
        }

        /*
                static void Main()
                {
                    // Create a list of users.
                    List<Vehicle> Vehicles = new List<Vehicle>();  //strongly typed list of objects that can be accessed by index.

                    vehicles.Add(new Vehicle() { VehicleMake = "Opel", VehicleModel = "Vectra", VehicleRegistrationNumber = "161D171", VehicleOdometerMileage = 1600, SettingFuelType = eSettingFuelType.Petrol, SettingDistance = eSettingDistance.Km, SettingVolume = eSettingVolume.Litres_L, SettingConsumption = eSettingConsumption.Lper100km });
                    vehicles.Add(new Vehicle() { VehicleMake = "Mercedes", VehicleModel = "C-Class", VehicleRegistrationNumber = "161D181", VehicleOdometerMileage = 1300, SettingFuelType = eSettingFuelType.Diesel, SettingDistance = eSettingDistance.Km, SettingVolume = eSettingVolume.Litres_L, SettingConsumption = eSettingConsumption.Lper100km });
                    vehicles.Add(new Vehicle() { VehicleMake = "Subaru", VehicleModel = "Impreza", VehicleRegistrationNumber = "161D200", VehicleOdometerMileage = 2500, SettingFuelType = eSettingFuelType.Petrol, SettingDistance = eSettingDistance.Miles, SettingVolume = eSettingVolume.UK_Gal, SettingConsumption = eSettingConsumption.Mpg_UK });
                    vehicles.Add(new Vehicle() { VehicleMake = "Volkswagen", VehicleModel = "Polo", VehicleRegistrationNumber = "161D250", VehicleOdometerMileage = 1000, SettingFuelType = eSettingFuelType.Petrol, SettingDistance = eSettingDistance.Miles, SettingVolume = eSettingVolume.US_Gal, SettingConsumption = eSettingConsumption.Mpg_US });
                }
        */
    }
}