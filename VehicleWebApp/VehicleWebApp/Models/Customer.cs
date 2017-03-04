using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"

namespace VehicleWebApp.Models
{
    public class Customer
    {

        public enum eUserType
        {
            Basic, PRO
        }

        [Key]                                   //implies Primary Key PK
        public int UserID { get; set; }


        [Required(ErrorMessage = "User Username is required")] //Not null or empty string
        public String Username { get; set; }


        [Required(ErrorMessage = "User Password is required")] //Not null or empty string
        public String UserPassword { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public String UserEmailAddress { get; set; }
        public int UserMobileNumber { get; set; }
        public eUserType UserType { get; set; }



        /*public int CreditCardNumber { get; set; }

        public int CreditCardExpMonth { get; set; }


        public int CreditCardExpYear { get; set; }


        public int CreditCardSecurityCode { get; set; }


        public int CreditCardAuthorisationNumber { get; set; }*/




        //ToString()
        public override string ToString()
        {
            return Username + " " + UserPassword + " " + UserEmailAddress + " " + UserMobileNumber;
        }
    }
}




/*
    //Create a Users collection in memory and populate with some users
    class Users
    {
    static void Main()
    {
        // Create a list of customers.
        List<Customer> customers = new List<Customer>();  //strongly typed list of objects that can be accessed by index.

        // Add customers to the list.
        customers.Add(new Customer() { Username = "Colm1", UserPassword = "123456", UserEmailAddress = "Colm@gmail.com", UserMobileNumber = 0871234567, UserType = Customer.eUserType.Basic });
        customers.Add(new Customer() { Username = "John1", UserPassword = "234567", UserEmailAddress = "John@gmail.com", UserMobileNumber = 0871111111, UserType = Customer.eUserType.PRO });
        customers.Add(new Customer() { Username = "Mick1", UserPassword = "345678", UserEmailAddress = "Mick@gmail.com", UserMobileNumber = 0872222222, UserType = Customer.eUserType.Basic });
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

