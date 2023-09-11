using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NaukaMVC.Entities;

namespace NaukaMVC.Controllers
{
    public class KsiazkaController : Controller
    {
        private readonly BibliotekaDbContext _context;

        public KsiazkaController(BibliotekaDbContext context)
        {
            _context = context;
        }

        // GET: Ksiazka
        public async Task<IActionResult> Index()
        {
              return _context.Ksiazki != null ? 
                          View(await _context.Ksiazki.ToListAsync()) :
                          Problem("Entity set 'BibliotekaDbContext.Ksiazki'  is null.");
        }

        // GET: Ksiazka/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ksiazki == null)
            {
                return NotFound();
            }

            var ksiazkaEntity = await _context.Ksiazki
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ksiazkaEntity == null)
            {
                return NotFound();
            }

            return View(ksiazkaEntity);
        }

        // GET: Ksiazka/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ksiazka/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Tytul,Autor,Opis,Strony,RokWydania")] KsiazkaEntity ksiazkaEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ksiazkaEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ksiazkaEntity);
        }

        // GET: Ksiazka/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ksiazki == null)
            {
                return NotFound();
            }

            var ksiazkaEntity = await _context.Ksiazki.FindAsync(id);
            if (ksiazkaEntity == null)
            {
                return NotFound();
            }
            return View(ksiazkaEntity);
        }

        // POST: Ksiazka/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tytul,Autor,Opis,Strony,RokWydania")] KsiazkaEntity ksiazkaEntity)
        {
            if (id != ksiazkaEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ksiazkaEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KsiazkaEntityExists(ksiazkaEntity.Id))
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
            return View(ksiazkaEntity);
        }

        // GET: Ksiazka/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ksiazki == null)
            {
                return NotFound();
            }

            var ksiazkaEntity = await _context.Ksiazki
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ksiazkaEntity == null)
            {
                return NotFound();
            }

            return View(ksiazkaEntity);
        }

        // POST: Ksiazka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ksiazki == null)
            {
                return Problem("Entity set 'BibliotekaDbContext.Ksiazki'  is null.");
            }
            var ksiazkaEntity = await _context.Ksiazki.FindAsync(id);
            if (ksiazkaEntity != null)
            {
                _context.Ksiazki.Remove(ksiazkaEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KsiazkaEntityExists(int id)
        {
          return (_context.Ksiazki?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
