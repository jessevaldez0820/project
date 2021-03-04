using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group25_Final_Project.DAL;
using Group25_Final_Project.Models;

namespace Group25_Final_Project.Seeding
{
	public static class SeedEmployees
	{
		public static async Task AddEmployee(IServiceProvider serviceProvider)
		{
			//Get instances of the services needed to add a user & add a user to a role
			AppDbContext _context = serviceProvider.GetRequiredService<AppDbContext>();
			UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
			RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			//: Add the needed roles
			//if the admin role doesn't exist, add it
			if (await _roleManager.RoleExistsAsync("Admin") == false)
			{
				await _roleManager.CreateAsync(new IdentityRole("Admin"));
			}

			if (await _roleManager.RoleExistsAsync("Manager") == false)
			{
				await _roleManager.CreateAsync(new IdentityRole("Manager"));
			}

			if (await _roleManager.RoleExistsAsync("Employee") == false)
			{
				await _roleManager.CreateAsync(new IdentityRole("Employee"));
			}

			if (await _roleManager.RoleExistsAsync("Customer") == false)
			{
				await _roleManager.CreateAsync(new IdentityRole("Customer"));
			}

			//check to see if the admin has already been added
			AppUser newUser = _context.Users.FirstOrDefault(u => u.Email == "admin@example.com");

			//if admin hasn't been created, then add them
			if (newUser == null)
			{
				//create a new instance of the app user class
				newUser = new AppUser();

				//populate the user properties that are from the 
				//IdentityUser base class
				newUser.UserName = "admin@example.com";
				newUser.Email = "admin@example.com";
				newUser.PhoneNumber = "(512)555-1234";

				//: Add additional fields that you created on the AppUser class
				//FirstName is included as an example
				newUser.FirstName = "Admin";
				newUser.LastName = "Admin";

				//create a variable for result
				IdentityResult result = new IdentityResult();
				try
				{
					//NOTE: Attempt to add the user using the UserManager
					//"Abc123!" is the password for this user
					result = await _userManager.CreateAsync(newUser, "Abc123!");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder();
					msg.Append("There was an error adding the user with the email ");
					msg.Append(newUser.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}
				//if the user was not added succesfully, throw an exception
				//so the user knows what happened
				if (result.Succeeded == false)
				{
					//Create a new string builder object to hold the error message(s)
					StringBuilder msg = new StringBuilder();

					//loop through all of the errors and add them to the message
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}

					//throw a new exception to tell the user something is wrong
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser = _context.Users.FirstOrDefault(u => u.UserName == "admin@example.com");
			}

			//Add the new user we just created to the Admin role
			if (await _userManager.IsInRoleAsync(newUser, "Admin") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Admin");
			}

			//save changes
			_context.SaveChanges();

			AppUser newUser2 = _context.Users.FirstOrDefault(u => u.Email == "t.jacobs@mainstreetmovies.com");

			if (newUser2 == null)
			{
				newUser2  = new AppUser();
				newUser2.UserName = "t.jacobs@mainstreetmovies.com";
				newUser2.Email = "t.jacobs@mainstreetmovies.com";
				newUser2.PhoneNumber = "9074653365";

				newUser2.FirstName = "Todd";
				newUser2.LastName = "Jacobs";
				newUser2.Initial = "L";
				newUser2.Birthday = new DateTime(1958, 4, 25);
				newUser2.EmpType = "Employee";
				newUser2.SocialSecurity = "341553365";
				newUser2.Address = "4564 Elm St.";
				newUser2.City = "Georgetown";
				newUser2.State = "TX";
				newUser2.ZipCode = "78628";
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser2 , "toddyboy");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser2.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}

				if (result.Succeeded == false)
				{
					StringBuilder msg = new StringBuilder();
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser2  = _context.Users.FirstOrDefault(u => u.UserName == "t.jacobs@mainstreetmovies.com");
			}

			if (newUser2.EmpType == "Manager")
			{
				await _userManager.AddToRoleAsync(newUser2 , "Manager");
			}
			if (newUser2.EmpType == "Employee")
			{
				await _userManager.AddToRoleAsync(newUser2 , "Employee");
			}
			_context.SaveChanges();


			AppUser newUser3 = _context.Users.FirstOrDefault(u => u.Email == "e.rice@mainstreetmovies.com");

			if (newUser3 == null)
			{
				newUser3  = new AppUser();
				newUser3.UserName = "e.rice@mainstreetmovies.com";
				newUser3.Email = "e.rice@mainstreetmovies.com";
				newUser3.PhoneNumber = "9073876657";

				newUser3.FirstName = "Eryn";
				newUser3.LastName = "Rice";
				newUser3.Initial = "M";
				newUser3.Birthday = new DateTime(1959, 7, 2);
				newUser3.EmpType = "Manager";
				newUser3.SocialSecurity = "454776657";
				newUser3.Address = "3405 Rio Grande";
				newUser3.City = "Austin";
				newUser3.State = "TX";
				newUser3.ZipCode = "78746";
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser3 , "ricearoni");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser3.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}

				if (result.Succeeded == false)
				{
					StringBuilder msg = new StringBuilder();
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser3  = _context.Users.FirstOrDefault(u => u.UserName == "e.rice@mainstreetmovies.com");
			}

			if (newUser3.EmpType == "Manager")
			{
				await _userManager.AddToRoleAsync(newUser3 , "Manager");
			}
			if (newUser3.EmpType == "Employee")
			{
				await _userManager.AddToRoleAsync(newUser3 , "Employee");
			}
			_context.SaveChanges();


			AppUser newUser4 = _context.Users.FirstOrDefault(u => u.Email == "a.taylor@mainstreetmovies.com");

			if (newUser4 == null)
			{
				newUser4  = new AppUser();
				newUser4.UserName = "a.taylor@mainstreetmovies.com";
				newUser4.Email = "a.taylor@mainstreetmovies.com";
				newUser4.PhoneNumber = "9074748452";

				newUser4.FirstName = "Allison";
				newUser4.LastName = "Taylor";
				newUser4.Initial = "R";
				newUser4.Birthday = new DateTime(1964, 9, 2);
				newUser4.EmpType = "Employee";
				newUser4.SocialSecurity = "934778452";
				newUser4.Address = "467 Nueces St.";
				newUser4.City = "Austin";
				newUser4.State = "TX";
				newUser4.ZipCode = "78727";
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser4 , "nostalgic");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser4.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}

				if (result.Succeeded == false)
				{
					StringBuilder msg = new StringBuilder();
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser4  = _context.Users.FirstOrDefault(u => u.UserName == "a.taylor@mainstreetmovies.com");
			}

			if (newUser4.EmpType == "Manager")
			{
				await _userManager.AddToRoleAsync(newUser4 , "Manager");
			}
			if (newUser4.EmpType == "Employee")
			{
				await _userManager.AddToRoleAsync(newUser4 , "Employee");
			}
			_context.SaveChanges();


			AppUser newUser5 = _context.Users.FirstOrDefault(u => u.Email == "g.martinez@mainstreetmovies.com");

			if (newUser5 == null)
			{
				newUser5  = new AppUser();
				newUser5.UserName = "g.martinez@mainstreetmovies.com";
				newUser5.Email = "g.martinez@mainstreetmovies.com";
				newUser5.PhoneNumber = "9078746718";

				newUser5.FirstName = "Gregory";
				newUser5.LastName = "Martinez";
				newUser5.Initial = "R";
				newUser5.Birthday = new DateTime(1992, 3, 30);
				newUser5.EmpType = "Employee";
				newUser5.SocialSecurity = "463566718";
				newUser5.Address = "8295 Sunset Blvd.";
				newUser5.City = "Austin";
				newUser5.State = "TX";
				newUser5.ZipCode = "78712";
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser5 , "fungus");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser5.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}

				if (result.Succeeded == false)
				{
					StringBuilder msg = new StringBuilder();
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser5  = _context.Users.FirstOrDefault(u => u.UserName == "g.martinez@mainstreetmovies.com");
			}

			if (newUser5.EmpType == "Manager")
			{
				await _userManager.AddToRoleAsync(newUser5 , "Manager");
			}
			if (newUser5.EmpType == "Employee")
			{
				await _userManager.AddToRoleAsync(newUser5 , "Employee");
			}
			_context.SaveChanges();


			AppUser newUser6 = _context.Users.FirstOrDefault(u => u.Email == "m.sheffield@mainstreetmovies.com");

			if (newUser6 == null)
			{
				newUser6  = new AppUser();
				newUser6.UserName = "m.sheffield@mainstreetmovies.com";
				newUser6.Email = "m.sheffield@mainstreetmovies.com";
				newUser6.PhoneNumber = "9075479167";

				newUser6.FirstName = "Martin";
				newUser6.LastName = "Sheffield";
				newUser6.Initial = "J";
				newUser6.Birthday = new DateTime(1996, 12, 29);
				newUser6.EmpType = "Employee";
				newUser6.SocialSecurity = "223449167";
				newUser6.Address = "3886 Avenue A";
				newUser6.City = "San Marcos";
				newUser6.State = "TX";
				newUser6.ZipCode = "78666";
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser6 , "longhorns");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser6.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}

				if (result.Succeeded == false)
				{
					StringBuilder msg = new StringBuilder();
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser6  = _context.Users.FirstOrDefault(u => u.UserName == "m.sheffield@mainstreetmovies.com");
			}

			if (newUser6.EmpType == "Manager")
			{
				await _userManager.AddToRoleAsync(newUser6 , "Manager");
			}
			if (newUser6.EmpType == "Employee")
			{
				await _userManager.AddToRoleAsync(newUser6 , "Employee");
			}
			_context.SaveChanges();


			AppUser newUser7 = _context.Users.FirstOrDefault(u => u.Email == "j.tanner@mainstreetmovies.com");

			if (newUser7 == null)
			{
				newUser7  = new AppUser();
				newUser7.UserName = "j.tanner@mainstreetmovies.com";
				newUser7.Email = "j.tanner@mainstreetmovies.com";
				newUser7.PhoneNumber = "9074590929";

				newUser7.FirstName = "Jeremy";
				newUser7.LastName = "Tanner";
				newUser7.Initial = "S";
				newUser7.Birthday = new DateTime(1970, 8, 12);
				newUser7.EmpType = "Manager";
				newUser7.SocialSecurity = "904440929";
				newUser7.Address = "4347 Almstead";
				newUser7.City = "Austin";
				newUser7.State = "TX";
				newUser7.ZipCode = "78712";
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser7 , "tanman");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser7.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}

				if (result.Succeeded == false)
				{
					StringBuilder msg = new StringBuilder();
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser7  = _context.Users.FirstOrDefault(u => u.UserName == "j.tanner@mainstreetmovies.com");
			}

			if (newUser7.EmpType == "Manager")
			{
				await _userManager.AddToRoleAsync(newUser7 , "Manager");
			}
			if (newUser7.EmpType == "Employee")
			{
				await _userManager.AddToRoleAsync(newUser7 , "Employee");
			}
			_context.SaveChanges();


			AppUser newUser8 = _context.Users.FirstOrDefault(u => u.Email == "m.rhodes@mainstreetmovies.com");

			if (newUser8 == null)
			{
				newUser8  = new AppUser();
				newUser8.UserName = "m.rhodes@mainstreetmovies.com";
				newUser8.Email = "m.rhodes@mainstreetmovies.com";
				newUser8.PhoneNumber = "9073744746";

				newUser8.FirstName = "Megan";
				newUser8.LastName = "Rhodes";
				newUser8.Initial = "C";
				newUser8.Birthday = new DateTime(1970, 12, 18);
				newUser8.EmpType = "Employee";
				newUser8.SocialSecurity = "353904746";
				newUser8.Address = "4587 Enfield Rd.";
				newUser8.City = "Austin";
				newUser8.State = "TX";
				newUser8.ZipCode = "78729";
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser8 , "countryrhodes");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser8.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}

				if (result.Succeeded == false)
				{
					StringBuilder msg = new StringBuilder();
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser8  = _context.Users.FirstOrDefault(u => u.UserName == "m.rhodes@mainstreetmovies.com");
			}

			if (newUser8.EmpType == "Manager")
			{
				await _userManager.AddToRoleAsync(newUser8 , "Manager");
			}
			if (newUser8.EmpType == "Employee")
			{
				await _userManager.AddToRoleAsync(newUser8 , "Employee");
			}
			_context.SaveChanges();


			AppUser newUser9 = _context.Users.FirstOrDefault(u => u.Email == "e.stuart@mainstreetmovies.com");

			if (newUser9 == null)
			{
				newUser9  = new AppUser();
				newUser9.UserName = "e.stuart@mainstreetmovies.com";
				newUser9.Email = "e.stuart@mainstreetmovies.com";
				newUser9.PhoneNumber = "9078178335";

				newUser9.FirstName = "Eric";
				newUser9.LastName = "Stuart";
				newUser9.Initial = "F";
				newUser9.Birthday = new DateTime(1971, 3, 11);
				newUser9.EmpType = "Employee";
				newUser9.SocialSecurity = "363998335";
				newUser9.Address = "5576 Toro Ring";
				newUser9.City = "San Antonio";
				newUser9.State = "TX";
				newUser9.ZipCode = "78758";
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser9 , "stewboy");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser9.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}

				if (result.Succeeded == false)
				{
					StringBuilder msg = new StringBuilder();
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser9  = _context.Users.FirstOrDefault(u => u.UserName == "e.stuart@mainstreetmovies.com");
			}

			if (newUser9.EmpType == "Manager")
			{
				await _userManager.AddToRoleAsync(newUser9 , "Manager");
			}
			if (newUser9.EmpType == "Employee")
			{
				await _userManager.AddToRoleAsync(newUser9 , "Employee");
			}
			_context.SaveChanges();


			AppUser newUser10 = _context.Users.FirstOrDefault(u => u.Email == "r.taylor@mainstreetmovies.com");

			if (newUser10 == null)
			{
				newUser10  = new AppUser();
				newUser10.UserName = "r.taylor@mainstreetmovies.com";
				newUser10.Email = "r.taylor@mainstreetmovies.com";
				newUser10.PhoneNumber = "9074512631";

				newUser10.FirstName = "Rachel";
				newUser10.LastName = "Taylor";
				newUser10.Initial = "O";
				newUser10.Birthday = new DateTime(1972, 12, 20);
				newUser10.EmpType = "Manager";
				newUser10.SocialSecurity = "393412631";
				newUser10.Address = "345 Longview Dr.";
				newUser10.City = "Austin";
				newUser10.State = "TX";
				newUser10.ZipCode = "78746";
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser10 , "swansong");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser10.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}

				if (result.Succeeded == false)
				{
					StringBuilder msg = new StringBuilder();
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser10  = _context.Users.FirstOrDefault(u => u.UserName == "r.taylor@mainstreetmovies.com");
			}

			if (newUser10.EmpType == "Manager")
			{
				await _userManager.AddToRoleAsync(newUser10 , "Manager");
			}
			if (newUser10.EmpType == "Employee")
			{
				await _userManager.AddToRoleAsync(newUser10 , "Employee");
			}
			_context.SaveChanges();


			AppUser newUser11 = _context.Users.FirstOrDefault(u => u.Email == "v.lawrence@mainstreetmovies.com");

			if (newUser11 == null)
			{
				newUser11  = new AppUser();
				newUser11.UserName = "v.lawrence@mainstreetmovies.com";
				newUser11.Email = "v.lawrence@mainstreetmovies.com";
				newUser11.PhoneNumber = "9079457399";

				newUser11.FirstName = "Tori";
				newUser11.LastName = "Lawrence";
				newUser11.Initial = "Y";
				newUser11.Birthday = new DateTime(1973, 4, 28);
				newUser11.EmpType = "Employee";
				newUser11.SocialSecurity = "770097399";
				newUser11.Address = "6639 Butterfly Ln.";
				newUser11.City = "Austin";
				newUser11.State = "TX";
				newUser11.ZipCode = "78712";
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser11 , "lottery");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser11.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}

				if (result.Succeeded == false)
				{
					StringBuilder msg = new StringBuilder();
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser11  = _context.Users.FirstOrDefault(u => u.UserName == "v.lawrence@mainstreetmovies.com");
			}

			if (newUser11.EmpType == "Manager")
			{
				await _userManager.AddToRoleAsync(newUser11 , "Manager");
			}
			if (newUser11.EmpType == "Employee")
			{
				await _userManager.AddToRoleAsync(newUser11 , "Employee");
			}
			_context.SaveChanges();


			AppUser newUser12 = _context.Users.FirstOrDefault(u => u.Email == "a.rogers@mainstreetmovies.com");

			if (newUser12 == null)
			{
				newUser12  = new AppUser();
				newUser12.UserName = "a.rogers@mainstreetmovies.com";
				newUser12.Email = "a.rogers@mainstreetmovies.com";
				newUser12.PhoneNumber = "9078752943";

				newUser12.FirstName = "Allen";
				newUser12.LastName = "Alberts";
				newUser12.Initial = "H";
				newUser12.Birthday = new DateTime(1978, 6, 21);
				newUser12.EmpType = "Manager";
				newUser12.SocialSecurity = "700002943";
				newUser12.Address = "4965 Oak Hill";
				newUser12.City = "Austin";
				newUser12.State = "TX";
				newUser12.ZipCode = "78705";
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser12 , "evanescent");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser12.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}

				if (result.Succeeded == false)
				{
					StringBuilder msg = new StringBuilder();
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser12  = _context.Users.FirstOrDefault(u => u.UserName == "a.rogers@mainstreetmovies.com");
			}

			if (newUser12.EmpType == "Manager")
			{
				await _userManager.AddToRoleAsync(newUser12 , "Manager");
			}
			if (newUser12.EmpType == "Employee")
			{
				await _userManager.AddToRoleAsync(newUser12 , "Employee");
			}
			_context.SaveChanges();


			AppUser newUser13 = _context.Users.FirstOrDefault(u => u.Email == "c.baker@mainstreetmovies.com");

			if (newUser13 == null)
			{
				newUser13  = new AppUser();
				newUser13.UserName = "c.baker@mainstreetmovies.com";
				newUser13.Email = "c.baker@mainstreetmovies.com";
				newUser13.PhoneNumber = "9075571146";

				newUser13.FirstName = "Christopher";
				newUser13.LastName = "Baker";
				newUser13.Initial = "E";
				newUser13.Birthday = new DateTime(1993, 3, 16);
				newUser13.EmpType = "Employee";
				newUser13.SocialSecurity = "401661146";
				newUser13.Address = "1245 Lake Anchorage Blvd.";
				newUser13.City = "Cedar Park";
				newUser13.State = "TX";
				newUser13.ZipCode = "78613";
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser13 , "hecktour");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser13.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}

				if (result.Succeeded == false)
				{
					StringBuilder msg = new StringBuilder();
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser13  = _context.Users.FirstOrDefault(u => u.UserName == "c.baker@mainstreetmovies.com");
			}

			if (newUser13.EmpType == "Manager")
			{
				await _userManager.AddToRoleAsync(newUser13 , "Manager");
			}
			if (newUser13.EmpType == "Employee")
			{
				await _userManager.AddToRoleAsync(newUser13 , "Employee");
			}
			_context.SaveChanges();


			AppUser newUser14 = _context.Users.FirstOrDefault(u => u.Email == "w.sewell@mainstreetmovies.com");

			if (newUser14 == null)
			{
				newUser14  = new AppUser();
				newUser14.UserName = "w.sewell@mainstreetmovies.com";
				newUser14.Email = "w.sewell@mainstreetmovies.com";
				newUser14.PhoneNumber = "9074510084";

				newUser14.FirstName = "William";
				newUser14.LastName = "Sewell";
				newUser14.Initial = "G";
				newUser14.Birthday = new DateTime(1986, 5, 25);
				newUser14.EmpType = "Employee";
				newUser14.SocialSecurity = "500830084";
				newUser14.Address = "2365 51st St.";
				newUser14.City = "Austin";
				newUser14.State = "TX";
				newUser14.ZipCode = "78755";
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser14 , "walkamile");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser14.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}

				if (result.Succeeded == false)
				{
					StringBuilder msg = new StringBuilder();
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser14  = _context.Users.FirstOrDefault(u => u.UserName == "w.sewell@mainstreetmovies.com");
			}

			if (newUser14.EmpType == "Manager")
			{
				await _userManager.AddToRoleAsync(newUser14 , "Manager");
			}
			if (newUser14.EmpType == "Employee")
			{
				await _userManager.AddToRoleAsync(newUser14 , "Employee");
			}
			_context.SaveChanges();


			AppUser newUser15 = _context.Users.FirstOrDefault(u => u.Email == "j.mason@mainstreetmovies.com");

			if (newUser15 == null)
			{
				newUser15  = new AppUser();
				newUser15.UserName = "j.mason@mainstreetmovies.com";
				newUser15.Email = "j.mason@mainstreetmovies.com";
				newUser15.PhoneNumber = "9018833432";

				newUser15.FirstName = "Jack";
				newUser15.LastName = "Mason";
				newUser15.Initial = "L";
				newUser15.Birthday = new DateTime(1986, 6, 6);
				newUser15.EmpType = "Employee";
				newUser15.SocialSecurity = "1112223232";
				newUser15.Address = "444 45th St";
				newUser15.City = "Austin";
				newUser15.State = "TX";
				newUser15.ZipCode = "78701";
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser15 , "changalang");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser15.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}

				if (result.Succeeded == false)
				{
					StringBuilder msg = new StringBuilder();
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser15  = _context.Users.FirstOrDefault(u => u.UserName == "j.mason@mainstreetmovies.com");
			}

			if (newUser15.EmpType == "Manager")
			{
				await _userManager.AddToRoleAsync(newUser15 , "Manager");
			}
			if (newUser15.EmpType == "Employee")
			{
				await _userManager.AddToRoleAsync(newUser15 , "Employee");
			}
			_context.SaveChanges();


			AppUser newUser16 = _context.Users.FirstOrDefault(u => u.Email == "j.jackson@mainstreetmovies.com");

			if (newUser16 == null)
			{
				newUser16  = new AppUser();
				newUser16.UserName = "j.jackson@mainstreetmovies.com";
				newUser16.Email = "j.jackson@mainstreetmovies.com";
				newUser16.PhoneNumber = "9075554545";

				newUser16.FirstName = "Jack";
				newUser16.LastName = "Jackson";
				newUser16.Initial = "J";
				newUser16.Birthday = new DateTime(1989, 10, 16);
				newUser16.EmpType = "Employee";
				newUser16.SocialSecurity = "8889993434";
				newUser16.Address = "222 Main";
				newUser16.City = "Austin";
				newUser16.State = "TX";
				newUser16.ZipCode = "78760";
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser16 , "offbeat");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser16.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}

				if (result.Succeeded == false)
				{
					StringBuilder msg = new StringBuilder();
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser16  = _context.Users.FirstOrDefault(u => u.UserName == "j.jackson@mainstreetmovies.com");
			}

			if (newUser16.EmpType == "Manager")
			{
				await _userManager.AddToRoleAsync(newUser16 , "Manager");
			}
			if (newUser16.EmpType == "Employee")
			{
				await _userManager.AddToRoleAsync(newUser16 , "Employee");
			}
			_context.SaveChanges();


			AppUser newUser17 = _context.Users.FirstOrDefault(u => u.Email == "m.nguyen@mainstreetmovies.com");

			if (newUser17 == null)
			{
				newUser17  = new AppUser();
				newUser17.UserName = "m.nguyen@mainstreetmovies.com";
				newUser17.Email = "m.nguyen@mainstreetmovies.com";
				newUser17.PhoneNumber = "9075524141";

				newUser17.FirstName = "Andy";
				newUser17.LastName = "Nguyen";
				newUser17.Initial = "M";
				newUser17.Birthday = new DateTime(1988, 4, 5);
				newUser17.EmpType = "Manager";
				newUser17.SocialSecurity = "7776665555";
				newUser17.Address = "465 N. Bear Cub";
				newUser17.City = "Austin";
				newUser17.State = "TX";
				newUser17.ZipCode = "78734";
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser17 , "landus");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser17.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}

				if (result.Succeeded == false)
				{
					StringBuilder msg = new StringBuilder();
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser17  = _context.Users.FirstOrDefault(u => u.UserName == "m.nguyen@mainstreetmovies.com");
			}

			if (newUser17.EmpType == "Manager")
			{
				await _userManager.AddToRoleAsync(newUser17 , "Manager");
			}
			if (newUser17.EmpType == "Employee")
			{
				await _userManager.AddToRoleAsync(newUser17 , "Employee");
			}
			_context.SaveChanges();


			AppUser newUser18 = _context.Users.FirstOrDefault(u => u.Email == "s.barnes@mainstreetmovies.com");

			if (newUser18 == null)
			{
				newUser18  = new AppUser();
				newUser18.UserName = "s.barnes@mainstreetmovies.com";
				newUser18.Email = "s.barnes@mainstreetmovies.com";
				newUser18.PhoneNumber = "9556662323";

				newUser18.FirstName = "Susan";
				newUser18.LastName = "Barnes";
				newUser18.Initial = "M";
				newUser18.Birthday = new DateTime(1993, 2, 22);
				newUser18.EmpType = "Employee";
				newUser18.SocialSecurity = "1112221212";
				newUser18.Address = "888 S. Main";
				newUser18.City = "Kyle";
				newUser18.State = "TX";
				newUser18.ZipCode = "78640";
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser18 , "rhythm");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser18.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}

				if (result.Succeeded == false)
				{
					StringBuilder msg = new StringBuilder();
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser18  = _context.Users.FirstOrDefault(u => u.UserName == "s.barnes@mainstreetmovies.com");
			}

			if (newUser18.EmpType == "Manager")
			{
				await _userManager.AddToRoleAsync(newUser18 , "Manager");
			}
			if (newUser18.EmpType == "Employee")
			{
				await _userManager.AddToRoleAsync(newUser18 , "Employee");
			}
			_context.SaveChanges();


			AppUser newUser19 = _context.Users.FirstOrDefault(u => u.Email == "l.jones@mainstreetmovies.com");

			if (newUser19 == null)
			{
				newUser19  = new AppUser();
				newUser19.UserName = "l.jones@mainstreetmovies.com";
				newUser19.Email = "l.jones@mainstreetmovies.com";
				newUser19.PhoneNumber = "9886662222";

				newUser19.FirstName = "Sarah";
				newUser19.LastName = "Johns";
				newUser19.Initial = "L";
				newUser19.Birthday = new DateTime(1996, 6, 29);
				newUser19.EmpType = "Employee";
				newUser19.SocialSecurity = "9099099999";
				newUser19.Address = "999 LeBlat";
				newUser19.City = "Austin";
				newUser19.State = "TX";
				newUser19.ZipCode = "78747";
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser19 , "kindly");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser19.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}

				if (result.Succeeded == false)
				{
					StringBuilder msg = new StringBuilder();
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser19  = _context.Users.FirstOrDefault(u => u.UserName == "l.jones@mainstreetmovies.com");
			}

			if (newUser19.EmpType == "Manager")
			{
				await _userManager.AddToRoleAsync(newUser19 , "Manager");
			}
			if (newUser19.EmpType == "Employee")
			{
				await _userManager.AddToRoleAsync(newUser19 , "Employee");
			}
			_context.SaveChanges();


			AppUser newUser20 = _context.Users.FirstOrDefault(u => u.Email == "c.silva@mainstreetmovies.com");

			if (newUser20 == null)
			{
				newUser20  = new AppUser();
				newUser20.UserName = "c.silva@mainstreetmovies.com";
				newUser20.Email = "c.silva@mainstreetmovies.com";
				newUser20.PhoneNumber = "9221113333";

				newUser20.FirstName = "Cindy";
				newUser20.LastName = "Silva";
				newUser20.Initial = "S";
				newUser20.Birthday = new DateTime(1997, 12, 29);
				newUser20.EmpType = "Employee";
				newUser20.SocialSecurity = "7776661111";
				newUser20.Address = "900 4th St";
				newUser20.City = "Austin";
				newUser20.State = "TX";
				newUser20.ZipCode = "78758";
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser20 , "arched");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser20.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}

				if (result.Succeeded == false)
				{
					StringBuilder msg = new StringBuilder();
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser20  = _context.Users.FirstOrDefault(u => u.UserName == "c.silva@mainstreetmovies.com");
			}

			if (newUser20.EmpType == "Manager")
			{
				await _userManager.AddToRoleAsync(newUser20 , "Manager");
			}
			if (newUser20.EmpType == "Employee")
			{
				await _userManager.AddToRoleAsync(newUser20 , "Employee");
			}
			_context.SaveChanges();


			AppUser newUser21 = _context.Users.FirstOrDefault(u => u.Email == "s.rankin@mainstreetmovies.com");

			if (newUser21 == null)
			{
				newUser21  = new AppUser();
				newUser21.UserName = "s.rankin@mainstreetmovies.com";
				newUser21.Email = "s.rankin@mainstreetmovies.com";
				newUser21.PhoneNumber = "9893336666";

				newUser21.FirstName = "ml";
				newUser21.LastName = "Rankin";
				newUser21.Initial = "R";
				newUser21.Birthday = new DateTime(1999, 12, 17);
				newUser21.EmpType = "Employee";
				newUser21.SocialSecurity = "1911919111";
				newUser21.Address = "23 Polar Bear Road";
				newUser21.City = "Buda";
				newUser21.State = "TX";
				newUser21.ZipCode = "78712";
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser21 , "decorate");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser21.Email);
					msg.Append(". This often happens because you are missing a required field on AppUser");
					throw new Exception(msg.ToString(), ex);
				}

				if (result.Succeeded == false)
				{
					StringBuilder msg = new StringBuilder();
					foreach (var error in result.Errors)
					{
						msg.AppendLine(error.ToString());
					}
					throw new Exception("This user can't be added:" + msg.ToString());
				}
				_context.SaveChanges();
				newUser21  = _context.Users.FirstOrDefault(u => u.UserName == "s.rankin@mainstreetmovies.com");
			}

			if (newUser21.EmpType == "Manager")
			{
				await _userManager.AddToRoleAsync(newUser21 , "Manager");
			}
			if (newUser21.EmpType == "Employee")
			{
				await _userManager.AddToRoleAsync(newUser21 , "Employee");
			}
			_context.SaveChanges();


		}
	}
}
