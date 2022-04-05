using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElektronikaiAlkatreszRaktar.Data;
using ElektronikaiAlkatreszRaktar.Models;
using Microsoft.AspNetCore.Authorization;

namespace ElektronikaiAlkatreszRaktar.Controllers
{
    public class AlkatreszekController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlkatreszekController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alkatreszek
        public async Task<IActionResult> Index(string Megnevezes, string Tipus)
        {
            AlkatreszKeres alkatreszKeres = new AlkatreszKeres();
            alkatreszKeres.Alkatreszek = await _context.Alkatresz.ToListAsync();
            alkatreszKeres.Megnevezesek = new SelectList(await _context.Alkatresz.Select(x => x.Megnevezes).Distinct().ToListAsync());
            alkatreszKeres.Tipusok = new SelectList(await _context.Alkatresz.Select(x => x.Tipus).Distinct().ToListAsync());

            var db = _context.Alkatresz.Select(x => x);

            if (!string.IsNullOrEmpty(Megnevezes))
            {
                db = db.Where(x => x.Megnevezes.Contains(Megnevezes));
            }
            if (!string.IsNullOrEmpty(Tipus))
            {
                db = db.Where(x => x.Tipus.Contains(Tipus));
            }

            alkatreszKeres.Alkatreszek = await db.ToListAsync();

            return View(alkatreszKeres);
        }

        // GET: Alkatreszek/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alkatresz = await _context.Alkatresz
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alkatresz == null)
            {
                return NotFound();
            }

            return View(alkatresz);
        }
        [Authorize]
        // GET: Alkatreszek/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: Alkatreszek/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Megnevezes,Gyarto,Tipus,Beszerzes")] Alkatresz alkatresz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alkatresz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alkatresz);
        }
        [Authorize]
        // GET: Alkatreszek/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alkatresz = await _context.Alkatresz.FindAsync(id);
            if (alkatresz == null)
            {
                return NotFound();
            }
            return View(alkatresz);
        }
        [Authorize]
        // POST: Alkatreszek/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Megnevezes,Gyarto,Tipus,Beszerzes")] Alkatresz alkatresz)
        {
            if (id != alkatresz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alkatresz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlkatreszExists(alkatresz.Id))
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
            return View(alkatresz);
        }
        [Authorize]
        // GET: Alkatreszek/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alkatresz = await _context.Alkatresz
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alkatresz == null)
            {
                return NotFound();
            }

            return View(alkatresz);
        }
        [Authorize]
        // POST: Alkatreszek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alkatresz = await _context.Alkatresz.FindAsync(id);
            _context.Alkatresz.Remove(alkatresz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlkatreszExists(int id)
        {
            return _context.Alkatresz.Any(e => e.Id == id);
        }
    }
}
