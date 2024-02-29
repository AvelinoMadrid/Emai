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
    public class GastosDiaController : Controller
    {
        private readonly IServicioGastosDia_Api _ServicioGastosDia_Api;

        public GastosDiaController(IServicioGastosDia_Api servicioColegiatura_Api)
        {
            string baseurl = "https://localhost:7265";
            _ServicioGastosDia_Api = servicioColegiatura_Api;
        }

        public async Task<IActionResult> GastosDia()
        {
            List<GastosDia> Lista = await _ServicioGastosDia_Api.Lista();

            foreach (var GastoDia in Lista)
            {
                //GastoDia.Subtotal = GastoDia.Cantidad;
                //GastoDia.Total = GastoDia.Subtotal * 16m / 100m + GastoDia.Subtotal;
            }

            return View(Lista);
        }

        public async Task<IActionResult> agregargastodia(int IdGastoDia)
        {
            GastosDia modelo_gas = new GastosDia();

            ViewBag.Accion = "Nuevo Gasto Dia";
            if (IdGastoDia != 0)
            {
                modelo_gas = await _ServicioGastosDia_Api.Obtener(IdGastoDia);
                ViewBag.Action = "Editar Gasto Dia";
            }

            return View(modelo_gas);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(GastosDia ob_gastodia)
        {
            bool gas1;

            if (ob_gastodia.IdGastoDia == 0)
            {
                //ob_gastodia.Subtotal = ob_gastodia.Cantidad;
                //ob_gastodia.Total = ob_gastodia.Subtotal * 16m / 100m + ob_gastodia.Subtotal;

                gas1 = await _ServicioGastosDia_Api.Guardar(ob_gastodia);
            }
            else
            {
                gas1 = await _ServicioGastosDia_Api.Editar(ob_gastodia);
            }

            if (gas1)
                return RedirectToAction("GastosDia");
            else
                return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int IdGastoDia)
        {
            var respuesta = await _ServicioGastosDia_Api.Eliminar(IdGastoDia);

            if (respuesta)
                return RedirectToAction("GastosDia");
            else
                return NoContent();
        }
    }
}
