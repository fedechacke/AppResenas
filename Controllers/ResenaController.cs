using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppResenas.Context;
using AppResenas.Models;

namespace AppResenas.Controllers
{
    public class ResenaController : Controller
    {
        private readonly ResenasDataBaseContext _context;

        public ResenaController(ResenasDataBaseContext context)
        {
            _context = context;
        }

        // GET: Resena
        public async Task<IActionResult> Index()
        {
            return View(await _context.resenas.ToListAsync());
        }

        // GET: Resena/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resena = await _context.resenas
                .FirstOrDefaultAsync(m => m.id == id);
            if (resena == null)
            {
                return RedirectToAction(nameof(Create));
            }

            return View(resena);
        }

        // GET: Resena/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resena/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,titulo,texto,tituloLibro,puntaje")] Resena resena)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resena);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resena);
        }

        // GET: Resena/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resena = await _context.resenas.FindAsync(id);
            if (resena == null)
            {
                return NotFound();
            }
            return View(resena);
        }

        // POST: Resena/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,titulo,texto,tituloLibro,puntaje")] Resena resena)
        {
            if (id != resena.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resena);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResenaExists(resena.id))
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
            return View(resena);
        }

        // GET: Resena/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resena = await _context.resenas
                .FirstOrDefaultAsync(m => m.id == id);
            if (resena == null)
            {
                return NotFound();
            }

            return View(resena);
        }

        // POST: Resena/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resena = await _context.resenas.FindAsync(id);
            _context.resenas.Remove(resena);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResenaExists(int id)
        {
            return _context.resenas.Any(e => e.id == id);
        }
    }
}
