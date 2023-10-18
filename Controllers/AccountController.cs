using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NT1_2023_2C_D.Models;
using NT1_2023_2C_D.ViewModels;

namespace NT1_2023_2C_D.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Persona> _userManager;

        public AccountController(UserManager<Persona> userManager)
        {
            this._userManager = userManager;
        }


        //Oferta de formulario de registración
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioRegistrar usuarioRegistrarVM)
        {
            if (ModelState.IsValid)
            {
                //avanzo con la registración de un cliente
                Cliente cliente = new Cliente()
                {
                    UserName = usuarioRegistrarVM.Email,
                    Email = usuarioRegistrarVM.Email
                };

                var resultado = await _userManager.CreateAsync(cliente,usuarioRegistrarVM.Password);

                if (resultado.Succeeded)
                {
                    //si está ok, sigo con lo que sea necesario.
                    return RedirectToAction("Edit","Clientes",new { id = cliente.Id});
                }
                //procesar los errores.
                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty,error.Description);
                }
            }
            //caso contrario, regreso a

            return View(usuarioRegistrarVM);
        }



    }
}
