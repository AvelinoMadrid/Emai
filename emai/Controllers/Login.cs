using emai.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace emai.Controllers
{
    public class Account : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public Account(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }


      
    }
}