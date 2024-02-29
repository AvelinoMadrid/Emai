using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using emai.Servicios;
using emai.Models;
//using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;


namespace emai.Controllers
{
    public class ColegiaturaController : Controller
    {
        private readonly IServicioColegiatura_Api _ServicioColegiatura_Api;

        public ColegiaturaController(IServicioColegiatura_Api servicioColegiatura_Api)
        {
            string baseurl = "https://localhost:7265";
            _ServicioColegiatura_Api = servicioColegiatura_Api;
        }

        public async Task<IActionResult> Colegiatura()
        {
            List<GastosColegiatura> Lista = await _ServicioColegiatura_Api.Lista();

            foreach (var colegiatura in Lista)
            {
                //colegiatura.Subtotal = colegiatura.Cantidad;
                //colegiatura.Total = colegiatura.Subtotal * 16m / 100m + colegiatura.Subtotal;
            }

            return View(Lista);
        }

        public async Task<IActionResult> agregarcolegiatura(int IdColegiatura)
        {
            GastosColegiatura modelo_colegiatura = new GastosColegiatura();

            ViewBag.Accion = "Nueva Colegiatura";
            if (IdColegiatura != 0)
            {
                modelo_colegiatura = await _ServicioColegiatura_Api.Obtener(IdColegiatura);
                ViewBag.Action = "Editar Colegiatura";
            }

            return View(modelo_colegiatura);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(GastosColegiatura ob_colegiatura)
        {
            bool respuesta;
            

            if (ob_colegiatura.IdColegiatura == 0)
            {

                //ob_colegiatura.Subtotal = ob_colegiatura.Cantidad;
                //ob_colegiatura.Total = ob_colegiatura.Subtotal * 16m / 100m + ob_colegiatura.Subtotal;

                respuesta = await _ServicioColegiatura_Api.Guardar(ob_colegiatura);
                
            }
            else
            {
                respuesta = await _ServicioColegiatura_Api.Editar(ob_colegiatura);
            }

            if (respuesta)
                return RedirectToAction("Colegiatura");
            else
                return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int IdColegiatura)
        {
            var respuesta = await _ServicioColegiatura_Api.Eliminar(IdColegiatura);

            if (respuesta)
                return RedirectToAction("Colegiatura");
            else
                return NoContent();
        }

    }
}
