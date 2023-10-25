using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NT1_2023_2C_D.Data;
using NT1_2023_2C_D.Models;

namespace NT1_2023_2C_D.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly GarageContext _context;

        public ClientesController(GarageContext context)
        {
            _context = context;
        }

        // GET: Clientes        
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("ClienteRol"))
            {
                string username = User.Identity.Name;
                var idUsuario = User.FindFirstValue(ClaimTypes.NameIdentifier);


                if (!string.IsNullOrEmpty(username))
                {
                    //return View(_context.Clientes.Where(c => c.NormalizedUserName == username.ToUpper()).ToList());
                    int idUsuaurioParse = Int32.Parse(idUsuario);

                    return RedirectToAction("details","clientes", new {id = idUsuaurioParse } );
                }                
            }
            return View(await _context.Clientes.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                                            .Include(c=>c.Direccion)
                                            .Include(c=>c.Telefonos)
                                            .FirstOrDefaultAsync(m => m.Id == id);


            if (cliente == null)
            {
                return NotFound();
            }
            
            //si soy cliente, verificar si quiero acceder a los detalles de otro, tomar accion.


            return View(cliente);
        }

        // GET: Clientes/Create
        [Authorize(Roles ="EmpleadoRol")]
        public IActionResult Create()
        {
            return View(new Cliente());
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "EmpleadoRol")]
        public async Task<IActionResult> Create([Bind("CUIT,Id,Nombre,Apellido,DNI,Foto")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            //ModelState.AddModelError("CUIT","Es invalido");
            //ModelState.AddModelError(string.Empty,"Otro error inesperado");
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CUIT,Id,Nombre,Apellido,DNI,Foto")] Cliente clienteDesdeFormulario)
        {
            if (id != clienteDesdeFormulario.Id)
            {
                return NotFound();
            }
                       

            if (ModelState.IsValid)
            {
                try
                {
                    Cliente clienteEnDb = _context.Clientes.Find(clienteDesdeFormulario.Id);
                    //si el cliente existe en la DB
                    if(clienteEnDb != null)
                    {
                        clienteEnDb.CUIT = clienteDesdeFormulario.CUIT;
                        clienteEnDb.Apellido = clienteDesdeFormulario.Apellido;
                    }
                    
                    _context.Update(clienteEnDb);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(clienteDesdeFormulario.Id))
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
            return View(clienteDesdeFormulario);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'GarageContext.Clientes'  is null.");
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
          return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
