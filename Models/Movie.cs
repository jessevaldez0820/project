using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Group25_Final_Project.Models
{
     public class Movie       
    
    {
        [Required(ErrorMessage = "Movie ID is required.")]
        public Int32 MovieID { get; set; }

        public Int32 MovieNumber { get; set; }

        [Required(ErrorMessage = "Movie Title is required.")]
        public String Title { get; set; }

        //Creating an instance of genre to create a one to many relationship
        //This is the one side of the one to many relationship
        //[Required(ErrorMessage = "Genre is required.")]
        public Genre Genre { get; set; }

        public String Overview { get; set; }

        [Required(ErrorMessage = "Release date is required.")]
        public DateTime ReleaseDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:c2}")]
        public Decimal Revenue { get; set; }

        [Required(ErrorMessage = "Running time is required.")]
        public Int32 RunningTime { get; set; }

        //Catchphrase or slogan
        public String Tagline { get; set; }


        //User can specify less than or greater than a decimal 1.0 and 5.0 inclusive
        //based on stars
        //public Decimal UserRatings { get; set; }

        /*
        public Decimal UserRatings 
        { 
            get { return Reviews.Average(r => r.Rating); } 
        }
        */
        //MPAA
        [Required(ErrorMessage = "MPAA rating is required.")]
        public String MPAARating { get; set; }

        [Required(ErrorMessage = "Actors is required.")]
        public String Actors { get; set; }

        public List<Showing> Showings { get; set; }

        public List<Review> Reviews { get; set; }

        public Movie()
        {
            if (Showings == null)
            {
                Showings = new List<Showing>();
            }
            if (Reviews == null)
            {
                Reviews = new List<Review>();
            }
        }


    }
}
