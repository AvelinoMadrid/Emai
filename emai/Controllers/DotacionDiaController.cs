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
    public class DotacionDiaController : Controller
    {
        private readonly IServicioDotacionDia_Api _ServicioDotacionDia_Api;

        public DotacionDiaController(IServicioDotacionDia_Api servicioDotacion_Api)
        {
            string baseurl = "https://localhost:7265";
            _ServicioDotacionDia_Api = servicioDotacion_Api;
        }

        public async Task<IActionResult> DotacionDia()
        {
            List<DotacionDia> Lista = await _ServicioDotacionDia_Api.Lista();


            foreach (var Dotacion in Lista)
            {
                Dotacion.Subtotal = Dotacion.Cantidad;
                Dotacion.Total = Dotacion.Subtotal * 16m / 100m + Dotacion.Subtotal;
            }

            return View(Lista);
        }

        public async Task<IActionResult> agregardotaciondia(int IdDotacion)
        {
            DotacionDia modelo_dotaciondia = new DotacionDia();

            ViewBag.Accion = "Nueva DotacionDia";
            if (IdDotacion != 0)
            {
                modelo_dotaciondia = await _ServicioDotacionDia_Api.Obtener(IdDotacion);
                ViewBag.Action = "Editar DotacionDia";
            }

            return View(modelo_dotaciondia);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(DotacionDia ob_dotacion)
        {
            bool respuesta;

            if (ob_dotacion.IdDotacion == 0)
            {
                ob_dotacion.Subtotal = ob_dotacion.Cantidad;
                ob_dotacion.Total = ob_dotacion.Subtotal * 16m / 100m + ob_dotacion.Subtotal;

                respuesta = await _ServicioDotacionDia_Api.Guardar(ob_dotacion);
            }
            else
            {
                respuesta = await _ServicioDotacionDia_Api.Editar(ob_dotacion);
            }

            if (respuesta)
                return RedirectToAction("DotacionDia");
            else
                return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int IdDotacion)
        {
            var respuesta = await _ServicioDotacionDia_Api.Eliminar(IdDotacion);

            if (respuesta)
                return RedirectToAction("DotacionDia");
            else
                return NoContent();
        }
    }
}
