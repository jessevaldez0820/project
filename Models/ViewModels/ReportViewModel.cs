using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Group25_Final_Project.Models
{
    public class AllMoviesReportViewModel
    {
        public String Title { get; set; }

        public String SelectedSeat { get; set; }

        public Int32 TransactionNumber { get; set; }

        public String CustomerName { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal TicketPrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ProfitMargin { get; set; }

        public DateTime OrderDate { get; set; }

        public IEnumerable<AppUser> Customers { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }

    public class OrderReportVM
    {
        public List<string> MovieNandS { get; set; }

        public Int32 TransactionNumber { get; set; }

        public String CustomerName { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal OrderTotal { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ProfitMargin { get; set; }

        public DateTime OrderDate { get; set; }

        public String Payment { get; set; }

        public IEnumerable<AppUser> Customers { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }

    public class CustomerReportVM
    {
        public String FirstName { get; set; }

        public List<string> MovieNandS { get; set; }

        public List<string> TransactionNumbers { get; set; }

        public Decimal CustomerTotal { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ProfitMargin { get; set; }

        public IEnumerable<AppUser> Customers { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }

    public class ReportDVM
    {
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal TR { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal TC { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal TP { get; set; }

        public IEnumerable<AppUser> Customers { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }

    public class InventoryReportVM
    {

        public String Title { get; set; }

        public Int32 SeatsAvailable { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal WeightedAvgCost { get; set; }


        public IEnumerable<AppUser> Customers { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}