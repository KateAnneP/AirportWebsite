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
    public class LinePlanesController : Controller
    {
        private readonly projektContext _context;

        public LinePlanesController(projektContext context)
        {
            _context = context;
        }

        // GET: LinePlanes
        public async Task<IActionResult> Index()
        {
            var projektContext = _context.LinePlane.Include(l => l.Line).Include(l => l.Plane);
            return View(await projektContext.ToListAsync());
        }

        // GET: LinePlanes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LinePlane == null)
            {
                return NotFound();
            }

            var linePlane = await _context.LinePlane
                .Include(l => l.Line)
                .Include(l => l.Plane)
                .FirstOrDefaultAsync(m => m.LinePlaneID == id);
            if (linePlane == null)
            {
                return NotFound();
            }

            return View(linePlane);
        }

        // GET: LinePlanes/Create
        public IActionResult Create()
        {
            ViewData["LineId"] = new SelectList(_context.Line, "Id", "Name");
            ViewData["PlaneId"] = new SelectList(_context.Set<Plane>(), "Id", "Model");
            return View();
        }

        // POST: LinePlanes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LinePlaneID,LineId,PlaneId")] LinePlane linePlane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(linePlane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LineId"] = new SelectList(_context.Line, "Id", "Name", linePlane.LineId);
            ViewData["PlaneId"] = new SelectList(_context.Set<Plane>(), "Id", "Model", linePlane.PlaneId);
            return View(linePlane);
        }

        // GET: LinePlanes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LinePlane == null)
            {
                return NotFound();
            }

            var linePlane = await _context.LinePlane.FindAsync(id);
            if (linePlane == null)
            {
                return NotFound();
            }
            ViewData["LineId"] = new SelectList(_context.Line, "Id", "Name", linePlane.LineId);
            ViewData["PlaneId"] = new SelectList(_context.Set<Plane>(), "Id", "Model", linePlane.PlaneId);
            return View(linePlane);
        }

        // POST: LinePlanes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LinePlaneID,LineId,PlaneId")] LinePlane linePlane)
        {
            if (id != linePlane.LinePlaneID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linePlane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinePlaneExists(linePlane.LinePlaneID))
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
            ViewData["LineId"] = new SelectList(_context.Line, "Id", "Name", linePlane.LineId);
            ViewData["PlaneId"] = new SelectList(_context.Set<Plane>(), "Id", "Model", linePlane.PlaneId);
            return View(linePlane);
        }

        // GET: LinePlanes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LinePlane == null)
            {
                return NotFound();
            }

            var linePlane = await _context.LinePlane
                .Include(l => l.Line)
                .Include(l => l.Plane)
                .FirstOrDefaultAsync(m => m.LinePlaneID == id);
            if (linePlane == null)
            {
                return NotFound();
            }

            return View(linePlane);
        }

        // POST: LinePlanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LinePlane == null)
            {
                return Problem("Entity set 'projektContext.LinePlane'  is null.");
            }
            var linePlane = await _context.LinePlane.FindAsync(id);
            if (linePlane != null)
            {
                _context.LinePlane.Remove(linePlane);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinePlaneExists(int id)
        {
          return (_context.LinePlane?.Any(e => e.LinePlaneID == id)).GetValueOrDefault();
        }
    }
}
