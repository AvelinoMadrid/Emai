
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
    public class MaestroController : Controller
    {
        private readonly IServicioMaestro_Api _ServicioMaestro_Api;

        public MaestroController(IServicioMaestro_Api servicioMaestro_Api)
        {
            string baseurl = "https://localhost:7265";
            _ServicioMaestro_Api = servicioMaestro_Api;
        }

        public async Task<List<Maestro>> ObtenerTodos()
        {
            List<Maestro> obtener = await _ServicioMaestro_Api.Lista();

            return obtener;
        }

        public async Task<IActionResult> Maestro()
        {
            List<Maestro> Lista = await _ServicioMaestro_Api.Lista();

            return View(Lista);
        }


        public async Task<IActionResult> agregarmaestro(int IdMaestro)
        {

            Maestro modelo_maestro = new Maestro();

            ViewBag.Accion = "Nuevo Maestro";
            if (IdMaestro != 0)
            {
                modelo_maestro = await _ServicioMaestro_Api.Obtener(IdMaestro);
                ViewBag.Action = "Editar Maestro";
            }
                return View(modelo_maestro);
        }




        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Maestro ob_maestro)
        {
            bool respuesta;

            if (ob_maestro.IdMaestro == 0)
            {
                respuesta = await _ServicioMaestro_Api.Guardar(ob_maestro);
            }
            else
            {
                respuesta = await _ServicioMaestro_Api.Editar(ob_maestro);
            }

            if (respuesta)
                return RedirectToAction("Maestro");
            else
                return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> Eliminar(int IdMaestro)
        {
            var respuesta = await _ServicioMaestro_Api.Eliminar(IdMaestro);

            if (respuesta)
                return RedirectToAction("Maestro");
            else
                return NoContent();
        }

    }
}
