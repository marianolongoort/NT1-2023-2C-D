using Microsoft.AspNetCore.Mvc;
using NT1_2023_2C_D.Data;
using NT1_2023_2C_D.Models;

namespace NT1_2023_2C_D.Controllers
{
    public class PreCargaDbController : Controller
    {
        private readonly GarageContext _context;

        public PreCargaDbController(GarageContext context)
        {
            this._context = context;
        }

        public IActionResult Seed()
        {
            if (!_context.Personas.Any())
            {
                AddPersonas();
            }
            if (!_context.Clientes.Any())
            {
                AddClientes();
            }

            if (!_context.Direcciones.Any())
            {
                AddDirecciones();
            }

            return RedirectToAction("Index","Home", new {mensaje = "Precarga realizada" });
        }

        private void AddDirecciones()
        {
            if (_context.Clientes.Any())
            {
                var clientePrimero = _context.Clientes.FirstOrDefault();

                if(clientePrimero != null)
                {
                    Direccion dir1 = new Direccion()
                    {
                        Calle = "Cordoba",
                        Numero = 1,
                        Piso = 6,
                        Departamento = "A",
                        CodigoPostal = "1423"
                    };
                    dir1.ClienteId = clientePrimero.Id;
                    
                    _context.Direcciones.Add(dir1);
                    
                }
            }

            _context.SaveChanges();


        }

        public IActionResult DeleteDB()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            return RedirectToAction("Index", "Home", new { mensaje = "DB regenerada" });
        }

        private void AddClientes()
        {
            Cliente cliente1 = new Cliente();
            cliente1.Nombre = "Vilma";
            cliente1.Apellido = "Picapiedra";
            cliente1.DNI = 55333444;
            cliente1.CUIT = 20553334440;
            

            _context.Clientes.Add(cliente1);
            _context.SaveChanges();
        }

        private void AddPersonas()
        {
            Persona persona1 = new Persona();
            persona1.Nombre = "Pedro";
            persona1.Apellido = "Picapiedra";
            persona1.DNI = 22333444;

            _context.Personas.Add(persona1);
            _context.SaveChanges();
        }
    }
}
