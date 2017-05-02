using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

//CG added
using System;
using System.ComponentModel;

namespace VehicleAppMVC.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email/UserName")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //CG added
        [Required(ErrorMessage = "The Mobile Phone Number must be provided to receive notifications")]
        [Phone]
        [Display(Name = "Mobile Phone Number")]
        public string PhoneNumber { get; set; }

        //vehicle Category  
        //Note Enum is at top of the IdentityModels so its removed from here.........public enum eVehicleUnits { KM, MilesUK, MilesUS }               //Enum Type
        [Required(ErrorMessage = "The Vehicle Unit Setting must be selected")]
        [DisplayName("Vehicle Unit Setting")]
        //public String VehicleUnit { get; set; }
        public eVehicleUnits VehicleUnit { get; set; }

/*
        //Vehicle category's
        public static String[] VehicleUnits       //array of Strings
        {
            get
            {
                return new String[] { "Km - Litres - L/100Km", "Miles - UK Gal - UK Mpg", "Miles - US Gal - US Mpg" };
            }

        }

        //vehicle Category  
        [Required(ErrorMessage = "Required field")]
        [DisplayName("Vehicle Unit Setting")]
        public String sVehicleUnit { get; set; }

        /*
                //CG: Added 17/04/17
                [Required(ErrorMessage = "Number must not be blank")]   //Not null or empty string
                [StringLength(10, MinimumLength = 10, ErrorMessage = "Number must be 10 digits long")]// string 10 characters long & no shorter than 10 characters
                [RegularExpression(@"^\d{10}$", ErrorMessage = "Number must be 10 digits long")]
                [Display(Name = "Mobile Phone Number")]
                public string UserMobileNumber { get; set; }
        */
        /*
                //CG: Added 17/04/17
                [DataType(DataType.PhoneNumber)]
                [Display(Name = "Phone Number")]
                [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number must be 10 digits long")]
                public string PhoneNumber { get; set; }

        */
        /*
                public ApplicationUser VehicleUnit { get; set; }
        */


    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
