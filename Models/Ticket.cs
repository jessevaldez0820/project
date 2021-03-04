using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Group25_Final_Project.Models
{
  
    public enum PaymentMethod { Cash, PopcornPoints };
  

    public class Ticket
    {

        public Int32 TicketID { get; set; }

        public String SelectedSeat { get; set; }

        public Boolean SeniorCitizen { get; set; }
       
        public Boolean Minor { get; set; }

        [Display(Name = "Do you want to pay with Popcorn Points? ")]
        public PaymentMethod PaymentMethod { get; set; }
        
        public Decimal TicketPrice { get; set; }

        [Display(Name = "Price of tickets:")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal TotalTicketFee { get; set; }

        public Showing Showing { get; set; }

        public Order Order { get; set; }

        /*
        //public List<String> SelectedSeats { get; set; }
        List<String> SelectedSeats = new List<String>(new string[]{"A1", "A2", "A3", "A4", "A5",
                                                                   "B1", "B2", "B3", "B4", "B5",
                                                                   "C1", "C2", "C3", "C4", "C5",
                                                                   "D1", "D2", "D3", "D4", "D5"});
        */
      
    }
}
