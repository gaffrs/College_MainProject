using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"	

namespace VehicleWebApp.Models
{
    //Enums
    public enum eNotificationTitle
    { VehicleBirthday, ServiceDateNotification, VehicleTestingDateRenewal, InsuranceDateRenewal,
        MotorTaxDateRenewal, ServiceMileageNotification }

    public enum eNotificationType { SMS, Email }

    public class Notification
    {
        //Property			                    //auto-implemented ReadWrite
        public int NotificationID { get; set; }                     //PK
        public int UserID { get; set; }                             //FK    Customer.UserID 
        public DateTime NotificationDate { get; set; }
        public DateTime NotificationSendDate { get; set; }
        public eNotificationType NotificationType { get; set; }     //Enum Type
        public eNotificationTitle NotificationTitle { get; set; }   //Enum Type

        //Navigation Property
        public User User { get; set; }              //NOT a Collection, as a Notification associated to only One User

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