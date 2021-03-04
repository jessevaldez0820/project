using Microsoft.EntityFrameworkCore;
using System;

//TODO: Update this using statement to include your project name
using Group25_Final_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;

//TODO: Make this namespace match your project name
namespace Group25_Final_Project.DAL
{
    //NOTE: This class definition references the user class for this project.  
    //If your User class is called something other than AppUser, you will need
    //to change it in the line below

    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //TODO: Add Dbsets here.  Products is included as an example.
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Order>Orders { get; set; }

        public DbSet<Showing> Showings { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Price> Prices { get; set; }

        public DbSet<Group25_Final_Project.Models.Schedule> Schedule { get; set; }

        
    }
}
