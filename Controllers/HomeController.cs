using Microsoft.AspNetCore.Mvc;
using NT1_2023_2C_D.Models;
using System.Diagnostics;

namespace NT1_2023_2C_D.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index( string mensaje)
        {
            ViewBag.Mensaje = mensaje;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
    }
}