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
        private readonly IServicioMaestro_Api _ServicioMaestroApi;
        private readonly IServicioClase_Api _ServicioClaseApi;

        public HorarioVeranoController(IServicioHorarioVerano_Api servicioHorarioVerano_Api, IServicioMaestro_Api servicioMaestro_Api, IServicioClase_Api servicioClase_Api)
        {
            string baseurl = "https://localhost:7265";
            _ServicioHorarioVeranoApi = servicioHorarioVerano_Api;
            _ServicioMaestroApi = servicioMaestro_Api;
            _ServicioClaseApi = servicioClase_Api;
        }

        public async Task<IActionResult> HorarioVerano()
        {
            List<HorarioVerano> Lista = await _ServicioHorarioVeranoApi.Lista();

            var maestrosDisponibles = await _ServicioMaestroApi.ObtenerTodos();
            var clasesDisponibles = await _ServicioClaseApi.ObtenerTodos();

            foreach (var horarioVerano in Lista)
            {
                // Buscar el maestro correspondiente en la lista de MaestrosDisponibles por su ID
                var maestro = maestrosDisponibles.FirstOrDefault(m => m.IdMaestro == horarioVerano.IdMaestro);
                if (maestro != null)
                {
                    horarioVerano.NombreMaestro = maestro.Nombre;
                }

                // Buscar la clase correspondiente en la lista de ClasesDisponibles por su ID
                var clase = clasesDisponibles.FirstOrDefault(c => c.idClase == horarioVerano.IdClase);
                if (clase != null)
                {
                    horarioVerano.NombreClase = clase.Nombre;
                }
            }
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

            modelo_horarioVr.MaestrosDisponibles = await _ServicioMaestroApi.ObtenerTodos();
            modelo_horarioVr.ClasesDisponibles = await _ServicioClaseApi.ObtenerTodos();

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

        public async Task<List<HorarioVerano>> ObtenerTodos()
        {
            List<HorarioVerano> obte = await _ServicioHorarioVeranoApi.Lista();

            return obte;
        }

    }
}
