using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Group25_Final_Project.Models
{
    //This is a linking table between customer and movie
    public class Review
    {
        public Int32 ReviewID { get; set; }

        //This is the user input

        [Display(Name = "Rating")]
        [Required(ErrorMessage = "Review Rating is required.")]
        [Range(1,5,ErrorMessage = "Please enter a value from 1 to 5")]
        public Decimal Rating { get; set; }



        [Display(Name = "Review Message")]
        [StringLength(280)]
        public String ReviewString { get; set; }


        //TODO: Ask Katie purpose of
        public Boolean Approved { get; set; }

        public Movie Movie { get; set; }

        //
        public AppUser AppUser  { get; set; }

        
    }
}
