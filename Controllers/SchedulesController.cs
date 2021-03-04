using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Group25_Final_Project.DAL;
using Group25_Final_Project.Models;
using Microsoft.AspNetCore.Authorization;

namespace Group25_Final_Project.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly AppDbContext _context;

        public SchedulesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            return View(await _context.Schedule.ToListAsync());
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .FirstOrDefaultAsync(m => m.ScheduleID == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        [Authorize(Roles = "Manager")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create([Bind("ScheduleID,Status,StartDate,EndDate")] Schedule schedule)
        {


            if (ModelState.IsValid == false)
            {

                return View(schedule);
            }
            _context.Add(schedule);
                await _context.SaveChangesAsync();
            return RedirectToAction("Create", "Showings", new { scheduleID = schedule.ScheduleID });
        }

        // GET: Schedules/Edit/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Please specify a order to edit" });
            }

            Schedule schedule = await _context.Schedule
                .Include(r => r.Showings)
                .ThenInclude(r => r.Movie)
                                             // .Include(r => r.AppUser)
                .FirstOrDefaultAsync(m => m.ScheduleID == id);

            if (schedule == null)
            {
                return View("Error", new String[] { "This schedule was not found in the database!" });
            }
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int id, [Bind("ScheduleID,Status,StartDate,EndDate")] Schedule schedule)
        {
            if (id != schedule.ScheduleID)
            {
                return View("Error", new String[] { "There was a problem editing this schedule. Try again!" });
            }

            if (ModelState.IsValid == false)
            {
                return View(schedule);
            }
            try
            {
                //find the record in the database
                Schedule dbSchedule = _context.Schedule.Find(schedule.ScheduleID);

                //update the notes
                dbSchedule.StartDate = schedule.StartDate;
                dbSchedule.EndDate = schedule.EndDate;
                //dbSchedule.Status

                _context.Update(dbSchedule);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return View("Error", new String[] { "There was an error updating this schedule!", ex.Message });
            }

            
            return RedirectToAction(nameof(Index));
            }
            
        }

        
    /*
        private bool ScheduleExists(int id)
        {
            return _context.Schedule.Any(e => e.ScheduleID == id);
        }
    */
    
}
