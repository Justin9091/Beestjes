using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beestjes.Models;

namespace Beestjes.Controllers
{
    public class BeestjesController : Controller
    {
        private BeestjesContext _context;

        public BeestjesController(BeestjesContext context)
        {
            _context = context;
        }

        // GET: Beestjes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Beestje.ToListAsync());
        }

        // GET: Beestjes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beestje = await _context.Beestje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beestje == null)
            {
                return NotFound();
            }

            return View(beestje);
        }

        // GET: Beestjes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beestjes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Price,Image")] Beestje beestje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beestje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beestje);
        }

        // GET: Beestjes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beestje = await _context.Beestje.FindAsync(id);
            if (beestje == null)
            {
                return NotFound();
            }
            return View(beestje);
        }

        // POST: Beestjes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Price,Image")] Beestje beestje)
        {
            if (id != beestje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beestje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeestjeExists(beestje.Id))
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
            return View(beestje);
        }

        // GET: Beestjes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beestje = await _context.Beestje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beestje == null)
            {
                return NotFound();
            }

            return View(beestje);
        }

        // POST: Beestjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beestje = await _context.Beestje.FindAsync(id);
            if (beestje != null)
            {
                _context.Beestje.Remove(beestje);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeestjeExists(int id)
        {
            return _context.Beestje.Any(e => e.Id == id);
        }
    }
}
