using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Group25_Final_Project.Models
{
    public class AppUser : IdentityUser
    {
        ///UserID: built in identity field for the unique identifier for the user
        ///First Name: Required, you will need to create this field in the user table
        [Display(Name = "First Name: ")]
        //[Required(ErrorMessage = "First name is required.")]
        public String FirstName { get; set; }

        //
        public String Initial { get; set; }

        //[Required(ErrorMessage = "Last name is required.")]
        ///Last Name: Required, you will need to create this field in the user table
        [Display(Name = "Last Name: ")]
        public String LastName { get; set; }



        [Display(Name = "Customer Number:")]
        public Int32 CustomerNumber { get; set; }



        //Birthday
        [Required(ErrorMessage = "Birthday is required.")]
        //We need to be sure they are over 18, How??###################################
        public DateTime Birthday { get; set; }

        public String SocialSecurity { get; set; }

        //
        public String Address { get; set; }

        //
        public String City { get; set; }

        //
        public String State { get; set; }

        //
        public String ZipCode { get; set; }

        public String EmpType { get; set; }

        public List<Review> Reviews { get; set; }

        //Popcorn Points
        public Int64 PopcornPoints { get; set; }

        public List<Order> Orders { get; set; }
        
        public AppUser()
        {
            
            if (Reviews == null)
            {
                Reviews = new List<Review>();
            }
            if (Orders == null)
            {
                Orders =  new List<Order>();
            }

        }
        //ActiveUser: Could not find this in instructions, we may not need it##############
        //In case we do
        //public Boolean ActiveUser { get; set; }
    }
}
 
