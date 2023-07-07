using emai.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace emai.Controllers
{
    public class Gastos : Controller
    {
        private readonly ILogger<Gastos> _logger;

        public Gastos(ILogger<Gastos> logger)
        {
            _logger = logger;
        }

        public IActionResult MenuGastos()
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