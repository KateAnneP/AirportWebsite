using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projekt.Data;
using projekt.Models;

namespace projekt.Controllers
{
    public class FlightStaffsController : Controller
    {
        private readonly projektContext _context;

        public FlightStaffsController(projektContext context)
        {
            _context = context;
        }

        // GET: FlightStaffs
        public async Task<IActionResult> Index()
        {
            var projektContext = _context.FlightStaff.Include(f => f.Flight).Include(f => f.Staff);
            return View(await projektContext.ToListAsync());
        }

        // GET: FlightStaffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FlightStaff == null)
            {
                return NotFound();
            }

            var flightStaff = await _context.FlightStaff
                .Include(f => f.Flight)
                .Include(f => f.Staff)
                .FirstOrDefaultAsync(m => m.FlightStaffID == id);
            if (flightStaff == null)
            {
                return NotFound();
            }

            return View(flightStaff);
        }

        // GET: FlightStaffs/Create
        public IActionResult Create()
        {
            ViewData["FlightId"] = new SelectList(_context.Flight, "Id", "Number");
            ViewData["StaffId"] = new SelectList(_context.Set<Staff>(), "Id", "FirstName");
            return View();
        }

        // POST: FlightStaffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightStaffID,FlightId,StaffId")] FlightStaff flightStaff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flightStaff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlightId"] = new SelectList(_context.Flight, "Id", "Number", flightStaff.FlightId);
            ViewData["StaffId"] = new SelectList(_context.Set<Staff>(), "Id", "FirstName", flightStaff.StaffId);
            return View(flightStaff);
        }

        // GET: FlightStaffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FlightStaff == null)
            {
                return NotFound();
            }

            var flightStaff = await _context.FlightStaff.FindAsync(id);
            if (flightStaff == null)
            {
                return NotFound();
            }
            ViewData["FlightId"] = new SelectList(_context.Flight, "Id", "Number", flightStaff.FlightId);
            ViewData["StaffId"] = new SelectList(_context.Set<Staff>(), "Id", "FirstName", flightStaff.StaffId);
            return View(flightStaff);
        }

        // POST: FlightStaffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightStaffID,FlightId,StaffId")] FlightStaff flightStaff)
        {
            if (id != flightStaff.FlightStaffID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flightStaff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightStaffExists(flightStaff.FlightStaffID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlightId"] = new SelectList(_context.Flight, "Id", "Number", flightStaff.FlightId);
            ViewData["StaffId"] = new SelectList(_context.Set<Staff>(), "Id", "FirstName", flightStaff.StaffId);
            return View(flightStaff);
        }

        // GET: FlightStaffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FlightStaff == null)
            {
                return NotFound();
            }

            var flightStaff = await _context.FlightStaff
                .Include(f => f.Flight)
                .Include(f => f.Staff)
                .FirstOrDefaultAsync(m => m.FlightStaffID == id);
            if (flightStaff == null)
            {
                return NotFound();
            }

            return View(flightStaff);
        }

        // POST: FlightStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FlightStaff == null)
            {
                return Problem("Entity set 'projektContext.FlightStaff'  is null.");
            }
            var flightStaff = await _context.FlightStaff.FindAsync(id);
            if (flightStaff != null)
            {
                _context.FlightStaff.Remove(flightStaff);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightStaffExists(int id)
        {
          return (_context.FlightStaff?.Any(e => e.FlightStaffID == id)).GetValueOrDefault();
        }
    }
}
