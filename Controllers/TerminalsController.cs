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
    public class TerminalsController : Controller
    {
        private readonly projektContext _context;

        public TerminalsController(projektContext context)
        {
            _context = context;
        }

        // GET: Terminals
        public async Task<IActionResult> Index()
        {
              return _context.Terminal != null ? 
                          View(await _context.Terminal.ToListAsync()) :
                          Problem("Entity set 'projektContext.Terminal'  is null.");
        }

        // GET: Terminals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Terminal == null)
            {
                return NotFound();
            }

            var terminal = await _context.Terminal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (terminal == null)
            {
                return NotFound();
            }

            return View(terminal);
        }

        // GET: Terminals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Terminals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] Terminal terminal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(terminal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(terminal);
        }

        // GET: Terminals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Terminal == null)
            {
                return NotFound();
            }

            var terminal = await _context.Terminal.FindAsync(id);
            if (terminal == null)
            {
                return NotFound();
            }
            return View(terminal);
        }

        // POST: Terminals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] Terminal terminal)
        {
            if (id != terminal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(terminal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerminalExists(terminal.Id))
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
            return View(terminal);
        }

        // GET: Terminals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Terminal == null)
            {
                return NotFound();
            }

            var terminal = await _context.Terminal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (terminal == null)
            {
                return NotFound();
            }

            return View(terminal);
        }

        // POST: Terminals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Terminal == null)
            {
                return Problem("Entity set 'projektContext.Terminal'  is null.");
            }
            var terminal = await _context.Terminal.FindAsync(id);
            if (terminal != null)
            {
                _context.Terminal.Remove(terminal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TerminalExists(int id)
        {
          return (_context.Terminal?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
