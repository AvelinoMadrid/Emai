using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using emai.Servicios;
using emai.Models;
//using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;



namespace emai.Controllers
{
    public class Configuracion : Controller
    {
        public IActionResult Configuracionusuario()
        {
            return View();
        }
    }
}