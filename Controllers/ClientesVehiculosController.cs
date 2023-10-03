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
    public class ClientesVehiculosController : Controller
    {
        private readonly GarageContext _context;

        public ClientesVehiculosController(GarageContext context)
        {
            _context = context;
        }

        // GET: ClientesVehiculos
        public async Task<IActionResult> Index()
        {
            var miBaseDeDatosContext = _context.ClienteVehiculos.Include(c => c.Cliente).Include(c => c.Vehiculo);
            return View(await miBaseDeDatosContext.ToListAsync());
        }

        // GET: ClientesVehiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClienteVehiculos == null)
            {
                return NotFound();
            }

            var clienteVehiculo = await _context.ClienteVehiculos
                .Include(c => c.Cliente)
                .Include(c => c.Vehiculo)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clienteVehiculo == null)
            {
                return NotFound();
            }

            return View(clienteVehiculo);
        }

        // GET: ClientesVehiculos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto");
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "Id", "Patente");
            return View();
        }

        // POST: ClientesVehiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,VehiculoId")] ClienteVehiculo clienteVehiculo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(clienteVehiculo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Se presentó un error");
                }
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellido", clienteVehiculo.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "Id", "Id", clienteVehiculo.VehiculoId);
            return View(clienteVehiculo);
        }

        // GET: ClientesVehiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClienteVehiculos == null)
            {
                return NotFound();
            }

            var clienteVehiculo = await _context.ClienteVehiculos.FindAsync(id);
            if (clienteVehiculo == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellido", clienteVehiculo.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "Id", "Id", clienteVehiculo.VehiculoId);
            return View(clienteVehiculo);
        }

        // POST: ClientesVehiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,VehiculoId")] ClienteVehiculo clienteVehiculo)
        {
            if (id != clienteVehiculo.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteVehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteVehiculoExists(clienteVehiculo.ClienteId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellido", clienteVehiculo.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "Id", "Id", clienteVehiculo.VehiculoId);
            return View(clienteVehiculo);
        }

        // GET: ClientesVehiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClienteVehiculos == null)
            {
                return NotFound();
            }

            var clienteVehiculo = await _context.ClienteVehiculos
                .Include(c => c.Cliente)
                .Include(c => c.Vehiculo)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clienteVehiculo == null)
            {
                return NotFound();
            }

            return View(clienteVehiculo);
        }

        // POST: ClientesVehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClienteVehiculos == null)
            {
                return Problem("Entity set 'GarageContext.ClienteVehiculos'  is null.");
            }
            var clienteVehiculo = await _context.ClienteVehiculos.FindAsync(id);
            if (clienteVehiculo != null)
            {
                _context.ClienteVehiculos.Remove(clienteVehiculo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteVehiculoExists(int id)
        {
          return _context.ClienteVehiculos.Any(e => e.ClienteId == id);
        }
    }
}
