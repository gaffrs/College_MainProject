using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"
using Microsoft.AspNet.Identity;

namespace VehicleAppMVC.Models
{
    //Enums
    public enum eNotificationTitle
    {
        [Display(Name = "Vehicle Birthday")] VehicleBirthday,
        [Display(Name = "Service Date Notification")] ServiceDateNotification,
        [Display(Name = "Vehicle Testing DateRenewal")] VehicleTestingDateRenewal,
        [Display(Name = "Insurance Date Renewal")] InsuranceDateRenewal,
        [Display(Name = "Motor Tax Date Renewal")] MotorTaxDateRenewal,
        [Display(Name = "Service Mileage Notification")] ServiceMileageNotification
    }

    public enum eNotificationType { SMS, Email }

    public class Notification
    {
            //Enums
    public enum eNotificationTitle
    {
        [Display(Name = "Vehicle Birthday")] VehicleBirthday,
        [Display(Name = "Service Date Notification")] ServiceDateNotification,
        [Display(Name = "Vehicle Testing DateRenewal")] VehicleTestingDateRenewal,
        [Display(Name = "Insurance Date Renewal")] InsuranceDateRenewal,
        [Display(Name = "Motor Tax Date Renewal")] MotorTaxDateRenewal,
        [Display(Name = "Service Mileage Notification")] ServiceMileageNotification
    }

        //Property			                    //auto-implemented ReadWrite
        public int NotificationID { get; set; }                     //PK
        public string ApplicationUserId { get; set; }               //FK to AspNetUsers UserId 
        //public int UserID { get; set; }                           //FK    Customer.UserID 

        [Display(Name = "Notification Title")]
        public eNotificationTitle NotificationTitle { get; set; }   //Enum Type  
            
        [Display(Name = "Notification Type")]
        public eNotificationType NotificationType { get; set; }     //Enum Type

        [Required(ErrorMessage = "Notification Date is required")]   //Not null or empty string
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Notification Date")]
        public DateTime NotificationDate { get; set; }

        [Required(ErrorMessage = "Notification Send Date is required")]   //Not null or empty string
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Send Date")]
        public DateTime NotificationSendDate { get; set; }


        //Navigation Property
        [Display(Name = "Application User")]
        public virtual ApplicationUser ApplicationUser { get; set; }
 
        //ToString()
        public override string ToString()
        {
            return "Notification ID: " + NotificationID + ", Notification Date: " + NotificationDate + ", Notification Send Date: " + NotificationSendDate +
                ", Notification Type: " + NotificationType + ", Notification Title: " + NotificationTitle;
        }

        /*
                //Method

                public virtual void NotificationSMS()
                {
                    throw new System.NotImplementedException();
                }

                public virtual void NotificationEmail()
                {
                    throw new System.NotImplementedException();
                }
        */
    }
}