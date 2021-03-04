using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Group25_Final_Project.DAL;
using Group25_Final_Project.Models;

using Microsoft.AspNetCore.Authorization;

namespace Group25_Final_Project.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private readonly AppDbContext _context;

        public TicketsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Tickets

        public IActionResult Index(int? orderID)
        {
            if (orderID == null)
            {
                return View("Error", new String[] { "Please specify a order to view!" });
            }
            List<Ticket> ts = _context.Tickets
                                           .Include(od => od.Showing)
                                           .Where(od => od.Order.OrderID == orderID)
                                           .ToList();
        

          //
            return View(ts);
        }

        

        // GET: Tickets/Create
        //Only customers and employees can create tickets
       
        //[Authorize(Roles = "Customer,Manager,Employee")]
        public async Task<IActionResult> Create(int orderID)
        {
            Ticket t = new Ticket();
            Order dbOrder = _context.Orders.Find(orderID);
            t.Order = dbOrder;

            //populate the ViewBag with a list of existing products

            ViewBag.AllShowings = GetAllShowings();
            ViewBag.AllSeats = GetAllSeats();

            //pass the newly created  ticket to the view
            return View(t);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize(Roles = "Customer,Manager,Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketID,TransactionNumber, SelectedSeat,SeniorCitizen,PaymentMethod, LastName, FirstName, Order")] Ticket ticket, Movie movie, int SelectedShowing)
        {
            
            if (ModelState.IsValid == false)
            {
                ViewBag.AllShowings = GetAllShowings();
                ViewBag.AllSeats = GetAllSeats();
                return View(ticket);
            }
            

            Showing dbShowing = _context.Showings.Find(SelectedShowing);
            ticket.Showing = dbShowing;

            
            Order dbOrder = _context.Orders.Find(ticket.Order.OrderID);
            ticket.Order = dbOrder;

            String id = User.Identity.Name;
            AppUser appUser = _context.Users.FirstOrDefault(u => u.UserName == id);

            ticket.SeniorCitizen = CalSeniorCitizen(ticket, appUser);

            ticket.Minor = CalMinor(ticket, appUser);

            Price dbPrice = _context.Prices.FirstOrDefault(pr => pr.BasePrice == 12);

            ticket.TicketPrice = SetPrice(ticket, dbPrice, dbShowing);

            if (ticket.PaymentMethod == PaymentMethod.PopcornPoints)
            {
                if (Convert.ToInt32(appUser.PopcornPoints) > 100)
                {
                    appUser.PopcornPoints = SubPopcornPoints(appUser);
                }

                else
                {
                    return View("Error", new String[] { "You do not have enough popcorn points to purchase this ticket!" });
                }

            }

            if (ticket.PaymentMethod == PaymentMethod.Cash)
            {
                appUser.PopcornPoints = AddPopcornPoints(ticket, appUser);
            }


            if (movie.MPAARating == "R" || movie.MPAARating == "NC-17" && ticket.Minor == true)
            {
                return View("Error", new String[] { "You are not old enough to purhcase this ticket!" });
            }


            _context.Add(ticket);
            await _context.SaveChangesAsync();



            //add the course department to the database and save changes
            //_context.Tickets.Add(t);
            //_context.SaveChanges();

            //return View("Index");
            

            return RedirectToAction("Details","Orders", new { id = ticket.Order.OrderID });

        
        }




        // GET: Tickets/Edit/5
        //[Authorize(Roles = "Customer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Customer")]
        public async Task<IActionResult> Edit(int id, [Bind("TicketID,SelectedSeat")] Ticket ticket)
        {
            if (id != ticket.TicketID)
            {
                return View("Error", new String[] { "There was a problem editing this record. Try again!" });
            }

            if (ModelState.IsValid == false)
            {
                return View(ticket);
            }
            Ticket dbticket;
                try
                {
                dbticket = _context.Tickets
                     .Include(od => od.Showing)
                     .Include(od => od.Order)
                     .FirstOrDefault(od => od.TicketID == ticket.TicketID);

                //dbticket.SelectedSeat = ticket.SelectedSeat;


                _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                return View("Error", new String[] { "There was a problem editing this record", ex.Message });

            }
            return RedirectToAction(nameof(Index));
            
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Please specify a ticket to delete!" });
            }

            Ticket ticket = await _context.Tickets
                .Include(r => r.Order)
                .FirstOrDefaultAsync(m => m.TicketID == id);
            if (ticket == null)
            {
                return View("Error", new String[] { "This order detail was not in the database!" });
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {


            Ticket ticket = await _context.Tickets
                .Include(o => o.Order)
                .FirstOrDefaultAsync(o => o.TicketID == id);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Orders", new { id = ticket.Order.OrderID });
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.TicketID == id);
        }

        private MultiSelectList GetAllSeats()
        {
            //create a list for all the products
            //List<String> allProducts = _context.Products.ToList();

            //the user MUST select a product, so you don't need a dummy option for no course

            List<String> allSeats = new List<String>(new string[]{"A1", "A2", "A3", "A4", "A5",
                                                                   "B1", "B2", "B3", "B4", "B5",
                                                                   "C1", "C2", "C3", "C4", "C5",
                                                                   "D1", "D2", "D3", "D4", "D5"});


            //use the constructor on select list to create a new select list with the options
            MultiSelectList slSelectedSeats = new MultiSelectList(allSeats);

            return slSelectedSeats;
        }



        private MultiSelectList GetAllSeats(string SelectedSeat)
        {
            //create a list for all the products
            //List<String> allProducts = _context.Products.ToList();

            //the user MUST select a product, so you don't need a dummy option for no course

            List<String> allSeats = new List<String>(new string[]{"A1", "A2", "A3", "A4", "A5",
                                                                   "B1", "B2", "B3", "B4", "B5",
                                                                   "C1", "C2", "C3", "C4", "C5",
                                                                   "D1", "D2", "D3", "D4", "D5"});


            //loop through the list of product Suppliers to find a list of department ids
            //create a list to store the supplier ids
            List<String> selectedSeats = new List<String>();



            foreach (String seat in allSeats)
            {
                if (seat == SelectedSeat)
                {
                    selectedSeats.Add(seat);
                }
            }

            //use the constructor on select list to create a new select list with the options
            MultiSelectList mslAllSeats = new MultiSelectList(allSeats, selectedSeats);

            return mslAllSeats;
        }
        public static class FindAvaliableSeats
        {
            public static List<String> DefaultSeats
            {
                get
                {
                    List<String> defaultSeats = new List<String>(new string[] {
                        "A1",
                        "A2",
                        "A3",
                        "A4",
                        "A5",
                        "B1",
                        "B2",
                        "B3",
                        "B4",
                        "B5",
                        "C1",
                        "C2",
                        "C3",
                        "C4",
                        "C5",
                        "D1",
                        "D2",
                        "D3",
                        "D4",
                        "D5"
                        });
                    return defaultSeats;

                }
            }
           

        }

        private int SubPopcornPoints(AppUser appUser)
        {
            int poppoints = Convert.ToInt32(appUser.PopcornPoints);
         

            int calpop = poppoints - 100;

            return calpop;
        }

        private int AddPopcornPoints(Ticket ticket, AppUser appUser)
        {
            int poppoints = Convert.ToInt32(appUser.PopcornPoints);

            int ticketpoppoints = Convert.ToInt32(ticket.TicketPrice);

            int calpop = poppoints + ticketpoppoints;

            return calpop;
        }

        


        private Boolean CalSeniorCitizen(Ticket ticket, AppUser appUser)
        {
            //DateTime birthday = appUser.Birthday;

            int year = appUser.Birthday.Year;

            if (year > 60)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private Boolean CalMinor(Ticket ticket, AppUser appUser)
        {
            //DateTime birthday = appUser.Birthday;

            int year = appUser.Birthday.Year;

            if (year < 17)
            {
                return true;
            }

            else
            {
                return false;
            }
        }


        private decimal SetPrice(Ticket ticket, Price price, Showing showing)
        {


            int hour = showing.StartTime.Hour;
            //string day = showing.StartTime.DayOfWeek.ToString("dddd");


            DateTime day = showing.StartTime;
            //day.ToString("ddd");

            String strday = day.DayOfWeek.ToString();

            if (showing.SpecialEvent == true)
            {
                return price.SpecialEvent;
            }


            if (hour < 12)
            {
                if (strday == "Monday" || strday == "Tuesday" || strday == "Wednesday" || strday == "Thursday" || strday == "Friday")
                {
                    if (ticket.SeniorCitizen == true)
                    {
                        return price.Matinee - price.SeniorCitizen;
                    }

                    return price.Matinee;
                }

            }
            if (hour > 12)
            {
                if (strday == "Monday" || strday == "Wednesday" || strday == "Thursday")
                {
                    if (ticket.SeniorCitizen == true)
                    {
                        return price.WeekdayAfternoon - price.SeniorCitizen;
                    }

                    return price.WeekdayAfternoon;
                }

            }
            if (hour > 12)
            {
                if (strday == "Tuesday")
                {
                    if (ticket.SeniorCitizen == true)
                    {
                        return price.TuesdayAfternoon - price.SeniorCitizen;
                    }

                    return price.TuesdayAfternoon;
                }

            }

            if (hour > 12)
            {
                if (strday == "Friday")
                {
                    if (ticket.SeniorCitizen == true)
                    {
                        return price.Weekend - price.SeniorCitizen;
                    }

                    return price.Weekend;
                }

            }

            if (strday == "Saturday" || strday == "Sunday")
            {
                if (ticket.SeniorCitizen == true)
                {
                    return price.Weekend - price.SeniorCitizen;
                }

                return price.Weekend;
            }

            
            return price.BasePrice;
        }

        
        private SelectList GetAllShowings()
        {
            //create a list for all the courses
            List<Showing> allShowings = _context.Showings
            //.Include(s => s.Movie)
            .ToList();

            //the user MUST select a course, so you don't need a dummy option for no course

            //use the constructor on select list to create a new select list with the options
            SelectList slAllShowings = new SelectList(allShowings.OrderBy(s => s.ShowingID), "ShowingID", "StartTime");

            return slAllShowings;
        }
        

        
       
       /*private SelectList GetAllMovies()
        {
            //create a list for all the courses
            List<Movie> allMovies = _context.Movies
            .Include(s => s.Showings)
            .ToList();

            //the user MUST select a course, so you don't need a dummy option for no course

            //use the constructor on select list to create a new select list with the options
            SelectList slAllMovies = new SelectList(allMovies.OrderBy(s => s.), "MovieID","Title");

            return slAllMovies;
        }*/

       
        /*public static List<String> AvailableSeats()
        {
            Showing dbShowing = _context.Showings
            .Include(t => t.Tickets)
            .FirstOrDefault(testc => testc.ShowingID == showingID);

            List<String> takenSeats = new List<String>();

            foreach (Ticket t in dbShowing.Tickets)
            {
                takenSeats.Add(t.SelectedSeat);
            }

            List<String> availableSeats = DefaultSeats.Except(takenSeats).ToList();
            return availableSeats;
        }

        public static List<String> AvailableSeats(Showing showing)
        {
            List<String> takenSeats = new List<String>();

            foreach (Ticket t in showing.Tickets)
            {
                takenSeats.Add(t.SelectedSeat);
            }
            List<String> availableSeats = DefaultSeats.Except(takenSeats).ToList();
            return availableSeats;
        }*/


    }

}

