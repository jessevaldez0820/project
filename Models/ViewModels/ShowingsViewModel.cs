using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Group25_Final_Project.Models

{
    public enum SeatSort { Above, Below };
    //public enum MpaaRating { NoPreference, G, PG, PG13, R, Unrated };
    public class ShowingsViewModel : Showing
    {

        [Display(Name = "Search by Movie:")]
        public String MovieMovie { get; set; }

        [Display(Name = "Search by Movie: ")]
        public Int32 SelectedMovieID { get; set; }

        [Display(Name = "Search by Start Time:")]
        [DataType(DataType.Date)]
        //DateTime?  means this date is nullable - we want to allow them to 
        //be able to NOT select a date
        public DateTime? MovieStartTime { get; set; }

        [Display(Name = "Search by End Time:")]
        [DataType(DataType.Time)]
        //DateTime?  means this date is nullable - we want to allow them to 
        //be able to NOT select a date
        public DateTime? MovieEndTime { get; set; }

        [Display(Name = "Select a Future Showtime:")]
        [DataType(DataType.Date)]
        //DateTime?  means this date is nullable - we want to allow them to 
        //be able to NOT select a date
        public DateTime? MovieShowtime { get; set; }

        [Display(Name = "Search by Seat Count:")]
        [Range(minimum: 0, maximum: 20, ErrorMessage = "Seat Count must be between 1 and 20")]
        public Decimal CountSeat { get; set; }

        [Display(Name = "Less than or Greater than Filter for Movies")]
        public SeatSort AscendingDescending { get; set; }



    }
}
