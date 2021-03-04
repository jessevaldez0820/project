using Group25_Final_Project.DAL;
using System;
using System.Linq;


namespace Group25_Final_Project.Utilities
{
    public static class GenerateNextMovieNumber
    {
        public static Int32 GetNextMovieNumber(AppDbContext _context)
        {
            //set a constant to designate where the registration numbers 
            //should start
            const Int32 START_NUMBER = 3000;

            Int32 intMaxMovieNumber; //the current maximum course number
            Int32 intNextMovieNumber; //the course number for the next class

            if (_context.Movies.Count() == 0) //there are no registrations in the database yet
            {
                intMaxMovieNumber = START_NUMBER; //registration numbers start at 70001
            }
            else
            {
                intMaxMovieNumber = _context.Movies.Max(c => c.MovieNumber); //this is the highest number in the database right now
            }

            //You added records to the datbase before you realized 
            //that you needed this and now you have numbers less than 100 
            //in the database
            if (intMaxMovieNumber < START_NUMBER)
            {
                intMaxMovieNumber = START_NUMBER;
            }

            //add one to the current max to find the next one
            intNextMovieNumber = intMaxMovieNumber + 1;

            //return the value
            return intNextMovieNumber;
        }

    }
}