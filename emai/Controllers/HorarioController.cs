
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
        private readonly IServicioMaestro_Api _ServicioMaestroApi;
        private readonly IServicioClase_Api _ServicioClaseApi;


        public HorarioController(IServicioHorario_Api servicioHorario_Api, IServicioMaestro_Api servicioMaestro_Api, IServicioClase_Api servicioClase_Api)
        {
            string baseurl = "https://localhost:7265";
            _ServicioHorarioApi = servicioHorario_Api;
            _ServicioMaestroApi = servicioMaestro_Api;
            _ServicioClaseApi = servicioClase_Api;
        }

        public async Task<IActionResult> Horario()
        {
            List<Horario> Lista = await _ServicioHorarioApi.Lista();

            var maestrosDisponibles = await _ServicioMaestroApi.ObtenerTodos();
            var clasesDisponibles = await _ServicioClaseApi.ObtenerTodos();

            // Asignar los nombres de maestro y clase a cada horario
            foreach (var horario in Lista)
            {
                // Buscar el maestro correspondiente en la lista de MaestrosDisponibles por su ID
                var maestro = maestrosDisponibles.FirstOrDefault(m => m.IdMaestro == horario.IdMaestro);
                if (maestro != null)
                {
                    horario.NombreMaestro = maestro.Nombre;
                }

                // Buscar la clase correspondiente en la lista de ClasesDisponibles por su ID
                var clase = clasesDisponibles.FirstOrDefault(c => c.idClase == horario.IdClase);
                if (clase != null)
                {
                    horario.NombreClase = clase.Nombre;
                }
            }


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

            //modelo_horario.MaestrosDisponibles = await _ServicioMaestroApi.ObtenerTodos();
            //modelo_horario.ClasesDisponibles = await _ServicioClaseApi.ObtenerTodos();

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
