using Microsoft.AspNetCore.Mvc;

namespace emai.Controllers
{
    public class ComprobacionController : Controller
    {
        public IActionResult VerComprobacion()
        {
            return View();
        }


        public IActionResult agregarcomprobacion()
        {
            return View();
        }
    }
}
