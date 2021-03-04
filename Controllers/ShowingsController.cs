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
    public class ShowingsController : Controller
    {
        private readonly AppDbContext _context;

        public ShowingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Showings
        [AllowAnonymous]
        public async Task<IActionResult> Index(int? scheduleID)
        {

            var query = from s in _context.Showings select s;

            if (scheduleID != null)
            {
                return View("Error", new String[] { "Please specify a schedule to view!" });

            }

            List<Showing> ss = _context.Showings
                                               .Include(s => s.Movie)
                                               .Where(s => s.Schedule.ScheduleID == scheduleID)
                                               //.OrderBy(m => m.StartTime).ToList();
                                               .ToList();
            //Populate the view bag with a count of all job postings
            //ViewBag.AllShowings = _context.Showings.Count();
            //Populate the view bag with a count of selected job postings
            //ViewBag.SelectedShowings= SelectedShowings.Count();




            return View(ss);
        }

        // GET: Showings/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Please specify a showing to view!" });
            }

            List<Showing> ss = _context.Showings
                                           .Include(od => od.Movie)
                                           .Where(od => od.Schedule.ScheduleID == id)
                                           .ToList();

            return View(ss);
        }

        // GET: Showings/Create
        [Authorize(Roles = "Manager")]
        public IActionResult Create(int scheduleID)
        {
            List<Showing> ss = _context.Showings
                                           .Include(od => od.Movie)
                                           //.Where(od => od.Schedule.ScheduleID == id)
                                           .ToList();

            Showing s = new Showing();


            Schedule dbschedule = _context.Schedule.Find(scheduleID);

            s.Schedule = dbschedule;



            ViewBag.AllMovies = GetAllMovies();

            return View(s);
            
        }

        [AllowAnonymous]
        public IActionResult DetailedShowingSearch()
        {
            
            ViewBag.AllShowings = GetAllShowings();
            ViewBag.AllMovies = GetAllMovies();
            //ViewBag.AllShowings = GetAllShowings();

            ShowingsViewModel svm = new ShowingsViewModel();

            return View(svm);
        }




   


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create([Bind("Schedule,Movie,ShowingID,StartTime,EndTime,SpecialEvent,Theater")] Showing showing, int  selectedMovie)

        {
            if (ModelState.IsValid == false) 
            {
                ViewBag.AllMovies = GetAllMovies();

                return View(showing);

            }
            Movie dbMovie = _context.Movies.Find(selectedMovie);
            
            showing.Movie = dbMovie;

            Schedule dbschedule = _context.Schedule.Find(showing.Schedule.ScheduleID);


            //set showing properties here
            showing.Schedule = dbschedule;
            showing.SeatCount = 20;
            //showing.ShowingStatus = 

            _context.Add(showing);
            
            await _context.SaveChangesAsync();


            //s.TitleTime = s.Movie.Title;



                return RedirectToAction("Details", "Schedules", new { id = showing.Schedule.ScheduleID });
            }



        // GET: Showings/Edit/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Please specify a showing to edit!" });
            }

            Showing showing = await _context.Showings
                                .Include(od => od.Movie)
                                                   .Include(od => od.Schedule)
                                                   .FirstOrDefaultAsync(od => od.ShowingID == id);
            if (showing == null)
            {
                return View("Error", new String[] { "This showing was not found" });
            }
            return View(showing);
        }

        // POST: Showings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int id, [Bind("ShowingID,ShowingTime,SpecialEvent")] Showing showing)
        {
            if (id != showing.ShowingID)
            {
                return View("Error", new String[] { "There was a problem editing this record. Try again!" });
            }

            if (ModelState.IsValid == false)
            {
                return View(showing);

            }

            Showing dbShowing;
            try
                {
                //find the existing order detail in the database
                //include both order and roduct
                dbShowing = _context.Showings
                      .Include(od => od.Movie)
                      .Include(od => od.Schedule)
                      .FirstOrDefault(od => od.ShowingID == showing.ShowingID);

                
                //save changes
                _context.Update(dbShowing);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return View("Error", new String[] { "There was a problem editing this record", ex.Message });

            }
            return RedirectToAction("Index", "Orders");
        }
            
        

       

        


        public IActionResult DisplayShowingResults(ShowingsViewModel svm)
        {
            var query = from s in _context.Showings.Include(m => m.Movie) select s;



            if (String.IsNullOrEmpty(svm.MovieMovie) == false) //JobPostingID not specified
            {
                query = query.Where(m => m.Movie.Title.Contains(svm.MovieMovie));

            }

            if (svm.MovieStartTime != null)
            {
                query = query.Where(s => s.StartTime <= svm.MovieStartTime);
            }


            if (svm.MovieEndTime != null)
            {
                query = query.Where(s => s.EndTime <= svm.MovieEndTime);
            }


            
            if (svm.CountSeat != 0)
            {
               switch(svm.AscendingDescending)
                {
                    case SeatSort.Below:
                        query = query.Where(s => s.SeatCount <= svm.CountSeat);

                        ViewBag.AllShowings = _context.Showings.Count();

                        ViewBag.SelectedShowings = query.Count();

                        break;

                    case SeatSort.Above:
                        query = query.Where(s => s.SeatCount >= svm.CountSeat);

                        ViewBag.AllShowings = _context.Showings.Count();

                        ViewBag.SelectedShowings = query.Count();

                        break;

                    default:

                        break;
                }

            }
            
          
            List<Showing> SelectedShowings = query.Include(m => m.Movie).ToList();
            //Populate the view bag with a count of all job postings
            ViewBag.AllShowings = _context.Showings.Count();
            //Populate the view bag with a count of selected job postings
            ViewBag.SelectedShowings = SelectedShowings.Count();



            return View("Index", SelectedShowings.OrderByDescending(s => s.StartTime));



        }


        private SelectList GetAllMovies()
        {
            //create a list for all the courses
            List<Movie> allMovies = _context.Movies.ToList();

            //the user MUST select a course, so you don't need a dummy option for no course

            //use the constructor on select list to create a new select list with the options
            SelectList slAllMovies = new SelectList(allMovies.OrderBy(m => m.MovieID), "MovieID", "Title");

            return slAllMovies;
        }

        private SelectList GetAllShowings()
        {
            //create a list for all the courses
            List<Showing> allShowings = _context.Showings
            .Include(s => s.Movie)
            .ToList();

            //the user MUST select a course, so you don't need a dummy option for no course

            //use the constructor on select list to create a new select list with the options
            SelectList slAllShowings = new SelectList(allShowings.OrderBy(s => s.ShowingID), "ShowingID", "StartTime");

            return slAllShowings;
        }


    }
}
