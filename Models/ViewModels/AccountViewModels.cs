using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

//TODO: Change this namespace to match your project
namespace Group25_Final_Project.Models
{
    //NOTE: This is the view model used to allow the user to login
    //The user only needs the email and password to login
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

    //NOTE: This is the view model used to register a user
    //When the user registers, they only need to specify the
    //properties listed in this model
    public class RegisterViewModel
    {
        //NOTE: Here is the property for email
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //NOTE: Here is the property for phone number
        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        //TODO: Add any fields that you need for creating a new user
        //First name is provided as an example
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        public String MiddleInitial { get; set; }

        //Last name should be here
        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Birthday is required.")]
        //We need to be sure they are over 18, How??###################################
        public DateTime Birthday { get; set; }


        //
        public String Street { get; set; }

        //
        public String City { get; set; }

        //
        public String State { get; set; }

        //
        public String ZipCode { get; set; }

        public Int64 PopcornPoints { get; set; }

        //NOTE: Here is the logic for putting in a password
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    //NOTE: This is the view model used to allow the user to 
    //change their password
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
    //NOTE: This is the view model used to allow the user to 
    //change their password
    public class ChangeBirthdayViewModel
    {
       
        [Display(Name = "Enter Birthday")]
        [Required(ErrorMessage = "Birthday is required.")]
        public DateTime Birthday { get; set; }

    }
    public class ChangePhoneNumberViewModel
    {
        //NOTE: Here is the property for phone number
        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

    }
    public class ChangeStreetViewModel
    {
        [Required]
        [Display(Name = "Enter new Street Address")]
        public String Street { get; set; }
    
        [Required]
        [Display(Name = "Enter State")]
        public String State { get; set; }

        [Required]
        [Display(Name = "Enter City")]
        public String City { get; set; }

        [Required]
        [Display(Name = "Enter Zip Code")]
        public String ZipCode { get; set; }

    }
//NOTE: This is the view model used to display basic user information
//on the index page
public class IndexViewModel : AppUser
    {
        public bool HasPassword { get; set; }
        //public String UserName { get; set; }
        //public String Email { get; set; }
        public String UserID { get; set; }
        public String UserStreet { get; set; }
        public String UserState { get; set; }
        public String UserCity { get; set; }
        public String UserZipCode { get; set; }
        //public String PhoneNumber { get; set; }
    }
}