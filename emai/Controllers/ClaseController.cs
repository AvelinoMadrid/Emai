
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using emai.Servicios;
using emai.Models;
//using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using emai.Servicios;

namespace emai.Controllers
{
    public class ClaseController : Controller
    {
      
        private readonly IServicioClase_Api _ServicioClaseApi;

        public ClaseController(IServicioClase_Api servicioClase_Api)
        {
            string baseurl = "https://localhost:7265";
            _ServicioClaseApi = servicioClase_Api;
        }

        public async Task<IActionResult> Clase()
        {
            List<Clase> Lista = await _ServicioClaseApi.Lista();

            return View(Lista);
        }

        public async Task<IActionResult> agregarclase(int idClase)
        {
            Clase modelo_clase = new Clase();

            ViewBag.Accion = "Nueva Clase";
            if (idClase != 0)
            {
                modelo_clase = await _ServicioClaseApi.Obtener(idClase);
                ViewBag.Action = "Editar Clase";
            }

            return View(modelo_clase);
        }


        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Clase ob_clase)
        {
            bool respuesta;

            if (ob_clase.idClase == 0)
            {
                respuesta = await _ServicioClaseApi.Guardar(ob_clase);
            }
            else
            {
                respuesta = await _ServicioClaseApi.Editar(ob_clase);
            }

            if (respuesta)
                return RedirectToAction("Clase");
            else
                return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> Eliminar(int idClase)
        {
            var respuesta = await _ServicioClaseApi.Eliminar(idClase);

            if (respuesta)
                return RedirectToAction("Clase");
            else
                return NoContent();
        }

    }
}
