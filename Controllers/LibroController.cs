using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppResenas.Context;
using AppResenas.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;

namespace AppResenas.Controllers
{
    public class LibroController : Controller
    {
        private readonly ResenasDataBaseContext _context;

        public LibroController(ResenasDataBaseContext context)
        {
            _context = context;
        }

        // GET: Libro
        public async Task<IActionResult> Index()
        {
            return View(await _context.libros.ToListAsync());
        }

        // GET: Libro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.libros
                .FirstOrDefaultAsync(m => m.id == id);

            var resena = await _context.resenas
                .FirstOrDefaultAsync(m => m.id == id);

            ViewBag.resena = resena;

            string puntaje = "--";
            double puntajeD = 0;

            if(resena.votos != 0)
            {
                puntajeD = (resena.puntajeAcum / resena.votos);
                puntaje = puntajeD.ToString();
            }
           

            ViewBag.puntaje = puntaje;

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libro/Create
        public IActionResult Create()
        {
            //COPIAR TAL CUAL ACA Y EN LA VISTA
            List<Autor> lAutores = new List<Autor>();
            lAutores = _context.autores.ToList();
            ViewBag.listaAutores = lAutores;
            return View();
        }

        // POST: Libro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,titulo,isbn,autor")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                libro.resena = new Resena(libro.id, ViewBag.resenaTexto);
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // GET: Libro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewBag.libroId =  id;
            return View(libro);
        }

        // POST: Libro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,titulo,isbn")] Libro libro)
        {
            if (id != libro.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.id))
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
            return View(libro);
        }

        // GET: Libro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.libros
                .FirstOrDefaultAsync(m => m.id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.libros.FindAsync(id);
            _context.libros.Remove(libro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return _context.libros.Any(e => e.id == id);
        }
    }
}
