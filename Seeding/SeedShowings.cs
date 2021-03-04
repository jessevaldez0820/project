using Group25_Final_Project.DAL;
using Group25_Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Group25_Final_Project.Seeding
{
	public static class SeedShowings
	{
		public static void SeedAllShowings(AppDbContext db)
		{
		//Create a new list for all of the Showings
		List<Showing> AllShowings = new List<Showing>();
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Footloose"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,4,9,5,0),
			EndTime = new DateTime(2020,12,4,10,52,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="WarGames"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,4,11,30,0),
			EndTime = new DateTime(2020,12,4,13,24,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Office Space"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,4,14,0,0),
			EndTime = new DateTime(2020,12,4,15,29,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Diamonds are Forever"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,4,15,55,0),
			EndTime = new DateTime(2020,12,4,17,55,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="West Side Story"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,4,18,40,0),
			EndTime = new DateTime(2020,12,4,21,12,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Forrest Gump"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,4,21,37,0),
			EndTime = new DateTime(2020,12,4,23,59,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Toy Story"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,4,9,0,0),
			EndTime = new DateTime(2020,12,4,10,21,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Dazed and Confused"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,4,10,50,0),
			EndTime = new DateTime(2020,12,4,12,32,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Lego Movie"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,4,13,0,0),
			EndTime = new DateTime(2020,12,4,14,40,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Princess Bride"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,4,15,20,0),
			EndTime = new DateTime(2020,12,4,16,58,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Finding Nemo"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,4,17,25,0),
			EndTime = new DateTime(2020,12,4,19,5,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Harry Potter and the Chamber of Secrets"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,4,19,30,0),
			EndTime = new DateTime(2020,12,4,22,11,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Land Before Time"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,4,22,40,0),
			EndTime = new DateTime(2020,12,4,23,49,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Footloose"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,5,9,5,0),
			EndTime = new DateTime(2020,12,5,10,52,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="WarGames"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,5,11,30,0),
			EndTime = new DateTime(2020,12,5,13,24,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Office Space"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,5,14,0,0),
			EndTime = new DateTime(2020,12,5,15,29,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Diamonds are Forever"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,5,15,55,0),
			EndTime = new DateTime(2020,12,5,17,55,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="West Side Story"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,5,18,40,0),
			EndTime = new DateTime(2020,12,5,21,12,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Forrest Gump"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,5,21,37,0),
			EndTime = new DateTime(2020,12,5,23,59,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Toy Story"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,5,9,0,0),
			EndTime = new DateTime(2020,12,5,10,21,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Dazed and Confused"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,5,10,50,0),
			EndTime = new DateTime(2020,12,5,12,32,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Lego Movie"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,5,13,0,0),
			EndTime = new DateTime(2020,12,5,14,40,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Princess Bride"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,5,15,20,0),
			EndTime = new DateTime(2020,12,5,16,58,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Finding Nemo"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,5,17,25,0),
			EndTime = new DateTime(2020,12,5,19,5,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Harry Potter and the Chamber of Secrets"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,5,19,30,0),
			EndTime = new DateTime(2020,12,5,22,11,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Land Before Time"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,5,22,40,0),
			EndTime = new DateTime(2020,12,5,23,49,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Footloose"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,6,9,5,0),
			EndTime = new DateTime(2020,12,6,10,52,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="WarGames"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,6,11,30,0),
			EndTime = new DateTime(2020,12,6,13,24,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Office Space"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,6,14,0,0),
			EndTime = new DateTime(2020,12,6,15,29,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Diamonds are Forever"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,6,15,55,0),
			EndTime = new DateTime(2020,12,6,17,55,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="West Side Story"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,6,18,40,0),
			EndTime = new DateTime(2020,12,6,21,12,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Forrest Gump"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,6,21,37,0),
			EndTime = new DateTime(2020,12,6,23,59,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Toy Story"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,6,9,0,0),
			EndTime = new DateTime(2020,12,6,10,21,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Dazed and Confused"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,6,10,50,0),
			EndTime = new DateTime(2020,12,6,12,32,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Lego Movie"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,6,13,0,0),
			EndTime = new DateTime(2020,12,6,14,40,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Princess Bride"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,6,15,20,0),
			EndTime = new DateTime(2020,12,6,16,58,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Finding Nemo"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,6,17,25,0),
			EndTime = new DateTime(2020,12,6,19,5,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Harry Potter and the Chamber of Secrets"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,6,19,30,0),
			EndTime = new DateTime(2020,12,6,22,11,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Land Before Time"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,6,22,40,0),
			EndTime = new DateTime(2020,12,6,23,49,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Footloose"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,7,9,5,0),
			EndTime = new DateTime(2020,12,7,10,52,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="WarGames"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,7,11,30,0),
			EndTime = new DateTime(2020,12,7,13,24,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Office Space"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,7,14,0,0),
			EndTime = new DateTime(2020,12,7,15,29,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Diamonds are Forever"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,7,15,55,0),
			EndTime = new DateTime(2020,12,7,17,55,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="West Side Story"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,7,18,40,0),
			EndTime = new DateTime(2020,12,7,21,12,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Forrest Gump"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,7,21,37,0),
			EndTime = new DateTime(2020,12,7,23,59,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Toy Story"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,7,9,0,0),
			EndTime = new DateTime(2020,12,7,10,21,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Dazed and Confused"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,7,10,50,0),
			EndTime = new DateTime(2020,12,7,12,32,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Lego Movie"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,7,13,0,0),
			EndTime = new DateTime(2020,12,7,14,40,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Princess Bride"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,7,15,20,0),
			EndTime = new DateTime(2020,12,7,16,58,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Finding Nemo"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,7,17,25,0),
			EndTime = new DateTime(2020,12,7,19,5,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Harry Potter and the Chamber of Secrets"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,7,19,30,0),
			EndTime = new DateTime(2020,12,7,22,11,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Land Before Time"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,7,22,40,0),
			EndTime = new DateTime(2020,12,7,23,49,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Footloose"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,8,9,5,0),
			EndTime = new DateTime(2020,12,8,10,52,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="WarGames"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,8,11,30,0),
			EndTime = new DateTime(2020,12,8,13,24,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Office Space"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,8,14,0,0),
			EndTime = new DateTime(2020,12,8,15,29,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Diamonds are Forever"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,8,15,55,0),
			EndTime = new DateTime(2020,12,8,17,55,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="West Side Story"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,8,18,40,0),
			EndTime = new DateTime(2020,12,8,21,12,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Forrest Gump"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,8,21,37,0),
			EndTime = new DateTime(2020,12,8,23,59,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Toy Story"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,8,9,0,0),
			EndTime = new DateTime(2020,12,8,10,21,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Dazed and Confused"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,8,10,50,0),
			EndTime = new DateTime(2020,12,8,12,32,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Lego Movie"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,8,13,0,0),
			EndTime = new DateTime(2020,12,8,14,40,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Princess Bride"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,8,15,20,0),
			EndTime = new DateTime(2020,12,8,16,58,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Finding Nemo"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,8,17,25,0),
			EndTime = new DateTime(2020,12,8,19,5,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Harry Potter and the Chamber of Secrets"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,8,19,30,0),
			EndTime = new DateTime(2020,12,8,22,11,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Land Before Time"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,8,22,40,0),
			EndTime = new DateTime(2020,12,8,23,49,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Footloose"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,9,9,5,0),
			EndTime = new DateTime(2020,12,9,10,52,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="WarGames"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,9,11,30,0),
			EndTime = new DateTime(2020,12,9,13,24,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Office Space"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,9,14,0,0),
			EndTime = new DateTime(2020,12,9,15,29,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Diamonds are Forever"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,9,15,55,0),
			EndTime = new DateTime(2020,12,9,17,55,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="West Side Story"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,9,18,40,0),
			EndTime = new DateTime(2020,12,9,21,12,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Forrest Gump"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,9,21,37,0),
			EndTime = new DateTime(2020,12,9,23,59,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Toy Story"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,9,9,0,0),
			EndTime = new DateTime(2020,12,9,10,21,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Dazed and Confused"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,9,10,50,0),
			EndTime = new DateTime(2020,12,9,12,32,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Lego Movie"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,9,13,0,0),
			EndTime = new DateTime(2020,12,9,14,40,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Princess Bride"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,9,15,20,0),
			EndTime = new DateTime(2020,12,9,16,58,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Finding Nemo"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,9,17,25,0),
			EndTime = new DateTime(2020,12,9,19,5,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Harry Potter and the Chamber of Secrets"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,9,19,30,0),
			EndTime = new DateTime(2020,12,9,22,11,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Land Before Time"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,9,22,40,0),
			EndTime = new DateTime(2020,12,9,23,49,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Footloose"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,10,9,5,0),
			EndTime = new DateTime(2020,12,10,10,52,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="WarGames"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,10,11,30,0),
			EndTime = new DateTime(2020,12,10,13,24,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Office Space"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,10,14,0,0),
			EndTime = new DateTime(2020,12,10,15,29,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Diamonds are Forever"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,10,15,55,0),
			EndTime = new DateTime(2020,12,10,17,55,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="West Side Story"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,10,18,40,0),
			EndTime = new DateTime(2020,12,10,21,12,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Forrest Gump"),
			TheaterNo ="Theater 1",
			StartTime = new DateTime(2020,12,10,21,37,0),
			EndTime = new DateTime(2020,12,10,23,59,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Toy Story"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,10,9,0,0),
			EndTime = new DateTime(2020,12,10,10,21,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Dazed and Confused"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,10,10,50,0),
			EndTime = new DateTime(2020,12,10,12,32,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Lego Movie"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,10,13,0,0),
			EndTime = new DateTime(2020,12,10,14,40,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Princess Bride"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,10,15,20,0),
			EndTime = new DateTime(2020,12,10,16,58,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Finding Nemo"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,10,17,25,0),
			EndTime = new DateTime(2020,12,10,19,5,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="Harry Potter and the Chamber of Secrets"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,10,19,30,0),
			EndTime = new DateTime(2020,12,10,22,11,0),
			SeatCount =20,
		});
		AllShowings.Add(new Showing 
		{
			Movie = db.Movies.FirstOrDefault(c => c.Title =="The Land Before Time"),
			TheaterNo ="Theater 2",
			StartTime = new DateTime(2020,12,10,22,40,0),
			EndTime = new DateTime(2020,12,10,23,49,0),
			SeatCount =20,
		});

		//create some counters to help debug problems
		Int32 intShowingID = 0;
		//String strShowingTitle ="Start";

		//loop throguh the list to add or update the movies
		try
		{
			foreach (Showing seedShowing in AllShowings)
			{
			//update the counters
			intShowingID = seedShowing.ShowingID;
			//see if the movie is already in the database using the MovieNumber
			Showing dbShowing = db.Showings.FirstOrDefault(m => m.ShowingID == seedShowing.ShowingID);

				//if movie is null, movie is not in the database
				if (dbShowing == null)
				{
					//Add the movie to the database
					db.Showings.Add(seedShowing);
					db.SaveChanges();
				}
				else //the movie is in the databae - reset all fields except the ID and the MovieNumber
				{
					dbShowing.Movie = seedShowing.Movie;
					dbShowing.StartTime = seedShowing.StartTime;
					dbShowing.EndTime = seedShowing.EndTime;
					db.SaveChanges();
				}
			}
			}
			catch (Exception ex) //throw error if there is a problem in the database
			{
				StringBuilder msg = new StringBuilder();
				msg.Append("There was a problem adding the showing with the ID: ");
				msg.Append(intShowingID);
				msg.Append(")");
				throw new Exception(msg.ToString(), ex);
			}
		}
	}
}
