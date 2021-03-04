using Group25_Final_Project.DAL;
using System;
using System.Linq;


namespace Group25_Final_Project.Utilities
{
    public static class GenerateNextCustomerNumber
    {
        public static Int32 GetNextCustomerNumber(AppDbContext _context)
        {
            //set a constant to designate where the registration numbers 
            //should start
            const Int32 START_NUMBER = 3000;

            Int32 intMaxCustomerNumber; //the current maximum course number
            Int32 intNextCustomerNumber; //the course number for the next class

            if (_context.Users.Count() == 0) //there are no registrations in the database yet
            {
                intMaxCustomerNumber = START_NUMBER; //registration numbers start at 70001
            }
            else
            {
                intMaxCustomerNumber = _context.Users.Max(c => c.CustomerNumber); //this is the highest number in the database right now
            }

            //You added records to the datbase before you realized 
            //that you needed this and now you have numbers less than 100 
            //in the database
            if (intMaxCustomerNumber < START_NUMBER)
            {
                intMaxCustomerNumber = START_NUMBER;
            }

            //add one to the current max to find the next one
            intNextCustomerNumber = intMaxCustomerNumber + 1;

            //return the value
            return intNextCustomerNumber;
        }

    }
}