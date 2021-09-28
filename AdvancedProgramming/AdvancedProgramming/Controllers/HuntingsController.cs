using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvancedProgramming.Data;
using AdvancedProgramming.Models;

namespace AdvancedProgramming.Controllers
{
    public class HuntingsController : Controller
    {
        private readonly MvcMovieContext _context;

        public HuntingsController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Huntings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hunting.ToListAsync());
        }

        // GET: Huntings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hunting = await _context.Hunting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hunting == null)
            {
                return NotFound();
            }

            return View(hunting);
        }

        // GET: Huntings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Huntings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Place,Date,HarvestedMeat,Note")] Hunting hunting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hunting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hunting);
        }

        // GET: Huntings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hunting = await _context.Hunting.FindAsync(id);
            if (hunting == null)
            {
                return NotFound();
            }
            return View(hunting);
        }

        // POST: Huntings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Place,Date,HarvestedMeat,Note")] Hunting hunting)
        {
            if (id != hunting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hunting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HuntingExists(hunting.Id))
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
            return View(hunting);
        }

        // GET: Huntings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hunting = await _context.Hunting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hunting == null)
            {
                return NotFound();
            }

            return View(hunting);
        }

        // POST: Huntings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hunting = await _context.Hunting.FindAsync(id);
            _context.Hunting.Remove(hunting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HuntingExists(int id)
        {
            return _context.Hunting.Any(e => e.Id == id);
        }
    }
}
