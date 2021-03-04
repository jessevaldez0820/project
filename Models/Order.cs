using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Group25_Final_Project.Models
{
   
    public class Order
    {
        private const Decimal TAX_RATE = 0.0825m;
        public Int32 OrderID { get; set; }

        public Int32 TransactionNumber { get; set; }


        public DateTime OrderDate { get; set; }

        public String GiftRec { get; set; }
        /// 
        /// Is there a reason we decided not to do a boolean here?
        /// 
        public Boolean GiftAttribute { get; set; }
        
        public Boolean Confirmation { get; set; }

        public Boolean IsCancelled { get; set; }

        
        [Display(Name = "Order Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Subtotal
        {
            get { return Tickets.Sum(t => t.TicketPrice); }
        }

        [Display(Name = "Tax Fee (15%)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Tax
        {
            get { return Subtotal * TAX_RATE; }
        }

        [Display(Name = "Order Total:")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Total 
        {
            get { return Subtotal + Tax; }
        }


        public List<Ticket> Tickets { get; set; }

        public Order()
        {
            if (Tickets == null)
            {
                Tickets = new List<Ticket>();
            }
        }

        public AppUser AppUser { get; set; }

    }

    /*public void CalcSubtotals()
    {
        Total
    }
    */
}
