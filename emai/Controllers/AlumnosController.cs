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
            string baseurl = "http://127.0.0.1:7265"; 
            _ServicioAlumnos_Api = servicioUsuarios_Api;
        }


        public async Task<IActionResult> Alumnos()
        {
            List<Alumnos> Lista = await _ServicioAlumnos_Api.Lista();

            return View(Lista);
        }


        public async Task<IActionResult> agregaralumnos(int IdAlumno)
        {

            Alumnos modelo_Alumnos = new Alumnos();

            ViewBag.Accion = "Nuevo Alumno";
            if (IdAlumno != 0)
            {
                modelo_Alumnos = await _ServicioAlumnos_Api.ObtenerAlu(IdAlumno);
                ViewBag.Action = "Editar Alumno";
            }
            return View(modelo_Alumnos);
        }

        // pModal de Papás
        public async Task<IActionResult> agregarpapas (int IdAlumno)
        {
            Alumnos modelo_Alumnos = new Alumnos();
            //if (IdAlumno != 0)
            //{
            //    modelo_Alumnos = await _ServicioAlumnos_Api.ObtenerAlu(IdAlumno);
            //    ViewBag.Action = "Editar Alumno";
            //}
            return View(modelo_Alumnos);

        }

        // Modal de Registrar Estudios
        public async Task<IActionResult> agregarEstudios(int IdAlumno)
        {
            Alumnos modelo_Alumnos = new Alumnos();
            //if (IdAlumno != 0)
            //{
            //    modelo_Alumnos = await _ServicioAlumnos_Api.ObtenerAlu(IdAlumno);
            //    ViewBag.Action = "Editar Alumno";
            //}
            return View(modelo_Alumnos);
        }

        public async Task<IActionResult> agregarConocimientosMusicales()
        {
            Alumnos modelo_Alumnos = new Alumnos();
            return View();  
        }

        // hoobys 
        public async Task<IActionResult> agregarPasatiempos(int IdAlumno)
        {
            Alumnos modelo_Alumnos = new Alumnos();
            //if (IdAlumno != 0)
            //{
            //    modelo_Alumnos = await _ServicioAlumnos_Api.ObtenerAlu(IdAlumno);
            //    ViewBag.Action = "Editar Alumno";
            //}
            return View(modelo_Alumnos);
        }


        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Alumnos ob_Alumno)
        {
            bool respuesta;

            if (ob_Alumno.IdAlumno == 0)
            {
                respuesta = await _ServicioAlumnos_Api.GuardarAlu(ob_Alumno);
            }
            else
            {
                respuesta = await _ServicioAlumnos_Api.EditarAlu(ob_Alumno);
            }

            if (respuesta)
                return RedirectToAction("Alumnos");
            else
                return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int IdAlumno)
        {
            var respuesta = await _ServicioAlumnos_Api.EliminarAlu(IdAlumno);

            if (respuesta)
                return RedirectToAction("Alumnos");
            else
                return NoContent();
        }

       

    }
}
