using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"	

namespace VehicleAppMVC.Models
{
    public class NotificationDto
    {
        //Property			                    //auto-implemented ReadWrite
        public int NotificationID { get; set; }                     //PK
        public int UserID { get; set; }                             //FK    Customer.UserID 

        [Display(Name = "Notification Date")]
        public DateTime NotificationDate { get; set; }
        [Display(Name = "Notification Send Date")]
        public DateTime NotificationSendDate { get; set; }
        //[Display(Name = "Notification Type")]
        //public eNotificationType NotificationType { get; set; }     //Enum Type
        //[Display(Name = "Notification Title")]
        //public eNotificationTitle NotificationTitle { get; set; }   //Enum Type

        //Navigation Property
        public virtual ApplicationUser ApplicationUser { get; set; }

        //        public virtual User User { get; set; }              //NOT a Collection, as a Notification associated to only One User


        //ToString()
        public override string ToString()
        {
            return "Notification ID: " + NotificationID + ", Notification Date: " + NotificationDate + ", Notification Send Date: " + NotificationSendDate +
                ", Notification Type: " /*+ NotificationType + ", Notification Title: " + NotificationTitle*/;
        }
    }
}