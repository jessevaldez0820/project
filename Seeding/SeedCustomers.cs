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
	public static class SeedCustomers
	{
		public static async Task AddCustomer(IServiceProvider serviceProvider)
		{
			//Get instances of the services needed to add a user & add a user to a role
			AppDbContext _context = serviceProvider.GetRequiredService<AppDbContext>();
			UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
			RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

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

			AppUser newUser22 = _context.Users.FirstOrDefault(u => u.Email == "cbaker@puppy.com");

			if (newUser22 == null)
			{
				newUser22  = new AppUser();
				newUser22.UserName = "cbaker@puppy.com";
				newUser22.Email = "cbaker@puppy.com";
				newUser22.PhoneNumber = "5125551132";

				newUser22.FirstName = "Christopher";
				newUser22.LastName = "Baker";
				newUser22.Initial = "L";
				newUser22.Birthday = new DateTime(1949, 11, 23);
				newUser22.CustomerNumber = 5001;
				newUser22.Address = "1245 Lake Anchorage Blvd.";
				newUser22.City = "Austin";
				newUser22.State = "TX";
				newUser22.ZipCode = "37705";
				newUser22.PopcornPoints = 90;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser22 , "hello1");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser22.Email);
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
				newUser22  = _context.Users.FirstOrDefault(u => u.UserName == "cbaker@puppy.com");
			}

			if (newUser22.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser22 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser23 = _context.Users.FirstOrDefault(u => u.Email == "banker@longhorn.net");

			if (newUser23 == null)
			{
				newUser23  = new AppUser();
				newUser23.UserName = "banker@longhorn.net";
				newUser23.Email = "banker@longhorn.net";
				newUser23.PhoneNumber = "5125552243";

				newUser23.FirstName = "Martin";
				newUser23.LastName = "Banks";
				newUser23.Initial = "T";
				newUser23.Birthday = new DateTime(1962, 11, 27);
				newUser23.CustomerNumber = 5002;
				newUser23.Address = "6700 Small Pine Lane";
				newUser23.City = "Austin";
				newUser23.State = "TX";
				newUser23.ZipCode = "37712";
				newUser23.PopcornPoints = 80;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser23 , "snowing");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser23.Email);
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
				newUser23  = _context.Users.FirstOrDefault(u => u.UserName == "banker@longhorn.net");
			}

			if (newUser23.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser23 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser24 = _context.Users.FirstOrDefault(u => u.Email == "franco@puppy.com");

			if (newUser24 == null)
			{
				newUser24  = new AppUser();
				newUser24.UserName = "franco@puppy.com";
				newUser24.Email = "franco@puppy.com";
				newUser24.PhoneNumber = "5125555546";

				newUser24.FirstName = "Franco";
				newUser24.LastName = "Broccolo";
				newUser24.Initial = "V";
				newUser24.Birthday = new DateTime(1992, 10, 11);
				newUser24.CustomerNumber = 5003;
				newUser24.Address = "562 Sad Road";
				newUser24.City = "Austin";
				newUser24.State = "TX";
				newUser24.ZipCode = "37704";
				newUser24.PopcornPoints = 10;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser24 , "skating");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser24.Email);
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
				newUser24  = _context.Users.FirstOrDefault(u => u.UserName == "franco@puppy.com");
			}

			if (newUser24.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser24 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser25 = _context.Users.FirstOrDefault(u => u.Email == "wchang@puppy.com");

			if (newUser25 == null)
			{
				newUser25  = new AppUser();
				newUser25.UserName = "wchang@puppy.com";
				newUser25.Email = "wchang@puppy.com";
				newUser25.PhoneNumber = "5125553376";

				newUser25.FirstName = "Wiseman";
				newUser25.LastName = "Chang";
				newUser25.Initial = "L";
				newUser25.Birthday = new DateTime(1997, 5, 16);
				newUser25.CustomerNumber = 5004;
				newUser25.Address = "7202 Big Hall";
				newUser25.City = "Round Rock";
				newUser25.State = "TX";
				newUser25.ZipCode = "37681";
				newUser25.PopcornPoints = 20;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser25 , "Fighter");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser25.Email);
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
				newUser25  = _context.Users.FirstOrDefault(u => u.UserName == "wchang@puppy.com");
			}

			if (newUser25.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser25 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser26 = _context.Users.FirstOrDefault(u => u.Email == "limchou@gogle.com");

			if (newUser26 == null)
			{
				newUser26  = new AppUser();
				newUser26.UserName = "limchou@gogle.com";
				newUser26.Email = "limchou@gogle.com";
				newUser26.PhoneNumber = "5125555379";

				newUser26.FirstName = "Lim";
				newUser26.LastName = "Chou";
				newUser26.Initial = "C";
				newUser26.Birthday = new DateTime(1970, 4, 6);
				newUser26.CustomerNumber = 5005;
				newUser26.Address = "8600 Cherry Lane";
				newUser26.City = "Austin";
				newUser26.State = "TX";
				newUser26.ZipCode = "37705";
				newUser26.PopcornPoints = 70;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser26 , "Dallas63");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser26.Email);
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
				newUser26  = _context.Users.FirstOrDefault(u => u.UserName == "limchou@gogle.com");
			}

			if (newUser26.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser26 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser27 = _context.Users.FirstOrDefault(u => u.Email == "shdixon@aoll.com");

			if (newUser27 == null)
			{
				newUser27  = new AppUser();
				newUser27.UserName = "shdixon@aoll.com";
				newUser27.Email = "shdixon@aoll.com";
				newUser27.PhoneNumber = "5125556607";

				newUser27.FirstName = "Shaman";
				newUser27.LastName = "Dixon";
				newUser27.Initial = "D";
				newUser27.Birthday = new DateTime(1984, 1, 12);
				newUser27.CustomerNumber = 5006;
				newUser27.Address = "8234 Puppy Circle";
				newUser27.City = "Austin";
				newUser27.State = "TX";
				newUser27.ZipCode = "37712";
				newUser27.PopcornPoints = 10;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser27 , "peppero");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser27.Email);
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
				newUser27  = _context.Users.FirstOrDefault(u => u.UserName == "shdixon@aoll.com");
			}

			if (newUser27.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser27 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser28 = _context.Users.FirstOrDefault(u => u.Email == "j.b.evans@aheca.org");

			if (newUser28 == null)
			{
				newUser28  = new AppUser();
				newUser28.UserName = "j.b.evans@aheca.org";
				newUser28.Email = "j.b.evans@aheca.org";
				newUser28.PhoneNumber = "5125552289";

				newUser28.FirstName = "Jim Bob";
				newUser28.LastName = "Evans";
				newUser28.Initial = "C";
				newUser28.Birthday = new DateTime(1959, 9, 9);
				newUser28.CustomerNumber = 5007;
				newUser28.Address = "9506 Kitten Circle";
				newUser28.City = "Georgetown";
				newUser28.State = "TX";
				newUser28.ZipCode = "37628";
				newUser28.PopcornPoints = 0;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser28 , "longhorn");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser28.Email);
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
				newUser28  = _context.Users.FirstOrDefault(u => u.UserName == "j.b.evans@aheca.org");
			}

			if (newUser28.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser28 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser29 = _context.Users.FirstOrDefault(u => u.Email == "feeley@penguin.org");

			if (newUser29 == null)
			{
				newUser29  = new AppUser();
				newUser29.UserName = "feeley@penguin.org";
				newUser29.Email = "feeley@penguin.org";
				newUser29.PhoneNumber = "5125559999";

				newUser29.FirstName = "Lou Ann";
				newUser29.LastName = "Feeley";
				newUser29.Initial = "K";
				newUser29.Birthday = new DateTime(2001, 1, 12);
				newUser29.CustomerNumber = 5008;
				newUser29.Address = "7600 N 7th Street W";
				newUser29.City = "Austin";
				newUser29.State = "TX";
				newUser29.ZipCode = "37746";
				newUser29.PopcornPoints = 200;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser29 , "aggiesuck");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser29.Email);
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
				newUser29  = _context.Users.FirstOrDefault(u => u.UserName == "feeley@penguin.org");
			}

			if (newUser29.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser29 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser30 = _context.Users.FirstOrDefault(u => u.Email == "tfreeley@minnetonka.ci.us");

			if (newUser30 == null)
			{
				newUser30  = new AppUser();
				newUser30.UserName = "tfreeley@minnetonka.ci.us";
				newUser30.Email = "tfreeley@minnetonka.ci.us";
				newUser30.PhoneNumber = "5125558827";

				newUser30.FirstName = "Teresa";
				newUser30.LastName = "Freeley";
				newUser30.Initial = "P";
				newUser30.Birthday = new DateTime(1991, 2, 4);
				newUser30.CustomerNumber = 5009;
				newUser30.Address = "5448 Clearview Ave.";
				newUser30.City = "Horseshoe Bay";
				newUser30.State = "TX";
				newUser30.ZipCode = "37657";
				newUser30.PopcornPoints = 250;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser30 , "raiders75");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser30.Email);
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
				newUser30  = _context.Users.FirstOrDefault(u => u.UserName == "tfreeley@minnetonka.ci.us");
			}

			if (newUser30.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser30 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser31 = _context.Users.FirstOrDefault(u => u.Email == "mgarcia@gogle.com");

			if (newUser31 == null)
			{
				newUser31  = new AppUser();
				newUser31.UserName = "mgarcia@gogle.com";
				newUser31.Email = "mgarcia@gogle.com";
				newUser31.PhoneNumber = "5125550002";

				newUser31.FirstName = "Mikaela";
				newUser31.LastName = "Garcia";
				newUser31.Initial = "L";
				newUser31.Birthday = new DateTime(1991, 10, 2);
				newUser31.CustomerNumber = 5010;
				newUser31.Address = "3594 Cowview";
				newUser31.City = "Austin";
				newUser31.State = "TX";
				newUser31.ZipCode = "37727";
				newUser31.PopcornPoints = 40;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser31 , "mustang54");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser31.Email);
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
				newUser31  = _context.Users.FirstOrDefault(u => u.UserName == "mgarcia@gogle.com");
			}

			if (newUser31.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser31 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser32 = _context.Users.FirstOrDefault(u => u.Email == "chaley@mug.com");

			if (newUser32 == null)
			{
				newUser32  = new AppUser();
				newUser32.UserName = "chaley@mug.com";
				newUser32.Email = "chaley@mug.com";
				newUser32.PhoneNumber = "5125550198";

				newUser32.FirstName = "Charmander";
				newUser32.LastName = "Haley";
				newUser32.Initial = "E";
				newUser32.Birthday = new DateTime(1974, 7, 10);
				newUser32.CustomerNumber = 5011;
				newUser32.Address = "43 One Pigboy Pkwy";
				newUser32.City = "Austin";
				newUser32.State = "TX";
				newUser32.ZipCode = "37712";
				newUser32.PopcornPoints = 30;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser32 , "onetime76");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser32.Email);
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
				newUser32  = _context.Users.FirstOrDefault(u => u.UserName == "chaley@mug.com");
			}

			if (newUser32.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser32 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser33 = _context.Users.FirstOrDefault(u => u.Email == "jeffh@mario.com");

			if (newUser33 == null)
			{
				newUser33  = new AppUser();
				newUser33.UserName = "jeffh@mario.com";
				newUser33.Email = "jeffh@mario.com";
				newUser33.PhoneNumber = "5125552134";

				newUser33.FirstName = "Jeff";
				newUser33.LastName = "Hampton";
				newUser33.Initial = "T";
				newUser33.Birthday = new DateTime(2004, 3, 10);
				newUser33.CustomerNumber = 5012;
				newUser33.Address = "7337 67th St.";
				newUser33.City = "San Marcos";
				newUser33.State = "TX";
				newUser33.ZipCode = "37666";
				newUser33.PopcornPoints = 50;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser33 , "hampton98");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser33.Email);
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
				newUser33  = _context.Users.FirstOrDefault(u => u.UserName == "jeffh@mario.com");
			}

			if (newUser33.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser33 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser34 = _context.Users.FirstOrDefault(u => u.Email == "wjhearniii@umich.org");

			if (newUser34 == null)
			{
				newUser34  = new AppUser();
				newUser34.UserName = "wjhearniii@umich.org";
				newUser34.Email = "wjhearniii@umich.org";
				newUser34.PhoneNumber = "5125559729";

				newUser34.FirstName = "John";
				newUser34.LastName = "Hearn";
				newUser34.Initial = "B";
				newUser34.Birthday = new DateTime(1950, 8, 5);
				newUser34.CustomerNumber = 5013;
				newUser34.Address = "8225 South First";
				newUser34.City = "Plano";
				newUser34.State = "TX";
				newUser34.ZipCode = "37705";
				newUser34.PopcornPoints = 60;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser34 , "jhearn99");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser34.Email);
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
				newUser34  = _context.Users.FirstOrDefault(u => u.UserName == "wjhearniii@umich.org");
			}

			if (newUser34.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser34 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser35 = _context.Users.FirstOrDefault(u => u.Email == "ahick@yaho.com");

			if (newUser35 == null)
			{
				newUser35  = new AppUser();
				newUser35.UserName = "ahick@yaho.com";
				newUser35.Email = "ahick@yaho.com";
				newUser35.PhoneNumber = "5125553967";

				newUser35.FirstName = "Abadon";
				newUser35.LastName = "Hicks";
				newUser35.Initial = "J";
				newUser35.Birthday = new DateTime(2004, 12, 8);
				newUser35.CustomerNumber = 5014;
				newUser35.Address = "632 NE Dog Ln., Ste 910";
				newUser35.City = "Austin";
				newUser35.State = "TX";
				newUser35.ZipCode = "37712";
				newUser35.PopcornPoints = 60;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser35 , "hickemon");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser35.Email);
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
				newUser35  = _context.Users.FirstOrDefault(u => u.UserName == "ahick@yaho.com");
			}

			if (newUser35.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser35 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser36 = _context.Users.FirstOrDefault(u => u.Email == "ingram@jack.com");

			if (newUser36 == null)
			{
				newUser36  = new AppUser();
				newUser36.UserName = "ingram@jack.com";
				newUser36.Email = "ingram@jack.com";
				newUser36.PhoneNumber = "5125552142";

				newUser36.FirstName = "Brock";
				newUser36.LastName = "Ingram";
				newUser36.Initial = "S";
				newUser36.Birthday = new DateTime(2001, 9, 5);
				newUser36.CustomerNumber = 5015;
				newUser36.Address = "9548 El Perro Ct.";
				newUser36.City = "New York";
				newUser36.State = "NY";
				newUser36.ZipCode = "10101";
				newUser36.PopcornPoints = 90;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser36 , "ingram2098");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser36.Email);
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
				newUser36  = _context.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com");
			}

			if (newUser36.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser36 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser37 = _context.Users.FirstOrDefault(u => u.Email == "toddj@yourmom.com");

			if (newUser37 == null)
			{
				newUser37  = new AppUser();
				newUser37.UserName = "toddj@yourmom.com";
				newUser37.Email = "toddj@yourmom.com";
				newUser37.PhoneNumber = "5125555557";

				newUser37.FirstName = "Todd";
				newUser37.LastName = "Jack";
				newUser37.Initial = "L";
				newUser37.Birthday = new DateTime(1999, 1, 20);
				newUser37.CustomerNumber = 5016;
				newUser37.Address = "2564 Tree St.";
				newUser37.City = "Austin";
				newUser37.State = "TX";
				newUser37.ZipCode = "37729";
				newUser37.PopcornPoints = 140;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser37 , "toddy53");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser37.Email);
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
				newUser37  = _context.Users.FirstOrDefault(u => u.UserName == "toddj@yourmom.com");
			}

			if (newUser37.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser37 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser38 = _context.Users.FirstOrDefault(u => u.Email == "thequeen@aska.net");

			if (newUser38 == null)
			{
				newUser38  = new AppUser();
				newUser38.UserName = "thequeen@aska.net";
				newUser38.Email = "thequeen@aska.net";
				newUser38.PhoneNumber = "5125550156";

				newUser38.FirstName = "Vic";
				newUser38.LastName = "Lancer";
				newUser38.Initial = "M";
				newUser38.Birthday = new DateTime(2000, 4, 14);
				newUser38.CustomerNumber = 5017;
				newUser38.Address = "1639 Butter Ln.";
				newUser38.City = "Beverly Hills";
				newUser38.State = "CA";
				newUser38.ZipCode = "90210";
				newUser38.PopcornPoints = 110;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser38 , "nothing34");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser38.Email);
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
				newUser38  = _context.Users.FirstOrDefault(u => u.UserName == "thequeen@aska.net");
			}

			if (newUser38.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser38 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser39 = _context.Users.FirstOrDefault(u => u.Email == "linebacker@gogle.com");

			if (newUser39 == null)
			{
				newUser39  = new AppUser();
				newUser39.UserName = "linebacker@gogle.com";
				newUser39.Email = "linebacker@gogle.com";
				newUser39.PhoneNumber = "5125550168";

				newUser39.FirstName = "Sweeney";
				newUser39.LastName = "Lineback";
				newUser39.Initial = "W";
				newUser39.Birthday = new DateTime(2003, 12, 2);
				newUser39.CustomerNumber = 5018;
				newUser39.Address = "1700 Land St";
				newUser39.City = "Austin";
				newUser39.State = "TX";
				newUser39.ZipCode = "37758";
				newUser39.PopcornPoints = 50;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser39 , "Password5");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser39.Email);
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
				newUser39  = _context.Users.FirstOrDefault(u => u.UserName == "linebacker@gogle.com");
			}

			if (newUser39.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser39 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser40 = _context.Users.FirstOrDefault(u => u.Email == "elowe@scare.net");

			if (newUser40 == null)
			{
				newUser40  = new AppUser();
				newUser40.UserName = "elowe@scare.net";
				newUser40.Email = "elowe@scare.net";
				newUser40.PhoneNumber = "5125556959";

				newUser40.FirstName = "Ernesto";
				newUser40.LastName = "Lowe";
				newUser40.Initial = "S";
				newUser40.Birthday = new DateTime(1977, 12, 7);
				newUser40.CustomerNumber = 5019;
				newUser40.Address = "2301 Snail Drive";
				newUser40.City = "New Braunfels";
				newUser40.State = "TX";
				newUser40.ZipCode = "37130";
				newUser40.PopcornPoints = 40;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser40 , "aclfest2076");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser40.Email);
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
				newUser40  = _context.Users.FirstOrDefault(u => u.UserName == "elowe@scare.net");
			}

			if (newUser40.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser40 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser41 = _context.Users.FirstOrDefault(u => u.Email == "cluce@gogle.com");

			if (newUser41 == null)
			{
				newUser41  = new AppUser();
				newUser41.UserName = "cluce@gogle.com";
				newUser41.Email = "cluce@gogle.com";
				newUser41.PhoneNumber = "5125556919";

				newUser41.FirstName = "Charles";
				newUser41.LastName = "Luce";
				newUser41.Initial = "B";
				newUser41.Birthday = new DateTime(1949, 3, 16);
				newUser41.CustomerNumber = 5020;
				newUser41.Address = "7945 Small Clouds";
				newUser41.City = "Cactus";
				newUser41.State = "TX";
				newUser41.ZipCode = "79013";
				newUser41.PopcornPoints = 160;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser41 , "nothinggreat");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser41.Email);
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
				newUser41  = _context.Users.FirstOrDefault(u => u.UserName == "cluce@gogle.com");
			}

			if (newUser41.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser41 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser42 = _context.Users.FirstOrDefault(u => u.Email == "mackcloud@george.com");

			if (newUser42 == null)
			{
				newUser42  = new AppUser();
				newUser42.UserName = "mackcloud@george.com";
				newUser42.Email = "mackcloud@george.com";
				newUser42.PhoneNumber = "5125553223";

				newUser42.FirstName = "Jackson";
				newUser42.LastName = "MacLeod";
				newUser42.Initial = "D";
				newUser42.Birthday = new DateTime(1947, 2, 21);
				newUser42.CustomerNumber = 5021;
				newUser42.Address = "2804 Near West Blvd.";
				newUser42.City = "Plano";
				newUser42.State = "TX";
				newUser42.ZipCode = "37654";
				newUser42.PopcornPoints = 130;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser42 , "However");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser42.Email);
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
				newUser42  = _context.Users.FirstOrDefault(u => u.UserName == "mackcloud@george.com");
			}

			if (newUser42.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser42 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser43 = _context.Users.FirstOrDefault(u => u.Email == "cmartin@beets.com");

			if (newUser43 == null)
			{
				newUser43  = new AppUser();
				newUser43.UserName = "cmartin@beets.com";
				newUser43.Email = "cmartin@beets.com";
				newUser43.PhoneNumber = "5125554445";

				newUser43.FirstName = "Candice";
				newUser43.LastName = "Markham";
				newUser43.Initial = "P";
				newUser43.Birthday = new DateTime(1972, 3, 20);
				newUser43.CustomerNumber = 5022;
				newUser43.Address = "9761 Bike Chase";
				newUser43.City = "Kissimmee";
				newUser43.State = "FL";
				newUser43.ZipCode = "34741";
				newUser43.PopcornPoints = 200;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser43 , "nobodycares");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser43.Email);
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
				newUser43  = _context.Users.FirstOrDefault(u => u.UserName == "cmartin@beets.com");
			}

			if (newUser43.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser43 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser44 = _context.Users.FirstOrDefault(u => u.Email == "clarence@yoho.com");

			if (newUser44 == null)
			{
				newUser44  = new AppUser();
				newUser44.UserName = "clarence@yoho.com";
				newUser44.Email = "clarence@yoho.com";
				newUser44.PhoneNumber = "5125554447";

				newUser44.FirstName = "Clarence";
				newUser44.LastName = "Martin";
				newUser44.Initial = "A";
				newUser44.Birthday = new DateTime(1992, 7, 19);
				newUser44.CustomerNumber = 5023;
				newUser44.Address = "387 Alcedo St.";
				newUser44.City = "Austin";
				newUser44.State = "TX";
				newUser44.ZipCode = "37709";
				newUser44.PopcornPoints = 230;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser44 , "eggsellent");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser44.Email);
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
				newUser44  = _context.Users.FirstOrDefault(u => u.UserName == "clarence@yoho.com");
			}

			if (newUser44.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser44 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser45 = _context.Users.FirstOrDefault(u => u.Email == "gregmartinez@drdre.com");

			if (newUser45 == null)
			{
				newUser45  = new AppUser();
				newUser45.UserName = "gregmartinez@drdre.com";
				newUser45.Email = "gregmartinez@drdre.com";
				newUser45.PhoneNumber = "5125556666";

				newUser45.FirstName = "Greg";
				newUser45.LastName = "Martinez";
				newUser45.Initial = "R";
				newUser45.Birthday = new DateTime(1947, 5, 28);
				newUser45.CustomerNumber = 5024;
				newUser45.Address = "2495 Sunrise Blvd.";
				newUser45.City = "Red Rock";
				newUser45.State = "TX";
				newUser45.ZipCode = "37662";
				newUser45.PopcornPoints = 70;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser45 , "rainrain");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser45.Email);
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
				newUser45  = _context.Users.FirstOrDefault(u => u.UserName == "gregmartinez@drdre.com");
			}

			if (newUser45.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser45 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser46 = _context.Users.FirstOrDefault(u => u.Email == "cmiller@bob.com");

			if (newUser46 == null)
			{
				newUser46  = new AppUser();
				newUser46.UserName = "cmiller@bob.com";
				newUser46.Email = "cmiller@bob.com";
				newUser46.PhoneNumber = "5125555923";

				newUser46.FirstName = "Charles";
				newUser46.LastName = "Miller";
				newUser46.Initial = "R";
				newUser46.Birthday = new DateTime(1990, 10, 15);
				newUser46.CustomerNumber = 5025;
				newUser46.Address = "897762 Main St.";
				newUser46.City = "South Padre Island";
				newUser46.State = "TX";
				newUser46.ZipCode = "37597";
				newUser46.PopcornPoints = 0;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser46 , "mypuppyspot");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser46.Email);
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
				newUser46  = _context.Users.FirstOrDefault(u => u.UserName == "cmiller@bob.com");
			}

			if (newUser46.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser46 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser47 = _context.Users.FirstOrDefault(u => u.Email == "knelson@aoll.com");

			if (newUser47 == null)
			{
				newUser47  = new AppUser();
				newUser47.UserName = "knelson@aoll.com";
				newUser47.Email = "knelson@aoll.com";
				newUser47.PhoneNumber = "5125557213";

				newUser47.FirstName = "Kelly";
				newUser47.LastName = "Nelson";
				newUser47.Initial = "T";
				newUser47.Birthday = new DateTime(1971, 7, 13);
				newUser47.CustomerNumber = 5026;
				newUser47.Address = "5601 Blue River";
				newUser47.City = "Disney";
				newUser47.State = "OK";
				newUser47.ZipCode = "74340";
				newUser47.PopcornPoints = 10;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser47 , "spotmycat");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser47.Email);
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
				newUser47  = _context.Users.FirstOrDefault(u => u.UserName == "knelson@aoll.com");
			}

			if (newUser47.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser47 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser48 = _context.Users.FirstOrDefault(u => u.Email == "joewin@xfactor.com");

			if (newUser48 == null)
			{
				newUser48  = new AppUser();
				newUser48.UserName = "joewin@xfactor.com";
				newUser48.Email = "joewin@xfactor.com";
				newUser48.PhoneNumber = "5125557774";

				newUser48.FirstName = "Joe";
				newUser48.LastName = "Nguyen";
				newUser48.Initial = "C";
				newUser48.Birthday = new DateTime(1984, 3, 17);
				newUser48.CustomerNumber = 5027;
				newUser48.Address = "8249 54th SW St.";
				newUser48.City = "Del Rio";
				newUser48.State = "TX";
				newUser48.ZipCode = "37841";
				newUser48.PopcornPoints = 30;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser48 , "joejoebob");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser48.Email);
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
				newUser48  = _context.Users.FirstOrDefault(u => u.UserName == "joewin@xfactor.com");
			}

			if (newUser48.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser48 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser49 = _context.Users.FirstOrDefault(u => u.Email == "orielly@foxnews.cnn");

			if (newUser49 == null)
			{
				newUser49  = new AppUser();
				newUser49.UserName = "orielly@foxnews.cnn";
				newUser49.Email = "orielly@foxnews.cnn";
				newUser49.PhoneNumber = "5125551111";

				newUser49.FirstName = "Bill";
				newUser49.LastName = "O'Reilly";
				newUser49.Initial = "T";
				newUser49.Birthday = new DateTime(1959, 7, 8);
				newUser49.CustomerNumber = 5028;
				newUser49.Address = "9870 Gato Drive";
				newUser49.City = "Fort Worth";
				newUser49.State = "TX";
				newUser49.ZipCode = "37746";
				newUser49.PopcornPoints = 120;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser49 , "bobbyboy");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser49.Email);
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
				newUser49  = _context.Users.FirstOrDefault(u => u.UserName == "orielly@foxnews.cnn");
			}

			if (newUser49.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser49 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser50 = _context.Users.FirstOrDefault(u => u.Email == "ankaisrad@gogle.com");

			if (newUser50 == null)
			{
				newUser50  = new AppUser();
				newUser50.UserName = "ankaisrad@gogle.com";
				newUser50.Email = "ankaisrad@gogle.com";
				newUser50.PhoneNumber = "5125555631";

				newUser50.FirstName = "Anka";
				newUser50.LastName = "Radkovich";
				newUser50.Initial = "L";
				newUser50.Birthday = new DateTime(1966, 5, 19);
				newUser50.CustomerNumber = 5029;
				newUser50.Address = "7900 Mark Pl";
				newUser50.City = "Plano";
				newUser50.State = "TX";
				newUser50.ZipCode = "37712";
				newUser50.PopcornPoints = 150;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser50 , "chadgirl");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser50.Email);
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
				newUser50  = _context.Users.FirstOrDefault(u => u.UserName == "ankaisrad@gogle.com");
			}

			if (newUser50.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser50 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser51 = _context.Users.FirstOrDefault(u => u.Email == "megrhodes@freserve.co.uk");

			if (newUser51 == null)
			{
				newUser51  = new AppUser();
				newUser51.UserName = "megrhodes@freserve.co.uk";
				newUser51.Email = "megrhodes@freserve.co.uk";
				newUser51.PhoneNumber = "5125557700";

				newUser51.FirstName = "Megan";
				newUser51.LastName = "Rhodes";
				newUser51.Initial = "C";
				newUser51.Birthday = new DateTime(1965, 3, 12);
				newUser51.CustomerNumber = 5030;
				newUser51.Address = "1187 Carpet Rd.";
				newUser51.City = "Austin";
				newUser51.State = "TX";
				newUser51.ZipCode = "37705";
				newUser51.PopcornPoints = 50;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser51 , "megan55");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser51.Email);
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
				newUser51  = _context.Users.FirstOrDefault(u => u.UserName == "megrhodes@freserve.co.uk");
			}

			if (newUser51.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser51 , "Customer");
			}
			_context.SaveChanges();


			AppUser newUser52 = _context.Users.FirstOrDefault(u => u.Email == "erynrice@aoll.com");

			if (newUser52 == null)
			{
				newUser52  = new AppUser();
				newUser52.UserName = "erynrice@aoll.com";
				newUser52.Email = "erynrice@aoll.com";
				newUser52.PhoneNumber = "5125550006";

				newUser52.FirstName = "Eryn";
				newUser52.LastName = "Rice";
				newUser52.Initial = "M";
				newUser52.Birthday = new DateTime(1975, 4, 28);
				newUser52.CustomerNumber = 5031;
				newUser52.Address = "2205 Rio Pequeno";
				newUser52.City = "Austin";
				newUser52.State = "TX";
				newUser52.ZipCode = "37375";
				newUser52.PopcornPoints = 70;
				IdentityResult result = new IdentityResult();
				try
				{
					result = await _userManager.CreateAsync(newUser52 , "ricearoni");
				}
				catch (Exception ex)
				{
					StringBuilder msg = new StringBuilder ();
					msg.Append("There was an error adding this user with the email");
					msg.Append(newUser52.Email);
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
				newUser52  = _context.Users.FirstOrDefault(u => u.UserName == "erynrice@aoll.com");
			}

			if (newUser52.CustomerNumber > 0)
			{
				await _userManager.AddToRoleAsync(newUser52 , "Customer");
			}
			_context.SaveChanges();


		}
	}
}
