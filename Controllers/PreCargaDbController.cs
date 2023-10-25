using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NT1_2023_2C_D.Data;
using NT1_2023_2C_D.Models;

namespace NT1_2023_2C_D.Controllers
{
    public class PreCargaDbController : Controller
    {
        private readonly GarageContext _context;
        private readonly UserManager<Persona> _usermanager;
        private readonly RoleManager<Rol> _rolemanager;

        public PreCargaDbController(
            GarageContext context,
            UserManager<Persona> usermanager,
            RoleManager<Rol> rolemanager)
        {
            this._context = context;
            this._usermanager = usermanager;
            this._rolemanager = rolemanager;
        }

        public IActionResult Seed()
        {
            AddRoles().Wait();


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

            if (!_context.Vehiculos.Any())
            {
                AddVehiculos();
            }



            return RedirectToAction("Index","Home", new {mensaje = "Precarga realizada" });
        }


        private async Task AddRoles()
        {
            Rol rol1 = new Rol() { 
                Name = "EmpleadoRol"            
            };
            
            Rol rol2 = new Rol()
            {
                Name = "ClienteRol"
            };

            var resultado1 = await _rolemanager.CreateAsync(rol1);            
            var resultado2 = await _rolemanager.CreateAsync(rol2);



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

            Cliente cliente2 = new Cliente();
            cliente2.Nombre = "Betty";
            cliente2.Apellido = "Marmol";
            cliente2.DNI = 55333444;
            cliente2.CUIT = 20553334441;
            _context.Clientes.Add(cliente2);

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

        private void AddVehiculos()
        {
            Vehiculo vehiculo1 = new Vehiculo() { 
                AnioFabricacion = 1999,
                Color = "Negro",
                Foto = "default.png",
                Marca = "Fiat",
                Patente = "III222"};

            _context.Vehiculos.Add(vehiculo1);
            _context.SaveChanges();
        }
    }
}
