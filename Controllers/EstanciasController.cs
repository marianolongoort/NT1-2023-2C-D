using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NT1_2023_2C_D.Data;
using NT1_2023_2C_D.Models;

namespace NT1_2023_2C_D.Controllers
{
    public class EstanciasController : Controller
    {
        private readonly GarageContext _context;

        public EstanciasController(GarageContext context)
        {
            _context = context;
        }

        // GET: Estancias
        public async Task<IActionResult> Index()
        {
              return View(await _context.Estancias.ToListAsync());
        }

        // GET: Estancias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estancias == null)
            {
                return NotFound();
            }

            var estancia = await _context.Estancias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estancia == null)
            {
                return NotFound();
            }

            return View(estancia);
        }

        // GET: Estancias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estancias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Monto,Inicio,Fin")] Estancia estancia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estancia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estancia);
        }

        // GET: Estancias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estancias == null)
            {
                return NotFound();
            }

            var estancia = await _context.Estancias.FindAsync(id);
            if (estancia == null)
            {
                return NotFound();
            }
            return View(estancia);
        }

        // POST: Estancias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Monto,Inicio,Fin")] Estancia estancia)
        {
            if (id != estancia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estancia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstanciaExists(estancia.Id))
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
            return View(estancia);
        }

        // GET: Estancias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estancias == null)
            {
                return NotFound();
            }

            var estancia = await _context.Estancias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estancia == null)
            {
                return NotFound();
            }

            return View(estancia);
        }

        // POST: Estancias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estancias == null)
            {
                return Problem("Entity set 'GarageContext.Estancias'  is null.");
            }
            var estancia = await _context.Estancias.FindAsync(id);
            if (estancia != null)
            {
                _context.Estancias.Remove(estancia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstanciaExists(int id)
        {
          return _context.Estancias.Any(e => e.Id == id);
        }
    }
}
