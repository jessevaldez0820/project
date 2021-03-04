using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Group25_Final_Project.DAL;
using Group25_Final_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Group25_Final_Project.Controllers
{
    public class SearchController : Controller
    {
        private AppDbContext _context;

        public SearchController(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        // GET: /<controller>/
        public ActionResult Index(string SearchString)
        {

            var query = from m in _context.Movies select m;

            if (SearchString != null)
            {
                query = query.Where(m => m.Title.Contains(SearchString) ||
                m.Tagline.Contains(SearchString));

            }
            List<Movie> SelectedMovies = query.Include(m => m.Genre).ToList();
            //Populate the view bag with a count of all job postings
            ViewBag.AllMovies = _context.Movies.Count();
            //Populate the view bag with a count of selected job postings
            ViewBag.SelectedMovies = SelectedMovies.Count();

            return View(SelectedMovies.OrderByDescending(m => m.ReleaseDate).ToList());


        }

        public IActionResult Details(int? id)
        {
            if (id == null) //JobPostingID not specified
            {
                return View("Error", new String[] { "MovieID not specified - which movie do you want to view?" });
            }

            Movie movie = _context.Movies.Include(m => m.Genre)
                                         .Include(m => m.Showings)
                                         .Include(m => m.Reviews)
                                         .ThenInclude(m => m.AppUser)
                                         .FirstOrDefault(m => m.MovieID == id);

            if (movie == null) //Job position does not exist in database
            {
                return View("Error", new String[] { "Movie not found in database" });

            }

        
            //if code gets this far, the user passed every validation
            return View(movie);




        }

        public IActionResult DetailedSearch()
        {
            ViewBag.AllGenres = GetAllGenres();
            //ViewBag.AllShowings = GetAllShowings();

            //ViewBag.AllShowings = GetAllShowings();

            SearchViewModel svm = new SearchViewModel();

            return View(svm);
        }



        
        public IActionResult DisplaySearchResults(SearchViewModel svm)
        {
            var query = from m in _context.Movies.Include(m => m.Showings) select m;

            

            if (String.IsNullOrEmpty(svm.MovieTitle) == false) //JobPostingID not specified
            {
                query = query.Where(m => m.Title.Contains(svm.MovieTitle));
                
            }

            if (String.IsNullOrEmpty(svm.MovieTagline) == false)
            {
                query = query.Where(m => m.Tagline.Contains(svm.MovieTagline));
            }

            if (svm.SelectedGenreID != 0)
            {
                query = query.Where(m => m.Genre.GenreID == svm.SelectedGenreID);
            }
            /*
            if (svm.UserRating != 0)
            {
               switch(svm.AscendingDescending)
                {
                    case MovieSort.Descending:
                        query = query.Where(m => m.UserRatings <= svm.UserRating);

                        ViewBag.AllMovies = _context.Movies.Count();

                        ViewBag.SelectedMovies = query.Count();

                        break;

                    case MovieSort.Ascending:
                        query = query.Where(m => m.UserRatings >= svm.UserRating);

                        ViewBag.AllMovies = _context.Movies.Count();

                        ViewBag.SelectedMovies = query.Count();

                        break;

                    default:

                        break;
                }

            }
            */
            if (svm.MovieReleaseDate != null)
            {
                query = query.Where(m => m.ReleaseDate <= svm.MovieReleaseDate);
            }
            
            if (svm.MPAA != MpaaRating.NoPreference)
            {
                if (svm.MPAA == MpaaRating.G)
                {
                    query = query.Where(m => m.MPAARating == "G");
                }
                if (svm.MPAA == MpaaRating.PG)
                {
                    query = query.Where(m => m.MPAARating == "PG");
                }
                if (svm.MPAA == MpaaRating.PG13)
                {
                    query = query.Where(m => m.MPAARating == "PG-13");
                }
                if (svm.MPAA == MpaaRating.R)
                {
                    query = query.Where(m => m.MPAARating == "R");

                }
                if (svm.MPAA == MpaaRating.Unrated)
                {
                    query = query.Where(m => m.MPAARating == "Unrated");
                }
            }

            if (String.IsNullOrEmpty(svm.MovieActors) == false) //JobPostingID not specified
            {
                query = query.Where(m => m.Actors.Contains(svm.MovieActors));

            }
            /*
            if (svm.MovieShowtime != null)
            {
                {
                    
                    //query = query.Where(m =>m.Showings.StartTime <= svm.MovieShowtime);
                    foreach (DateTime showing in s.Showings)
                    query = query.Where(m => m.ReleaseDate <= svm.MovieReleaseDate);
                }


            }
            */
            List<Movie> SelectedMovies = query.Include(m => m.Genre).ToList();
            //Populate the view bag with a count of all job postings
            ViewBag.AllMovies = _context.Movies.Count();
            //Populate the view bag with a count of selected job postings
            ViewBag.SelectedMovies = SelectedMovies.Count();

            

            return View("Index",SelectedMovies.OrderByDescending(m => m.ReleaseDate));



        }
        private SelectList GetAllGenres()
        {
            //Get the list of months from the database
            List<Genre> genreList = _context.Genres.ToList();

            //add a dummy entry so the user can select all months
            Genre SelectNone = new Genre() { GenreID = 0, GenreName = "All Genres" };
            genreList.Add(SelectNone);

            //convert the list to a SelectList by calling SelectList constructor
            //MonthID and MonthName are the names of the properties on the Month class
            //MonthID is the primary key
            SelectList genreSelectList = new SelectList(genreList.OrderBy(m => m.GenreID), "GenreID", "GenreName");

            //return the electList
            return genreSelectList;
        }

    }

}