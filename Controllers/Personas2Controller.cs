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
    public class Personas2Controller : Controller
    {
        private readonly MiBaseDeDatosContext _miDb;

        public Personas2Controller(MiBaseDeDatosContext context)
        {
            _miDb = context;
        }

        // GET: Personas
        public IActionResult Index()
        {
              return View(_miDb.Personas.ToList());
        }

        // GET: Personas2/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _miDb.Personas == null)
            {
                return NotFound();
            }

            var persona = _miDb.Personas.FirstOrDefault(persona => persona.Id == id);

            if(persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Personas2/Create Oferta de Formulario
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personas2/Create Procesa la info.        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,DNI,Foto")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _miDb.Add(persona);
                await _miDb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: Personas2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _miDb.Personas == null)
            {
                return NotFound();
            }

            var persona = await _miDb.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        // POST: Personas2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,DNI,Foto")] Persona persona)
        {
            if (id != persona.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _miDb.Update(persona);
                    await _miDb.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.Id))
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
            return View(persona);
        }

        // GET: Personas2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _miDb.Personas == null)
            {
                return NotFound();
            }

            var persona = await _miDb.Personas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personas2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_miDb.Personas == null)
            {
                return Problem("Entity set 'MiBaseDeDatosContext.Personas'  is null.");
            }
            var persona = await _miDb.Personas.FindAsync(id);
            if (persona != null)
            {
                _miDb.Personas.Remove(persona);
            }
            
            await _miDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(int id)
        {
          return _miDb.Personas.Any(e => e.Id == id);
        }
    }
}
