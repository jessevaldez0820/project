using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group25_Final_Project.Models
{
    public enum Status { Confirmed, Pending };

            
    public class Schedule
    {
        
        public Int32 ScheduleID { get; set; }

        public List<Showing> Showings { get; set; }

       

        public  Status Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
