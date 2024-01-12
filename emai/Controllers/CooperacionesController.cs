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
    public class CooperacionesController : Controller
    {
        private readonly IServicioCooperaciones_Api _ServicioCooperacionesApi;

        public CooperacionesController(IServicioCooperaciones_Api servicioCooperaciones_Api)
        {
            string baseurl = "https://localhost:7265";
            _ServicioCooperacionesApi = servicioCooperaciones_Api;
        }

        public async Task<List<Cooperaciones>> ObtenerTodos()
        {
            List<Cooperaciones> Lista = await _ServicioCooperacionesApi.Lista();

            return Lista;
        }

        public async Task<IActionResult> Cooperaciones()
        {
            List<Cooperaciones> Lista = await _ServicioCooperacionesApi.Lista();

            foreach (var Dotacion in Lista)
            {
                Dotacion.SubTotal = Dotacion.Cantidad;
                Dotacion.Total = Dotacion.SubTotal * 16m / 100m + Dotacion.SubTotal;
            }

            return View(Lista);
        }

        public async Task<IActionResult> agregarcooperaciones(int IdCooperacion)
        {
            Cooperaciones modelo_cooperaciones = new Cooperaciones();

            ViewBag.Accion = "Nueva Cooperacion";
            if (IdCooperacion != 0)
            {
                modelo_cooperaciones = await _ServicioCooperacionesApi.Obtener(IdCooperacion);
                ViewBag.Action = "Editar Cooperacion";
            }

            return View(modelo_cooperaciones);
        }


        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Cooperaciones ob_cooperacion)
        {
            bool respuesta;

            if (ob_cooperacion.IdCooperacion == 0)
            {
                ob_cooperacion.SubTotal = ob_cooperacion.Cantidad;
                ob_cooperacion.Total = ob_cooperacion.SubTotal * 16m / 100m + ob_cooperacion.SubTotal;

                respuesta = await _ServicioCooperacionesApi.Guardar(ob_cooperacion);
            }
            else
            {
                respuesta = await _ServicioCooperacionesApi.Editar(ob_cooperacion);
            }

            if (respuesta)
                return RedirectToAction("Cooperaciones");
            else
                return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> Eliminar(int IdCooperacion)
        {
            var respuesta = await _ServicioCooperacionesApi.Eliminar(IdCooperacion);

            if (respuesta)
                return RedirectToAction("Cooperaciones");
            else
                return NoContent();
        }
    }
}
