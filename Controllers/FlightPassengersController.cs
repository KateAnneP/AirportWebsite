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
    public class FlightPassengersController : Controller
    {
        private readonly projektContext _context;

        public FlightPassengersController(projektContext context)
        {
            _context = context;
        }

        // GET: FlightPassengers
        public async Task<IActionResult> Index()
        {
            var projektContext = _context.FlightPassenger.Include(f => f.Flight).Include(f => f.Passenger);
            return View(await projektContext.ToListAsync());
        }

        // GET: FlightPassengers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FlightPassenger == null)
            {
                return NotFound();
            }

            var flightPassenger = await _context.FlightPassenger
                .Include(f => f.Flight)
                .Include(f => f.Passenger)
                .FirstOrDefaultAsync(m => m.FlightPassengerID == id);
            if (flightPassenger == null)
            {
                return NotFound();
            }

            return View(flightPassenger);
        }

        // GET: FlightPassengers/Create
        public IActionResult Create()
        {
            ViewData["FlightId"] = new SelectList(_context.Flight, "Id", "Number");
            ViewData["PassengerId"] = new SelectList(_context.Set<Passenger>(), "Id", "LastName");
            return View();
        }

        // POST: FlightPassengers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightPassengerID,PassengerId,FlightId")] FlightPassenger flightPassenger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flightPassenger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlightId"] = new SelectList(_context.Flight, "Id", "Number", flightPassenger.FlightId);
            ViewData["PassengerId"] = new SelectList(_context.Set<Passenger>(), "Id", "Citizenship", flightPassenger.PassengerId);
            return View(flightPassenger);
        }

        // GET: FlightPassengers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FlightPassenger == null)
            {
                return NotFound();
            }

            var flightPassenger = await _context.FlightPassenger.FindAsync(id);
            if (flightPassenger == null)
            {
                return NotFound();
            }
            ViewData["FlightId"] = new SelectList(_context.Flight, "Id", "Number", flightPassenger.FlightId);
            ViewData["PassengerId"] = new SelectList(_context.Set<Passenger>(), "Id", "Citizenship", flightPassenger.PassengerId);
            return View(flightPassenger);
        }

        // POST: FlightPassengers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightPassengerID,PassengerId,FlightId")] FlightPassenger flightPassenger)
        {
            if (id != flightPassenger.FlightPassengerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flightPassenger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightPassengerExists(flightPassenger.FlightPassengerID))
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
            ViewData["FlightId"] = new SelectList(_context.Flight, "Id", "Number", flightPassenger.FlightId);
            ViewData["PassengerId"] = new SelectList(_context.Set<Passenger>(), "Id", "Citizenship", flightPassenger.PassengerId);
            return View(flightPassenger);
        }

        // GET: FlightPassengers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FlightPassenger == null)
            {
                return NotFound();
            }

            var flightPassenger = await _context.FlightPassenger
                .Include(f => f.Flight)
                .Include(f => f.Passenger)
                .FirstOrDefaultAsync(m => m.FlightPassengerID == id);
            if (flightPassenger == null)
            {
                return NotFound();
            }

            return View(flightPassenger);
        }

        // POST: FlightPassengers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FlightPassenger == null)
            {
                return Problem("Entity set 'projektContext.FlightPassenger'  is null.");
            }
            var flightPassenger = await _context.FlightPassenger.FindAsync(id);
            if (flightPassenger != null)
            {
                _context.FlightPassenger.Remove(flightPassenger);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightPassengerExists(int id)
        {
          return (_context.FlightPassenger?.Any(e => e.FlightPassengerID == id)).GetValueOrDefault();
        }
    }
}
