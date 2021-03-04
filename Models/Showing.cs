using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Group25_Final_Project.Models
{

    public enum ShowingStatus
    {
        
        Approved,
        Pending,
        Cancelled
    }

    public class Showing
    {
        public Int32 ShowingID { get; set; }

        //[DataType(DataType.Date)]
        public DateTime StartTime { get; set; }

        //[DataType(DataType.Date)]
        public DateTime EndTime { get; set; }

        public String TheaterNo { get; set; }


        public Int32 SeatCount { get; set; }
       
        
        public Schedule Schedule {get; set; }


        public ShowingStatus ShowingStatus { get; set; }

        public Boolean SpecialEvent { get; set; }

        public Movie Movie { get; set; }

        public List<Ticket> Tickets { get; set; }



        public Showing()
        {
            if (Tickets == null)
            {
                Tickets = new List<Ticket>();
            }

        }


    }
}
