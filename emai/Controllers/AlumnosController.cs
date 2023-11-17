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
    public class AlumnosController : Controller
    {
        private readonly IServicioAlumnos_Api _ServicioAlumnos_Api;

        public AlumnosController(IServicioAlumnos_Api servicioUsuarios_Api)
        {
            string baseurl = "https://localhost:7265";
            _ServicioAlumnos_Api = servicioUsuarios_Api;
        }


        public async Task<IActionResult> Alumnos()
        {
            List<Alumnos> Lista = await _ServicioAlumnos_Api.Lista();

            return View(Lista);
        }


        public async Task<IActionResult> agregaralumnos(int IdAlumno)
        {

            Alumnos modelo_usuario = new Alumnos();

            ViewBag.Accion = "Nuevo Alumno";
            if (IdAlumno != 0)
            {
                modelo_usuario = await _ServicioAlumnos_Api.ObtenerAlu(IdAlumno);
                ViewBag.Action = "Editar Alumno";
            }
            return View(modelo_usuario);
        }




        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Alumnos ob_usuario)
        {
            bool respuesta;

            if (ob_usuario.IdAlumno == 0)
            {
                respuesta = await _ServicioAlumnos_Api.GuardarAlu(ob_usuario);
            }
            else
            {
                respuesta = await _ServicioAlumnos_Api.EditarAlu(ob_usuario);
            }

            if (respuesta)
                return RedirectToAction("Alumno");
            else
                return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> Eliminar(int IdAlumno)
        {
            var respuesta = await _ServicioAlumnos_Api.EliminarAlu(IdAlumno);

            if (respuesta)
                return RedirectToAction("Alumno");
            else
                return NoContent();
        }
    }
}
