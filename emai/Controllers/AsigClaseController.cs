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
    public class AsigClaseController : Controller
    {
        private readonly IServicioAsigClase_Api _ServicioAsigClase_Api;
        private readonly IServicioMaestro_Api _ServicioMaestroApi;
        private readonly IServicioClase_Api _ServicioClaseApi;

        public AsigClaseController(IServicioAsigClase_Api servicioAsigclase_Api, IServicioMaestro_Api servicioMaestro_Api, IServicioClase_Api servicioClase_Api)
        {
            string baseurl = "http://127.0.0.1:7265";
            _ServicioAsigClase_Api = servicioAsigclase_Api;
            _ServicioMaestroApi = servicioMaestro_Api;
            _ServicioClaseApi = servicioClase_Api;
        }

        public async Task<IActionResult> AsigClase()
        {
            List<AsigClase> Lista = await _ServicioAsigClase_Api.Lista();

            var maestrosDisponibles = await _ServicioMaestroApi.ObtenerTodos();
            var clasesDisponibles = await _ServicioClaseApi.ObtenerTodos();

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

        public async Task<IActionResult> agregarasigclase(int AsgnId)
        {
            AsigClase modelo_asig = new AsigClase();

            ViewBag.Accion = "Nueva Asignacion";
            if (AsgnId != 0)
            {
                modelo_asig = await _ServicioAsigClase_Api.Obtener(AsgnId);
                //ViewBag.Action = "Editar Gasto Dia";
            }

            modelo_asig.MaestrosDisponibles = await _ServicioMaestroApi.ObtenerTodos();
            modelo_asig.ClasesDisponibles = await _ServicioClaseApi.ObtenerTodos();

            return View(modelo_asig);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(AsigClase ob_asigclase)
        {
            bool gas1;

            if (ob_asigclase.AsgnId == 0)
            {
                gas1 = await _ServicioAsigClase_Api.Asignar(ob_asigclase);
            }
            else
            {
                gas1 = await _ServicioAsigClase_Api.Asignar(ob_asigclase);
            }

            if (gas1)
                return RedirectToAction("AsigClase");
            else
                return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int AsgnId)
        {
            var respuesta = await _ServicioAsigClase_Api.Eliminar(AsgnId);

            if (respuesta)
                return RedirectToAction("AsigClase");
            else
                return NoContent();
        }
    }
}
