using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Group25_Final_Project.Models

{
    public enum MovieSort { Ascending, Descending };
    public enum MpaaRating { NoPreference,G, PG, PG13, R, Unrated };
    public class SearchViewModel : Movie
    {
        [Display(Name = "Search by Title: ")]
        public String MovieTitle { get; set; }

        [Display(Name = "Search by Tagline:")]
        public String MovieTagline { get; set; }

        [Display(Name = "Search by Genre:")]
        public String MovieGenre { get; set; }

        [Display(Name = "Search by Genre: ")]
        public Int32 SelectedGenreID { get; set; }

        [Display(Name = "Search by MPAA Rating:")]
        public MpaaRating MPAA { get; set; }

        [Display(Name = "Search by Release Date:")]
        [DataType(DataType.Date)]
        //DateTime?  means this date is nullable - we want to allow them to 
        //be able to NOT select a date
        public DateTime? MovieReleaseDate { get; set; }

        [Display(Name = "Select a Run Time:")]
        [DataType(DataType.Time)]
        //DateTime?  means this date is nullable - we want to allow them to 
        //be able to NOT select a date
        public DateTime? MovieRunTime { get; set; }

        [Display(Name = "Select a Future Showtime:")]
        [DataType(DataType.Date)]
        //DateTime?  means this date is nullable - we want to allow them to 
        //be able to NOT select a date
        public DateTime? MovieShowtime { get; set; }

        [Display(Name = "Search by User Rating:")]
        [Range(minimum: 1, maximum: 5, ErrorMessage = "User Rating must be between 1.0 and 5.0")]
        public Decimal UserRating { get; set; }


        [Display(Name = "Ascending or Descending Filter for Movies")]
        public MovieSort AscendingDescending { get; set; }

        [Display(Name = "Search by Actors: ")]
        public String MovieActors{ get; set; }


    }
}
