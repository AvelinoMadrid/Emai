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
    public class NominaController : Controller
    {
        private readonly IServicioNomina_Api _ServicioNominaApi;

        public NominaController(IServicioNomina_Api servicioNomina_Api)
        {
            string baseurl = "https://localhost:7265";
            _ServicioNominaApi = servicioNomina_Api;
        }

        public async Task<IActionResult> Nomina()
        {
            List<Nomina> Lista = await _ServicioNominaApi.Lista();

            return View(Lista);
        }

        public async Task<IActionResult> agregarnomina(int IdNomina)
        {
            Nomina modelo_nomina = new Nomina();

            ViewBag.Accion = "Nueva Nomina";
            if (IdNomina != 0)
            {
                modelo_nomina = await _ServicioNominaApi.Obtener(IdNomina);
                ViewBag.Action = "Editar Nomina";
            }

            return View(modelo_nomina);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Nomina ob_Nomina)
        {
            bool nom;

            if (ob_Nomina.IdNomina == 0)
            {
                nom = await _ServicioNominaApi.Guardar(ob_Nomina);
            }
            else
            {
                nom = await _ServicioNominaApi.Editar(ob_Nomina);
            }

            if (nom)
                return RedirectToAction("Nomina");
            else
                return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int IdNomina)
        {
            var respuesta = await _ServicioNominaApi.Eliminar(IdNomina);

            if (respuesta)
                return RedirectToAction("Nomina");
            else
                return NoContent();
        }
    }
}
