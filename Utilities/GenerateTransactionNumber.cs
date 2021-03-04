using Group25_Final_Project.DAL;
using System;
using System.Linq;

namespace Group25_Final_Project.Utilities
{
    public static class GenerateTransactionNumber
    {
        public static Int32 GetNextTransactionNumber(AppDbContext _context)
        {
            //Set a number where the course numbers should start
            const Int32 START_NUMBER = 70001;

            Int32 intMaxOrderNumber; //the current maximum course number
            Int32 intNextOrderNumber; //the course number for the next class

            if (_context.Orders.Count() == 0) //there are no courses in the database yet
            {
                intMaxOrderNumber = START_NUMBER; //order numbers start at 70001
            }
            else
            {
                intMaxOrderNumber = _context.Orders.Max(c => c.TransactionNumber); //this is the highest number in the database right now
            }

            //You added orders before you realized that you needed this code
            //and now you have some order numbers less than 3000
            if (intMaxOrderNumber < START_NUMBER)
            {
                intMaxOrderNumber = START_NUMBER;
            }

            //add one to the current max to find the next one
            intNextOrderNumber = intMaxOrderNumber + 1;

            //return the value
            return intNextOrderNumber;
        }

    }
}