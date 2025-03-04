﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReteaSocialaMDS.Models
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

        [StringLength(30), Required]
        [Display(Name = "First name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }


        [StringLength(30), Required]
        [Display(Name = "Last name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }


        [StringLength(100), Required]
        [DataType(DataType.MultilineText)]
        public string AdressName { get; set; }


        [StringLength(15)]
        [Display(Name = "Twitter Handle")]
        [DataType(DataType.Text)]
        public string TwitterHandle { get; set; }

      
        [Display(Name = "Birth date")]
        [DataType(DataType.DateTime)]
        [CheckDate]
        public string BirthDate { get; set; }

       
       
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

    public class UserDetailsViewModel
    {
        
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "First name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }


        
        [Display(Name = "Last name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }


        
        [DataType(DataType.MultilineText)]
        public string AdressName { get; set; }


        
        [Display(Name = "Twitter Handle")]
        [DataType(DataType.Text)]
        public string TwitterHandle { get; set; }


        [Display(Name = "Birth date")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Account creation date and time")]
        [DataType(DataType.DateTime)]
        public DateTime AccountCreation{ get; set; }


    }
}
