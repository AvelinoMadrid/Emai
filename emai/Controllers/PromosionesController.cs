using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using emai.Servicios;
using emai.Models;
//using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using emai.Servicios;
using Email.Utiilities.Static;
using emai.Servicios.Commons;

namespace emai.Controllers
{
    public class PromosionesController : Controller
    {
        private readonly IServicioPromosiones_Api _ServicioPromosiones_Api;

        public PromosionesController(IServicioPromosiones_Api servicioPromosiones_Api)
        {
            string baseurl = "https://localhost:7265";
            _ServicioPromosiones_Api = servicioPromosiones_Api;
        }




        [HttpGet]
        public async Task<IActionResult> Eliminar(int IdPromociones)
        {
            var respuesta = await _ServicioPromosiones_Api.Eliminar(IdPromociones);

            if (respuesta)
                return RedirectToAction("Promociones");
            else
                return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> EliminarPromosionV1(int IdPromociones)
        {
            BaseResponseV4<bool> PromocionesModelV1 = await _ServicioPromosiones_Api.EliminarPromosionV1(IdPromociones);

            if (PromocionesModelV1.Data == true)
            {
                return RedirectToAction("Promociones");

            }
            else
            {
                return NoContent();
            }




        }

        public async Task<IActionResult> Promociones()
        {
            BaseResponseV3<PromocionesModelV1> PromocionesModelV1 = await _ServicioPromosiones_Api.ListarAllPromosiones();
            return View(PromocionesModelV1);
        }


        public async Task<IActionResult> agregarpromociones(int IdPromociones)
        {

            PromocionesModelV1 modelo_promosion = new PromocionesModelV1();

            ViewBag.Accion = "Nuevo Promocion";
            if (IdPromociones != 0)
            {
                modelo_promosion = await _ServicioPromosiones_Api.Obtener(IdPromociones);
                ViewBag.Action = "Editar Promocion";
            }
            return View(modelo_promosion);
        }


        [HttpPost]
        public async Task<IActionResult> Guardar(PromocionesModelV1 ob_promosion)
        {
            bool respuesta;

            if (ob_promosion.IdPromociones == 0)
            {
                respuesta = await _ServicioPromosiones_Api.Guardar(ob_promosion);
            }
            else
            {
                respuesta = await _ServicioPromosiones_Api.Editar(ob_promosion);
            }

            if (respuesta)
                return RedirectToAction("Promociones");
            else
                return NoContent();
        }




    }

  

}