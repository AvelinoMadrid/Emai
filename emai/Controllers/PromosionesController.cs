
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
    public class PromosionesController : Controller
    {
        private readonly IServicioPromosiones_Api _ServicioPromosiones_Api;

        public PromosionesController(IServicioPromosiones_Api servicioPromosiones_Api)
        {
            string baseurl = "https://localhost:7265";
            _ServicioPromosiones_Api = servicioPromosiones_Api;
        }

        public async Task<List<Promosiones>> ObtenerTodos()
        {
            List<Promosiones> obtener = await _ServicioPromosiones_Api.Lista();

            return obtener;
        }

        public async Task<IActionResult> Promociones()
        {
            List<Promosiones> Lista = await _ServicioPromosiones_Api.Lista();

            return View(Lista);
        }


        public async Task<IActionResult> agregarpromociones(int IdPromociones)
        {

            Promosiones modelo_promociones = new Promosiones();

            ViewBag.Accion = "Nuevo Promociones";
            if (IdPromociones != 0)
            {
                modelo_promociones = await _ServicioPromosiones_Api.Obtener(IdPromociones);
                ViewBag.Action = "Editar Promociones";

                //modelo_maestro.StatusSeleccionado = modelo_maestro.Status ? "Base" : "Suplente";
            }
                return View(modelo_promociones);
        }




        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Promosiones ob_promociones)
        {
            bool respuesta;

            //ob_maestro.Status = ob_maestro.StatusSeleccionado == "Base";

            if (ob_promociones.IdPromociones == 0)
            {
                respuesta = await _ServicioPromosiones_Api.Guardar(ob_promociones);
            }
            else
            {
                respuesta = await _ServicioPromosiones_Api.Editar(ob_promociones);
            }

            if (respuesta)
                return RedirectToAction("Promociones");
            else
                return NoContent();
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

    }
}
