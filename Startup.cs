using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

//: Make these using statements match your project
using Group25_Final_Project.Models;
using Group25_Final_Project.DAL;


//: Make this namespace match your project - be sure to remove the []
namespace Group25_Final_Project
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //This adds the MVC engine and Razor code
            services.AddControllersWithViews();

            //: (For HW4 and beyond) Add a connection string here once you have created it on Azure
            //This is the official(OG) connection string to group25 final project databse!
            //Uncomment this one to access OG database
            //String connectionString = "Server=tcp:fa20group25finalproject.database.windows.net,1433;Initial Catalog=fa20Group25FinalProject;Persist Security Info=False;User ID=MISAdmin;Password=Hunnits!;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


            //This is the unofficial/fake datavase (NON-OG) for the testing database!!
            String connectionString = "Server=tcp:group25testing.database.windows.net,1433;Initial Catalog=group25testing;Persist Security Info=False;User ID=Misadmin;Password=Hunnits!;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


            //: Uncomment this line once you have your connection string
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            //: Uncomment these lines once you have added Identity to your project
            ////NOTE: This is where you would change your password requirements
            services.AddIdentity<AppUser, IdentityRole>(opts => {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        }

        public void Configure(IApplicationBuilder app, IServiceProvider service)
        {
            //These lines allow you to see more detailed error messages
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();

            //This line allows you to use static pages like style sheets and images
            app.UseStaticFiles();

            //This marks the position in the middleware pipeline where a routing decision
            //is made for a URL.
            app.UseRouting();

            //This allows the data annotations for currency to work on a mac
            app.Use(async (context, next) =>
            {
                CultureInfo.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
                CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture;

                await next.Invoke();
            });

            //: Once you have added Identity into your project, you will need to uncomment these lines
            app.UseAuthentication();
            app.UseAuthorization();

            //This method maps the controllers and their actions to a patter for
            //requests that's known as the default route. This route identifies
            //the Home controller as the default controller and the Index() action
            //method as the default action. The default route also identifies a 
            //third segment of the URL that's a parameter named id.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //: Uncomment this after admin is seeded
            //This seeds the admin user
            //Seeding.SeedEmployees.AddEmployee(service).Wait();
            //Seeding.SeedCustomers.AddCustomer(service).Wait();
        }
    }
}