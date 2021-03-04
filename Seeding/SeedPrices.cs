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
    public static class SeedPrices
    {
        //You will call this method from the SeedController to add categories
        public static void SeedAllPrices(AppDbContext db)
        {
            //create a list of categories to add
            List<Price> AllPrices = new List<Price>();

            //create a new instance of the genre class
            Price p1 = new Price()
            {
                BasePrice = 12,
                Matinee = 5,
                WeekdayAfternoon = 10,
                TuesdayAfternoon = 8,
                Weekend = 12,
                SpecialEvent = 12,
                SeniorCitizen = 2
            };

                                       

            //add the Genre to the list
            AllPrices.Add(p1);


            //create a counter and flag to help with debugging
            int intPriceID = 0;
            String strPriceType = "Start";

            //we are now going to add the data to the database
            //this could cause errors, so we need to put this code
            //into a Try/Catch block
            try
            {
                //loop through each of the categories
                foreach (Price seedPrice in AllPrices)
                {
                    //updates the counters to get info on where the problem is
                    intPriceID = seedPrice.PriceID;
                   

                    //try to find the category in the database
                    Price dbPrice = db.Prices.FirstOrDefault(p => p.PriceID == seedPrice.PriceID);

                    //if the category isn't in the database, dbCategory will be null
                    if (dbPrice == null)
                    {
                        //add the Category to the database
                        db.Prices.Add(seedPrice);
                        db.SaveChanges();
                    }
                    else //the record is in the database
                    {
                        //update all the fields
                        //this isn't really needed for category because it only has one field
                        //but you will need it to re-set seeded data with more fields
                        dbPrice.PriceID = seedPrice.PriceID;
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
                msg.Append(strPriceType);
                msg.Append(" Genre (GenreID = ");
                msg.Append(intPriceID);
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
