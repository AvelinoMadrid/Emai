
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
    public class HorarioController : Controller
    {
        private readonly IServicioHorario_Api _ServicioHorarioApi;

        public HorarioController(IServicioHorario_Api servicioHorario_Api)
        {
            string baseurl = "https://localhost:7265";
            _ServicioHorarioApi = servicioHorario_Api;
        }

        public async Task<IActionResult> Horario()
        {
            List<Horario> Lista = await _ServicioHorarioApi.Lista();

            return View(Lista);
        }

        public async Task<IActionResult> agregarhorario(int IdHorario)
        {
            Horario modelo_horario = new Horario();

            ViewBag.Accion = "Nuevo Horario";
            if (IdHorario != 0)
            {
                modelo_horario = await _ServicioHorarioApi.Obtener(IdHorario);
                ViewBag.Action = "Editar Horario";
            }

            return View(modelo_horario);
        }


        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Horario ob_horario)
        {
            bool respuesta;

            if (ob_horario.IdHorario == 0)
            {
                respuesta = await _ServicioHorarioApi.Guardar(ob_horario);
            }
            else
            {
                respuesta = await _ServicioHorarioApi.Editar(ob_horario);
            }

            if (respuesta)
                return RedirectToAction("Horario");
            else
                return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> Eliminar(int IdHorario)
        {
            var respuesta = await _ServicioHorarioApi.Eliminar(IdHorario);

            if (respuesta)
                return RedirectToAction("Horario");
            else
                return NoContent();
        }
    }
}
