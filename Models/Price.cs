using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Group25_Final_Project.Models
{
    public class Price
    {
        public Int32 PriceID { get; set; }

        
        //BasePrice = 12
        public Decimal BasePrice { get; set; }

        //Mantinee Price = 5 MTWThF
        public Decimal Matinee { get; set; }

        //WeekDayAfternoon MWTF Price = 10
        public Decimal WeekdayAfternoon { get; set; }

        //Tuesday Afternoon = 8
        public Decimal TuesdayAfternoon { get; set; }

        //Weekend Price starting at 12:00PM Friday and ending on Sunday = 12
        public Decimal Weekend { get; set; }

        //Special Event = 12 no discounts no matter what
        public Decimal SpecialEvent { get; set; }

        //Senior citizen discount = 2
        public Decimal SeniorCitizen { get; set; }
        
        /*
        public String PriceType { get; set; }


        public Decimal Amount { get; set; }
        */
    }
}
