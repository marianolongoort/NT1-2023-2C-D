using Microsoft.AspNetCore.Mvc;
using NT1_2023_2C_D.Models;
using System.Diagnostics;

namespace NT1_2023_2C_D.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
    }
}