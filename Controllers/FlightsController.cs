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
    public class FlightsController : Controller
    {
        private readonly projektContext _context;

        public FlightsController(projektContext context)
        {
            _context = context;
        }

        // GET: Flights
        public async Task<IActionResult> Index()
        {
            var projektContext = _context.Flight.Include(f => f.Destination).Include(f => f.Line).Include(f => f.Plane).Include(f => f.Status).Include(f => f.Terminal);
            return View(await projektContext.ToListAsync());
        }

        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Flight == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight
                .Include(f => f.Destination)
                .Include(f => f.Line)
                .Include(f => f.Plane)
                .Include(f => f.Status)
                .Include(f => f.Terminal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            ViewData["DestinationID"] = new SelectList(_context.Destination, "Id", "City");
            ViewData["LineID"] = new SelectList(_context.Set<Line>(), "Id", "Name");
            ViewData["PlaneID"] = new SelectList(_context.Set<Plane>(), "Id", "Model");
            ViewData["StatusID"] = new SelectList(_context.Set<Status>(), "Id", "Description");
            ViewData["TerminalID"] = new SelectList(_context.Set<Terminal>(), "Id", "Description");
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,DateAndTime,LineID,StatusID,TerminalID,PlaneID,DestinationID")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinationID"] = new SelectList(_context.Destination, "Id", "City", flight.DestinationID);
            ViewData["LineID"] = new SelectList(_context.Set<Line>(), "Id", "Name", flight.LineID);
            ViewData["PlaneID"] = new SelectList(_context.Set<Plane>(), "Id", "Model", flight.PlaneID);
            ViewData["StatusID"] = new SelectList(_context.Set<Status>(), "Id", "Description", flight.StatusID);
            ViewData["TerminalID"] = new SelectList(_context.Set<Terminal>(), "Id", "Description", flight.TerminalID);
            return View(flight);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Flight == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            ViewData["DestinationID"] = new SelectList(_context.Destination, "Id", "City", flight.DestinationID);
            ViewData["LineID"] = new SelectList(_context.Set<Line>(), "Id", "Name", flight.LineID);
            ViewData["PlaneID"] = new SelectList(_context.Set<Plane>(), "Id", "Model", flight.PlaneID);
            ViewData["StatusID"] = new SelectList(_context.Set<Status>(), "Id", "Description", flight.StatusID);
            ViewData["TerminalID"] = new SelectList(_context.Set<Terminal>(), "Id", "Description", flight.TerminalID);
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,DateAndTime,LineID,StatusID,TerminalID,PlaneID,DestinationID")] Flight flight)
        {
            if (id != flight.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.Id))
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
            ViewData["DestinationID"] = new SelectList(_context.Destination, "Id", "City", flight.DestinationID);
            ViewData["LineID"] = new SelectList(_context.Set<Line>(), "Id", "Name", flight.LineID);
            ViewData["PlaneID"] = new SelectList(_context.Set<Plane>(), "Id", "Model", flight.PlaneID);
            ViewData["StatusID"] = new SelectList(_context.Set<Status>(), "Id", "Description", flight.StatusID);
            ViewData["TerminalID"] = new SelectList(_context.Set<Terminal>(), "Id", "Description", flight.TerminalID);
            return View(flight);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Flight == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight
                .Include(f => f.Destination)
                .Include(f => f.Line)
                .Include(f => f.Plane)
                .Include(f => f.Status)
                .Include(f => f.Terminal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Flight == null)
            {
                return Problem("Entity set 'projektContext.Flight'  is null.");
            }
            var flight = await _context.Flight.FindAsync(id);
            if (flight != null)
            {
                _context.Flight.Remove(flight);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(int id)
        {
          return (_context.Flight?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
