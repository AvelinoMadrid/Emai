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
    public class ClaseController : Controller
    {

        private readonly IServicioClase_Api _ServicioClaseApi;
        private readonly IServicioHorario_Api _ServicioHorarioApi;

        public ClaseController(IServicioClase_Api servicioClase_Api, IServicioHorario_Api servicioHorario_Api)
        {
            string baseurl = "https://localhost:7265";
            _ServicioClaseApi = servicioClase_Api;
            _ServicioHorarioApi = servicioHorario_Api;
        }

        public async Task<List<Clase>> ObtenerTodos()
        {
            List<Clase> obte = await _ServicioClaseApi.Lista();

            return obte;
        }

        //public async Task<IActionResult> Clase()
        //{
        //    List<Clase> Lista = await _ServicioClaseApi.Lista();
        //    var HorarioDisponibles = await _ServicioHorarioApi.ObtenerTodos();

        //    foreach (var horario in Lista)
        //    {
        //        // Buscar el maestro correspondiente en la lista de MaestrosDisponibles por su ID
        //        var horarios = HorarioDisponibles.FirstOrDefault(m => m.IdHorario == horario.idHorario);
        //        if (horarios != null)
        //        {
        //            horario.NombreHorario = horarios.Dia;
        //        }


        //    }

        //    return View(Lista);
        //}

        //public async Task<IActionResult> agregarclase(int idClase)
        //{
        //    Clase modelo_clase = new Clase();

        //    ViewBag.Accion = "Nueva Clase";
        //    if (idClase != 0)
        //    {
        //        modelo_clase = await _ServicioClaseApi.Obtener(idClase);
        //        ViewBag.Action = "Editar Clase";
        //    }


        //    modelo_clase.HorarioDisponibles = await _ServicioHorarioApi.ObtenerTodos();

        //    return View(modelo_clase);
        //}


        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Clase ob_clase)
        {
            bool respuesta;

            if (ob_clase.idClase == 0)
            {
                respuesta = await _ServicioClaseApi.Guardar(ob_clase);
            }
            else
            {
                respuesta = await _ServicioClaseApi.Editar(ob_clase);
            }

            if (respuesta)
                return RedirectToAction("Clase");
            else
                return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> Eliminar(int idClase)
        {
            var respuesta = await _ServicioClaseApi.Eliminar(idClase);

            if (respuesta)
                return RedirectToAction("Clase");
            else
                return NoContent();
        }

    }
}
