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
    [AllowAnonymous]
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.Include(g => g.Genre).ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(g => g.Genre)
                .FirstOrDefaultAsync(m => m.MovieID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        [Authorize(Roles = "Manager")]
        public IActionResult Create()
        {
            ViewBag.AllGenres = GetAllGenres();

            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create([Bind("Genre,MovieID,MovieNumber,Title,Overview,ReleaseDate,Revenue,RunningTime,Tagline,MPAARating,Actors")] Movie movie, int SelectedGenre)
        {
            //Assign the movie number of the movie being created
            movie.MovieNumber = Utilities.GenerateNextMovieNumber.GetNextMovieNumber(_context);

            //Find the actual genre associated with the selected genre id
       

            //selected genre should be an int
            Genre dbGenre = _context.Genres.Find(SelectedGenre);
                       

            movie.Genre = dbGenre;

            Genre g = new Genre();
            g.Movies.Add(movie);

            _context.Add(movie);
            await _context.SaveChangesAsync();


             if (ModelState.IsValid == false)
                        {
                            ViewBag.AllGenres = GetAllGenres();
                            return View(movie);
                        }


            return RedirectToAction(nameof(Index));
        }


        // GET: Movies/Edit/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.AllGenres = GetAllGenres();


            if (id == null)
            {

                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int id, [Bind("Genre,MovieID,MovieNumber,Title,Overview,ReleaseDate,Revenue,RunningTime,Tagline,MPAARating,Actors")] Movie movie)
        {
            ViewBag.AllGenres = GetAllGenres();


            if (id != movie.MovieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieID == id);
        }



        private SelectList GetAllGenres()
        {

            //IEnumerable<SelectListItem> values = from Genre g in genreList;

            //Get a list of all the genres
            List<Genre> genreList = _context.Genres.ToList();

            //Get the ids associated with all the genres to display
            //Save the genre that was selected
            //Save the genre id that was selected
            SelectList genreSelectList = new SelectList(genreList.OrderBy(m => m.GenreID), "GenreID", "GenreName");
            //return the select list
            return genreSelectList;
        }


    }
}
