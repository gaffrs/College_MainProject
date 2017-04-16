using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"
using Microsoft.AspNet.Identity;

namespace VehicleMVC.Models
{
    //Enums
    public enum eNotificationTitle
    {
        VehicleBirthday, ServiceDateNotification, VehicleTestingDateRenewal, InsuranceDateRenewal,
        MotorTaxDateRenewal, ServiceMileageNotification
    }

    public enum eNotificationType { SMS, Email }

    public class Notification
    {
        //Property			                    //auto-implemented ReadWrite
        public int NotificationID { get; set; }                     //PK
        public int UserID { get; set; }                             //FK    Customer.UserID 

        [Required(ErrorMessage = "Notification Date is required")]   //Not null or empty string
        [Display(Name = "Notification Date")]
        public DateTime NotificationDate { get; set; }

        [Required(ErrorMessage = "Notification Send Date is required")]   //Not null or empty string
        [Display(Name = "Notification Send Date")]
        public DateTime NotificationSendDate { get; set; }
        [Display(Name = "Notification Type")]
        public eNotificationType NotificationType { get; set; }     //Enum Type
        [Display(Name = "Notification Title")]
        public eNotificationTitle NotificationTitle { get; set; }   //Enum Type

        //Navigation Property
        public virtual UserLoginInfo User { get; set; }              //NOT a Collection, as a Notification associated to only One User


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