using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleMVC.Models
{
    //Enums user types
    public enum eUserType { Basic, PRO }
    public class User
    {
        [Key, ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }


        /*

                [Key]                                   //implies Primary Key PK
                public int UserID { get; set; }

                [Required(ErrorMessage = "Username is required")] //Not null or empty string
                public String Username { get; set; }

                [Required(ErrorMessage = "Password is required")] //Not null or empty string
                [Display(Name = "Password")]
                public String UserPassword { get; set; }


                [Required(ErrorMessage = "Email address is required")]
                [EmailAddress(ErrorMessage = "Invalid Email Address")]
                [Display(Name = "Email Address")]
                public String UserEmailAddress { get; set; }

                [Required(ErrorMessage = "Number must not be blank")]   //Not null or empty string
                [StringLength(10, MinimumLength = 10, ErrorMessage = "Number must be 10 digits long")]// string 10 characters long & no shorter than 10 characters
                [RegularExpression(@"^\d{10}$", ErrorMessage = "Number must be 10 digits long")]
                [Display(Name = "Mobile Phone Number")]
                public String UserMobileNumber { get; set; }

                public eUserType UserType { get; set; }

                //Navigation Property
                public virtual List<Vehicle> Vehicles { get; set; }          //Collection and refers to Vehicle
                public virtual List<Notification> Notifications { get; set; }//Collection and refers to Notification

                //ToString()
                public override string ToString()
                {
                    return "User ID: " + UserID + ", Username: " + Username + ", Password: " + UserPassword +
                        ", Email Address: " + UserEmailAddress + ", UserMobileNumber: " + UserMobileNumber + ", User Type: " + UserType;
                }

                /*
                public int CreditCardNumber { get; set; }
                public int CreditCardExpMonth { get; set; }
                public int CreditCardExpYear { get; set; }
                public int CreditCardSecurityCode { get; set; }
                public int CreditCardAuthorisationNumber { get; set; }
                */


    }
}


/*
    //Create a Users collection in memory and populate with some users
    class Users
    {
    static void Main()
    {
        // Create a list of customers.
        List<User> Users = new List<User>();  //strongly typed list of objects that can be accessed by index.

        // Add customers to the list.
        Users.Add(new User() { Username = "Colm1", UserPassword = "123456", UserEmailAddress = "Colm@gmail.com", UserMobileNumber = 0871234567, UserType = Customer.eUserType.Basic });
        Users.Add(new User() { Username = "John1", UserPassword = "234567", UserEmailAddress = "John@gmail.com", UserMobileNumber = 0871111111, UserType = Customer.eUserType.PRO });
        Users.Add(new User() { Username = "Mick1", UserPassword = "345678", UserEmailAddress = "Mick@gmail.com", UserMobileNumber = 0872222222, UserType = Customer.eUserType.Basic });
    }
/*







/*
            //Method
            public virtual void UserAdd()
            {
                throw new System.NotImplementedException();
            }

            public virtual void UserEdit()
            {
                throw new System.NotImplementedException();
            }

            public virtual void UserDelete()
            {
                throw new System.NotImplementedException();
            }

            public virtual void UserLogin()
            {
                throw new System.NotImplementedException();
            }

            public virtual void UserLogout()
            {
                throw new System.NotImplementedException();
            }

            public virtual void UserGetAuthorisation()
            {
                throw new System.NotImplementedException();
            }

            public virtual void UserGetAuthorisationNumber()
            {
                throw new System.NotImplementedException();
            }

            public virtual void UserGetAuthorisationReceipt()
            {
                throw new System.NotImplementedException();
            }

        */
