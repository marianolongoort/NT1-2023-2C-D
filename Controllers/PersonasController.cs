using Microsoft.AspNetCore.Mvc;

namespace NT1_2023_2C_D.Controllers
{
    public class PersonasController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public int DameNumero()        
        {
            
            return 4;
        }
    }
}
