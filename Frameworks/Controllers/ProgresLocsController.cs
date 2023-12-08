using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Frameworks.Data;
using Frameworks.Models;

namespace Frameworks.Controllers
{
    public class ProgresLocsController : Controller
    {
        private readonly FrameworksContext _context;

        public ProgresLocsController(FrameworksContext context)
        {
            _context = context;
        }

        // GET: ProgresLocs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProgresLocs.Where(p => p.Deleted > DateTime.Now).Include(p => p.Locations);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProgresLocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var progresLoc = await _context.ProgresLocs
                .Include(p => p.Locations)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (progresLoc == null)
            {
                return NotFound();
            }

            return View(progresLoc);
        }

        // GET: ProgresLocs/Create
        public IActionResult Create()
        {
            ViewData["LocationsId"] = new SelectList(_context.Locations, "Id", "Id");
            return View();
        }

        // POST: ProgresLocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LocationsId,FrameworksUserId,Comment,Completed,DateTime,Deleted")] ProgresLoc progresLoc)
        {
            // if (ModelState.IsValid)
            // {
                progresLoc.Completed = true;
                progresLoc.DateTime = DateTime.Now;
                _context.Add(progresLoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           // }
            ViewData["LocationsId"] = new SelectList(_context.Locations, "Id", "Id", progresLoc.LocationsId);
            return View(progresLoc);
        }

        // GET: ProgresLocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var progresLoc = await _context.ProgresLocs.FindAsync(id);
            if (progresLoc == null)
            {
                return NotFound();
            }
            ViewData["LocationsId"] = new SelectList(_context.Locations, "Id", "Id", progresLoc.LocationsId);
            return View(progresLoc);
        }

        // POST: ProgresLocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LocationsId,FrameworksUserId,Comment,Completed,DateTime,Deleted")] ProgresLoc progresLoc)
        {
            if (id != progresLoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(progresLoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgresLocExists(progresLoc.Id))
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
            ViewData["LocationsId"] = new SelectList(_context.Locations, "Id", "Id", progresLoc.LocationsId);
            return View(progresLoc);
        }

        // GET: ProgresLocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var progresLoc = await _context.ProgresLocs
                .Include(p => p.Locations)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (progresLoc == null)
            {
                return NotFound();
            }

            return View(progresLoc);
        }

        // POST: ProgresLocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var progresLoc = await _context.ProgresLocs.FindAsync(id);
            if (progresLoc != null)
            {
                progresLoc.Deleted = DateTime.Now;
                _context.ProgresLocs.Update(progresLoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgresLocExists(int id)
        {
            return _context.ProgresLocs.Any(e => e.Id == id);
        }
    }
}
