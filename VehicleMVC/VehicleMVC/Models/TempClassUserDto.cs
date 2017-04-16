using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"

namespace VehicleMVC.Models
{
    public class TempClassUserDto
    {
        public int UserID { get; set; }

        public String Username { get; set; }
        [Display(Name = "Password")]
        public String UserPassword { get; set; }
        [Display(Name = "Email Address")]
        public String UserEmailAddress { get; set; }
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Number must be 10 digits long")]// string 10 characters long & no shorter than 10 characters
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Number must be 10 digits long")]
        [Display(Name = "Mobile Phone Number")]
        public String UserMobileNumber { get; set; }

        public eUserType UserType { get; set; }

        //Navigation Property
        public virtual List<VehicleDto> Vehicles { get; set; }
        public virtual List<NotificationDto> Notifications { get; set; }

        //ToString()
        public override string ToString()
        {
            return "User ID: " + UserID + ", Username: " + Username + ", Password: " + UserPassword +
                ", Email Address: " + UserEmailAddress + ", UserMobileNumber: " + UserMobileNumber + ", User Type: " + UserType;
        }
    }
}