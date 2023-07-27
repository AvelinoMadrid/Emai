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
    public class HorarioVeranoController : Controller
    {
        private readonly IServicioHorarioVerano_Api _ServicioHorarioVeranoApi;

        public HorarioVeranoController(IServicioHorarioVerano_Api servicioHorarioVerano_Api)
        {
            string baseurl = "https://localhost:7265";
            _ServicioHorarioVeranoApi = servicioHorarioVerano_Api;
        }

        public async Task<IActionResult> HorarioVerano()
        {
            List<HorarioVerano> Lista = await _ServicioHorarioVeranoApi.Lista();

            return View(Lista);
        }

        public async Task<IActionResult> agregarhorarioVr(int IdHorarioVerano)
        {
            HorarioVerano modelo_horarioVr = new HorarioVerano();

            ViewBag.Accion = "Nuevo Horario Verano";
            if (IdHorarioVerano != 0)
            {
                modelo_horarioVr = await _ServicioHorarioVeranoApi.Obtener(IdHorarioVerano);
                ViewBag.Action = "Editar Horario Verano";
            }

            return View(modelo_horarioVr);
        }


        [HttpPost]
        public async Task<IActionResult> GuardarCambios(HorarioVerano ob_horarioVr)
        {
            bool respuesta;

            if (ob_horarioVr.IdHorarioVerano == 0)
            {
                respuesta = await _ServicioHorarioVeranoApi.Guardar(ob_horarioVr);
            }
            else
            {
                respuesta = await _ServicioHorarioVeranoApi.Editar(ob_horarioVr);
            }

            if (respuesta)
                return RedirectToAction("HorarioVerano");
            else
                return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> Eliminar(int IdHorarioVerano)
        {
            var respuesta = await _ServicioHorarioVeranoApi.Eliminar(IdHorarioVerano);

            if (respuesta)
                return RedirectToAction("HorarioVerano");
            else
                return NoContent();
        }

    }
}
