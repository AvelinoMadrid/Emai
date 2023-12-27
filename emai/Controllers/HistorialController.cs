using Microsoft.AspNetCore.Mvc;

namespace emai.Controllers
{
    public class HistorialController : Controller
    {
        public IActionResult VerHistorial()
        {
            return View();
        }
    }
}
