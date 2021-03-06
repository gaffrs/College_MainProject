﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Collections;

namespace VehicleAppMVC.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
        public eVehicleUnits VehicleUnit { get; set; }     //CG added so that they appear on Manage Index
        public string UserName { get; set; }        //CG added so that they appear on Manage Index
        public ArrayList Consumption { get; set; } //CG added so that they appear on Manage Index
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }


    //CG added to get Edit UserName & PhoneNumber
    public class ChangeUsernameAndEmail
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email/UserName")]
        public string UserName { get; set; }
    }

    //CG added to get Edit UserName & PhoneNumber
    public class ChangePhonenumber
    {
        [Required(ErrorMessage = "The Mobile Phone Number must be provided to receive notifications")]
        [Phone]
        [Display(Name = "Mobile Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ChangeVehicleUnitSettings
    {
        //vehicle Category  
        [Required(ErrorMessage = "The Vehicle Unit Setting must be selected")]
        [Display(Name = "Vehicle Unit Setting")]
        //public String VehicleUnit { get; set; }
        public eVehicleUnits VehicleUnit { get; set; }
    }

    public class DeleteUserViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email/UserName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }
    }
    




}