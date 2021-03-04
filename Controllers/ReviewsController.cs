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
    public class ReviewsController : Controller
    {
        private readonly AppDbContext _context;

        public ReviewsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Reviews
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            List<Review> reviews;
            //get all reviews for manager and employee
            if (User.IsInRole("Manager,Employee"))
            {
                reviews = _context.Reviews
                                .Include(r => r.AppUser)
                                .Include(r => r.Movie)
                                .ToList();
            }
            else ///User is a customer, so this only displays their records
            {
                reviews = _context.Reviews
                                .Include(r => r.Movie)
                                //.Where(r => r.AppUser.UserName == User.Identity.Name)
                                .ToList();
            }


            return View(await _context.Reviews.ToListAsync());
        }

        // GET: Reviews/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Please specify a review to view!" });
            }

            Review review = await _context.Reviews
                .Include(r => r.Movie)
                .Include(o => o.AppUser)
                .FirstOrDefaultAsync(m => m.ReviewID == id);


            if (review == null)
            {
                return View("Error", new String[] { "This review was not found!" });
            }

            return View(review);
        }

        // GET: Reviews/Create
        [Authorize(Roles = "Customer")]
        public IActionResult Create()
        {

            //populate the ViewBag with a list of existing products
            ViewBag.AllMovies = GetAllMovies();


            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create([Bind("ReviewID,Rating,ReviewString,Approved")] Review review, int SelectedMovie)
        {

            //Associate the review with the logged-in customer
            review.AppUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);


            if (ModelState.IsValid == false)
            {

                ViewBag.AllMovies = GetAllMovies();
                return View(review);

            }

            //find the movie associated with this review
            Movie dbmovie = _context.Movies.Find(SelectedMovie);

            review.Movie = dbmovie;


            _context.Add(review);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Reviews/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Please specify a review to edit" });
            }

            Review review = await _context.Reviews
                             .Include(r => r.Movie)
                             .Include(r => r.AppUser)
                             .FirstOrDefaultAsync(m => m.ReviewID == id);

            if (review == null)
            {
                return View("Error", new String[] { "This review was not found in the database!" });
            }

            if (User.IsInRole("Customer") && review.AppUser.UserName != User.Identity.Name)
            {
                return View("Error", new String[] { "You are not authorized to edit this review!" });
            }

            return View(review);
        }

        // POST: Reviews/Edit/5
        [Authorize]
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewID,Rating,ReviewString,Approved")] Review review)
        {
            if (id != review.ReviewID)
            {
                return View("Error", new String[] { "There was a problem editing this review. Try again!" });
            }

            if (ModelState.IsValid == false)
            {
                return View(review);     
            }

            try
            {
                //find the record in the database
                Review dbReview = _context.Reviews.Find(review.ReviewID);

                //update the notes

                dbReview.ReviewString = review.ReviewString;

                _context.Update(dbReview);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
                {
                return View("Error", new String[] { "There was an error updating this review!", ex.Message });

            }
            return RedirectToAction(nameof(Index));
        }


        private SelectList GetAllMovies()
        {
            //create a list for all the courses
            List<Movie> allMovies = _context.Movies
            .Include(s => s.Reviews)
            .ToList();

            /*
            //the user MUST select a course, so you don't need a dummy option for no course
            //make sure this registration belongs to this user
            if (User.IsInRole("Customer") && Review.AppUser.UserName != User.Identity.Name)
            {
                return View("Error", new String[] { "This is not your order!" });
            }
            */
            //use the constructor on select list to create a new select list with the options
            SelectList slAllMovies = new SelectList(allMovies.OrderBy(s => s.MovieID), "MovieID", "Title");

            return slAllMovies;
        }
    }



}
