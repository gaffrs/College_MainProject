using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"	

namespace VehicleWebApp.Models
{
    public class Notification
    {
        //Enums
        public enum eNotificationTitle
        {
            VehicleBirthday, ServiceDateNotification, VehicleTestingDateRenewal, InsuranceDateRenewal,
            MotorTaxDateRenewal, ServiceMileageNotification,
        }

        public enum eNotificationType
        {
            SMS, Email,
        }

        //Property			                    //auto-implemented ReadWrite
        public int notificationID { get; set; }
        public DateTime notificationDate { get; set; }
        public DateTime notificationSendDate { get; set; }
        public eNotificationType notificationType { get; set; }     //Enum Type
        public eNotificationTitle notificationTitle { get; set; }   //Enum Type


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