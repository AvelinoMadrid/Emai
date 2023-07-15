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
    public class PagoController : Controller
    {
        private readonly IServicioPago_Api _ServicioPagoApi;

        public PagoController(IServicioPago_Api servicioPago_Api)
        {
            string baseurl = "https://localhost:7265";
            _ServicioPagoApi = servicioPago_Api;
        }

        public async Task<IActionResult> Pago()
        {
            List<Pago> Lista = await _ServicioPagoApi.Lista();

            return View(Lista);
        }

        public async Task<IActionResult> agregarpago(int IdPago)
        {
            Pago modelo_pago = new Pago();

            ViewBag.Accion = "Nuevo Pago";
            if (IdPago != 0)
            {
                modelo_pago = await _ServicioPagoApi.Obtener(IdPago);
                ViewBag.Action = "Editar Pago";
            }

            return View(modelo_pago);
        }


        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Pago ob_pago)
        {
            bool pags;

            if (ob_pago.IdPago == 0)
            {
                pags = await _ServicioPagoApi.Guardar(ob_pago);
            }
            else
            {
                pags = await _ServicioPagoApi.Editar(ob_pago);
            }

            if (pags)
                return RedirectToAction("Pago");
            else
                return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> Eliminar(int IdPago)
        {
            var pagosss = await _ServicioPagoApi.Eliminar(IdPago);

            if (pagosss)
                return RedirectToAction("Pago");
            else
                return NoContent();
        }
    }
}
