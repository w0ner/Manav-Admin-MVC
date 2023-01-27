using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using manav.Data;
using manav.Models;
using manav.ViewModel;

namespace manav.Controllers
{
    public class MeyveController : Controller
    {
        private readonly ManavDBContext _context;

        public MeyveController(ManavDBContext context)
        {
            _context = context;
        }

        // GET: Meyve
        public async Task<IActionResult> Liste()
        {
            return View(await _context.Meyveler.Include(a=>a.Renk).Include(a => a.Kategori).OrderByDescending(a=>a.MeyveID).ToListAsync());
        }

        // GET: Meyve/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Meyveler == null)
            {
                return NotFound();
            }

            var meyve = await _context.Meyveler
                .FirstOrDefaultAsync(m => m.MeyveID == id);
            if (meyve == null)
            {
                return NotFound();
            }

            return View(meyve);
        }

        // GET: Meyve/Create
        public IActionResult Ekle()
        {
            MeyveEkleViewModel x= new MeyveEkleViewModel();
            x.RenkListesi= _context.Renkler.ToList();
            x.KategoriListesi= _context.Kategoriler.ToList();

            return View(x);
        }

        // POST: Meyve/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle([Bind("MeyveID,MeyveAdı,KategoriID,RenkID")] Meyve meyve)
        {

            _context.Meyveler.Add(meyve);
            await _context.SaveChangesAsync();
            return RedirectToAction("Liste","Meyve");

        }

        // GET: Meyve/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Meyveler == null)
            {
                return NotFound();
            }

            var meyve = await _context.Meyveler.FindAsync(id);
            if (meyve == null)
            {
                return NotFound();
            }
            return View(meyve);
        }

        // POST: Meyve/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MeyveID,MeyveAdı")] Meyve meyve)
        {
            if (id != meyve.MeyveID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meyve);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeyveExists(meyve.MeyveID))
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
            return View(meyve);
        }

        // GET: Meyve/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Meyveler == null)
            {
                return NotFound();
            }

            var meyve = await _context.Meyveler
                .FirstOrDefaultAsync(m => m.MeyveID == id);
            if (meyve == null)
            {
                return NotFound();
            }

            return View(meyve);
        }

        // POST: Meyve/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Meyveler == null)
            {
                return Problem("Entity set 'ManavDBContext.Meyveler'  is null.");
            }
            var meyve = await _context.Meyveler.FindAsync(id);
            if (meyve != null)
            {
                _context.Meyveler.Remove(meyve);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeyveExists(int id)
        {
            return _context.Meyveler.Any(e => e.MeyveID == id);
        }
    }
}
