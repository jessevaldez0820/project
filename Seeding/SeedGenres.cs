using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//:Make these namespaces match your project name
using Group25_Final_Project.Models;
using Group25_Final_Project.DAL;
using System.Text;

//:Make this namespace match your project name
namespace Group25_Final_Project.Seeding
{
    //make this class static so you can use the dbContext
    public static class SeedGenres
    {
        //You will call this method from the SeedController to add categories
        public static void SeedAllGenres(AppDbContext db)
        {
            //create a list of categories to add
            List<Genre> AllGenres = new List<Genre>();

            //create a new instance of the genre class
            Genre g1 = new Genre() { GenreName = "Action" };
            //add the Genre to the list
            AllGenres.Add(g1);

            //create a new instance of the genre class
            Genre g2 = new Genre() { GenreName = "Adventure" };
            //add the Genre to the list
            AllGenres.Add(g2);

            //create a new instance of the genre class
            Genre g3 = new Genre() { GenreName = "Animation" };
            //add the Genre to the list
            AllGenres.Add(g3);

            //create a new instance of the genre class
            Genre g4 = new Genre() { GenreName = "Comedy" };
            //add the Genre to the list
            AllGenres.Add(g4);

            //create a new instance of the genre class
            Genre g5 = new Genre() { GenreName = "Crime" };
            //add the Genre to the list
            AllGenres.Add(g5);

            //create a new instance of the genre class
            Genre g6 = new Genre() { GenreName = "Drama" };
            //add the Genre to the list
            AllGenres.Add(g6);

            //create a new instance of the genre class
            Genre g7 = new Genre() { GenreName = "Family" };
            //add the Genre to the list
            AllGenres.Add(g7);

            //create a new instance of the genre class
            Genre g8 = new Genre() { GenreName = "Fantasy" };
            //add the Genre to the list
            AllGenres.Add(g8);

            //create a new instance of the genre class
            Genre g9 = new Genre() { GenreName = "Horror" };
            //add the Genre to the list
            AllGenres.Add(g9);

            //create a new instance of the genre class
            Genre g10 = new Genre() { GenreName = "Musical" };
            //add the Genre to the list
            AllGenres.Add(g10);

            //create a new instance of the genre class
            Genre g11 = new Genre() { GenreName = "Romance" };
            //add the Genre to the list
            AllGenres.Add(g11);

            //create a new instance of the genre class
            Genre g12 = new Genre() { GenreName = "Science Fiction" };
            //add the Genre to the list
            AllGenres.Add(g12);

            //create a new instance of the genre class
            Genre g13 = new Genre() { GenreName = "Thriller" };
            //add the Genre to the list
            AllGenres.Add(g13);

            //create a new instance of the genre class
            Genre g14 = new Genre() { GenreName = "War" };
            //add the Genre to the list
            AllGenres.Add(g14);

            //create a new instance of the genre class
            Genre g15 = new Genre() { GenreName = "Western" };
            //add the Genre to the list
            AllGenres.Add(g15);

            //create a new instance of the genre class
            Genre g16 = new Genre() { GenreName = "Blank" };
            //add the Genre to the list
            AllGenres.Add(g16);

            //create a counter and flag to help with debugging
            int intGenreID = 0;
            String strGenreName = "Start";

            //we are now going to add the data to the database
            //this could cause errors, so we need to put this code
            //into a Try/Catch block
            try
            {
                //loop through each of the categories
                foreach (Genre seedGenre in AllGenres)
                {
                    //updates the counters to get info on where the problem is
                    intGenreID = seedGenre.GenreID;
                    strGenreName = seedGenre.GenreName;

                    //try to find the category in the database
                    Genre dbGenre = db.Genres.FirstOrDefault(c => c.GenreName == seedGenre.GenreName);

                    //if the category isn't in the database, dbCategory will be null
                    if (dbGenre == null)
                    {
                        //add the Category to the database
                        db.Genres.Add(seedGenre);
                        db.SaveChanges();
                    }
                    else //the record is in the database
                    {
                        //update all the fields
                        //this isn't really needed for category because it only has one field
                        //but you will need it to re-set seeded data with more fields
                        dbGenre.GenreName = seedGenre.GenreName;
                        //you would add other fields here
                        db.SaveChanges();
                    }

                }
            }
            catch (Exception ex)  //something about adding to the database caused a problem
            {
                //create a new instance of the string builder to make building out 
                //our message neater - we don't want a REALLY long line of code for this
                //so we break it up into several lines
                StringBuilder msg = new StringBuilder();

                msg.Append("There was an error adding the ");
                msg.Append(strGenreName);
                msg.Append(" Genre (GenreID = ");
                msg.Append(intGenreID);
                msg.Append(")");

                //have this method throw the exception to the calling method
                //this code wraps the exception from the database with the 
                //custom message we built above.  The original error from the
                //database becomes the InnerException
                throw new Exception(msg.ToString(), ex);
            }

        }
    
    }
}
