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
    //[Authorize]
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            List<Order> orders;
            if (User.IsInRole("Manager,Employee"))
            {
                orders = _context.Orders
                                .Include(o => o.Tickets)
                                .ToList();
            }
            else //user is a customer, so only display their records
            {
                orders = _context.Orders
                                .Include(r => r.Tickets)
                                .Where(r => r.AppUser.UserName == User.Identity.Name)
                                .ToList();
            }
            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Please specify a order to view!" });
            }

            Order order = await _context.Orders
                .Include(o => o.Tickets).ThenInclude(o => o.Showing).ThenInclude(o => o.Movie)
                .Include(o => o.AppUser)
                .FirstOrDefaultAsync(m => m.OrderID == id);
                

            

            if (order == null)
            {
                return View("Error", new String[] { "This order was not found!" });
            }


            //make sure this registration belongs to this user
            if (User.IsInRole("Customer") && order.AppUser.UserName != User.Identity.Name)
            {
                return View("Error", new String[] { "This is not your order!" });
            }
            return View(order);
        }

        // GET: Orders/Create
        //[Authorize(Roles = "Customer,Manager,Employee")]
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Get all movies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Customer,Manager,Employee")]
        public async Task<IActionResult> Create([Bind("TicketID,SelectedSeat,OrderDate,GiftAttribute")] Order order)
        {
            order.TransactionNumber = Utilities.GenerateTransactionNumber.GetNextTransactionNumber(_context);
            

            //Associate the registration with the logged-in customer
            order.AppUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            order.OrderDate = DateTime.Now;
            


            if (order.GiftAttribute == true)
            {
                return View("Gift");
            }
            //make sure all properties are valid
            if (ModelState.IsValid == false)
            {


                return View(order);           
            }
            _context.Add(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("Create", "Tickets", new { orderID = order.OrderID });
            ;



            //if code gets this far, add the registration to the database


            //send the user on to the action that will allow them to 
            //create a registration detail.  Be sure to pass along the RegistrationID
            //that you created when you added the registration to the database above

        }


        

        

        // GET: Orders/Edit/5//
        //[Authorize(Roles = "Customer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Please specify a order to edit" });
            }

            Order order =  _context.Orders
                .Include(o => o.Tickets)
                .ThenInclude(o => o.Showing)
                .ThenInclude(o => o.Movie)
                .Include(o => o.AppUser)
                .FirstOrDefault(o => o.OrderID == id);

            


            if (order == null)
            {
                return View("Error", new String[] { "This order was not found in the database!" });
            }

            //registration does not belong to this user
            if (User.IsInRole("Customer") && order.AppUser.UserName != User.Identity.Name)
            {
                return View("Error", new String[] { "You are not authorized to edit this order!" });
            }

            //send the user to the registration edit view
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Customer")]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,TransactionNumber,Subtotal,Tax,Total,OrderDate,GiftAttribute,Confirmation,IsCancelled")] Order order, int SelectedShowing)
        {
            if (id != order.OrderID)
            {
                return View("Error", new String[] { "There was a problem editing this order. Try again!" });
            }

            if (ModelState.IsValid == false)
            {
                return View(order);

            }

            //if code gets this far, update the record
            try
            {
                //find the record in the database
                Order dbOrder = _context.Orders.Find(order.OrderID);

                //update the notes
                dbOrder.IsCancelled = order.IsCancelled;

                _context.Update(dbOrder);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return View("Error", new String[] { "There was an error updating this order!", ex.Message });
            }

            return RedirectToAction(nameof(Index));
            
         
        }

       

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }


        private Boolean GetGift(Order order, AppUser appUser)
        {
            //DateTime birthday = appUser.Birthday;

            

            if (order.GiftAttribute == true)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        //[Authorize(Roles = "Customer")]
        public IActionResult Gift()
        {

            return View();
        }
        //[Authorize(Roles = "Customer")]
        public async Task<IActionResult> Gift([Bind("TicketID,SelectedSeat,OrderDate,GiftAttribute")] Order order, string email)
        {
            //DateTime birthday = appUser.Birthday;

            
            List<AppUser> appUsers = _context.Users.ToList();

            
           List<AppUser> accounts = new List<AppUser>();

            int count = 0;
            //See if the email matches any email in the database
            foreach (AppUser a in appUsers)
            {

                //if the email matches go through with process
                if (a.Email == email)
                {
                    ////add this email to a list
                    accounts.Add(a);
                    count = count + 1;
                }
            }

            if (accounts == null)
            { 
                return View(email);
            }

            else
            if (count == 0)
            {
                
                return View(email);
            }



            return RedirectToAction("Create", "Tickets", new { orderID = order.OrderID });


            //if code gets this far, add the registration to the database


            //send the user on to the action that will allow them to 
            //create a registration detail.  Be sure to pass along the RegistrationID
            //that you created when you added the registration to the database above

        }

        
    }
}
