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
    public class ProgresController : Controller
    {
        private readonly FrameworksContext _context;

        public ProgresController(FrameworksContext context)
        {
            _context = context;
        }

        // GET: Progres
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Progres.Where(p =>p .Deleted > DateTime.Now).Include(p => p.Route);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Progres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var progres = await _context.Progres
                .Include(p => p.Route)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (progres == null)
            {
                return NotFound();
            }

            return View(progres);
        }

        // GET: Progres/Create
        public IActionResult Create()
        {
            ViewData["RouteId"] = new SelectList(_context.Routes, "Id", "Id");
            return View();
        }

        // POST: Progres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RouteId,FrameworksUserId,Comment,Completed,DateTime,Deleted")] Progres progres)
        {
            //if (ModelState.IsValid)
            //{
                progres.Completed = true;
                progres.DateTime = DateTime.Now;
                _context.Add(progres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           // }
            ViewData["RouteId"] = new SelectList(_context.Routes, "Id", "Id", progres.RouteId);
            return View(progres);
        }

        // GET: Progres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var progres = await _context.Progres.FindAsync(id);
            if (progres == null)
            {
                return NotFound();
            }
            ViewData["RouteId"] = new SelectList(_context.Routes, "Id", "Id", progres.RouteId);
            return View(progres);
        }

        // POST: Progres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RouteId,FrameworksUserId,Comment,Completed,DateTime,Deleted")] Progres progres)
        {
            if (id != progres.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(progres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgresExists(progres.Id))
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
            ViewData["RouteId"] = new SelectList(_context.Routes, "Id", "Id", progres.RouteId);
            return View(progres);
        }

        // GET: Progres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var progres = await _context.Progres
                .Include(p => p.Route)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (progres == null)
            {
                return NotFound();
            }

            return View(progres);
        }

        // POST: Progres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var progres = await _context.Progres.FindAsync(id);
            if (progres != null)
            {
                progres.Deleted = DateTime.Now;
                _context.Progres.Update(progres);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgresExists(int id)
        {
            return _context.Progres.Any(e => e.Id == id);
        }
    }
}
