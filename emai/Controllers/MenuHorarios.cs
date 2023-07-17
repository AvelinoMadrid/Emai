using emai.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace emai.Controllers
{
    public class Horarios : Controller
    {
        private readonly ILogger<Horarios> _logger;

        public Horarios(ILogger<Horarios> logger)
        {
            _logger = logger;
        }

        public IActionResult MenuHorarios()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}