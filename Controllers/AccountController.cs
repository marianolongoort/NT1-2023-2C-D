using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NT1_2023_2C_D.Models;
using NT1_2023_2C_D.ViewModels;

namespace NT1_2023_2C_D.Controllers
{
 
    public class AccountController : Controller
    {
        private readonly UserManager<Persona> _userManager;
        private readonly SignInManager<Persona> _signInManager;

        public AccountController(UserManager<Persona> userManager,SignInManager<Persona> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
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

                    var resultadoAddRole = await _userManager.AddToRoleAsync(cliente, "ClienteRol");

                    if (resultadoAddRole.Succeeded)
                    {
                        return RedirectToAction("Edit", "Clientes", new { id = cliente.Id });
                    }
                    
                    //procesar los errores si fuera necesario.
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


        public IActionResult IniciarSesion(string returnurl)
        {
            TempData["ReturnUrl"] = returnurl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(Login modelo)
        {
           
            if (ModelState.IsValid)
            {
                var resultadoInicioSesion = await _signInManager.PasswordSignInAsync(modelo.Email, modelo.Password, modelo.Recordarme, false);

                if (resultadoInicioSesion.Succeeded)
                {
                    //si tengo return url redirecciono
                    string returnurl = TempData["ReturnUrl"] as string;

                    if (!string.IsNullOrEmpty(returnurl))
                    {
                        //tengo url para redireccionar.
                        return Redirect(returnurl);
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Inicio de sesión inválido.");
            }
            return View(modelo);
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index","Home");
        }



        [HttpGet]
        [Authorize]
        public IActionResult AccesoDenegado()
        {
            return Content("No tenes permisos");
        }

    }
}
