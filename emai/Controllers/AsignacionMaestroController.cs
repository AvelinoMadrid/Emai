using Microsoft.AspNetCore.Mvc;

namespace emai.Controllers
{
    public class AsignacionMaestroController : Controller
    {
        public IActionResult Asignacionmaestros()
        {
            return View();
        }


        public IActionResult agregarasignacionmaestros()
        {
            return View();
        }
    }
}
