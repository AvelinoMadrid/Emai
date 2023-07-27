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
    public class EventoController : Controller
    {
        private readonly IServicioEvento_Api _ServicioEvento_Api;

        public EventoController(IServicioEvento_Api servicioEvento_Api)
        {
            string baseurl = "https://localhost:7265";
            _ServicioEvento_Api = servicioEvento_Api;
        }

        public async Task<IActionResult> Evento()
        {
            List<Evento> Lista = await _ServicioEvento_Api.Lista();

            return View(Lista);
        }

        public async Task<IActionResult> agregarevento(int IdEvento)
        {
            Evento modelo_evento = new Evento();

            ViewBag.Accion = "Nuevo Evento";
            if (IdEvento != 0)
            {
                modelo_evento = await _ServicioEvento_Api.Obtener(IdEvento);
                ViewBag.Action = "Editar Evento";
            }

            return View(modelo_evento);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Evento ob_evento)
        {
            bool respuesta;

            if (ob_evento.IdEvento == 0)
            {
                respuesta = await _ServicioEvento_Api.Guardar(ob_evento);
            }
            else
            {
                respuesta = await _ServicioEvento_Api.Editar(ob_evento);
            }

            if (respuesta)
                return RedirectToAction("Evento");
            else
                return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int IdEvento)
        {
            var respuesta = await _ServicioEvento_Api.Eliminar(IdEvento);

            if (respuesta)
                return RedirectToAction("Evento");
            else
                return NoContent();
        }
    }
}
