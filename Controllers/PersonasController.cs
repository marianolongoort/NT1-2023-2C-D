using Microsoft.AspNetCore.Mvc;
using NT1_2023_2C_D.Data;
using NT1_2023_2C_D.Models;

namespace NT1_2023_2C_D.Controllers
{
    public class PersonasController : Controller
    {
        public ActionResult Index()
        {

            var personas = PersonasRepository.Personas;

            return View(personas);
        }

        //Oferta de formulario                
        public ActionResult Create()
        {
            return View();
        }


        //recibo y proceso la info
        [HttpPost]
        public ActionResult Create(string apellidoo, string nombre)
        {
            Persona persona = new Persona();
            persona.Nombre = nombre;
            persona.Apellido = apellidoo;            

            PersonasRepository.Personas.Add(persona);
            
            return RedirectToAction("Index");
        }



    }
}
