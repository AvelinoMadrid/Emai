using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using emai.Servicios;
using emai.Models;
//using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace emai.Controllers
{
    public class RepClaseController : Controller
    {
        //public IActionResult Reponerclases()
        //{
        //    return View();
        //}


        //public IActionResult agregarreponerclases()
        //{
        //    return View();
        //}
        private readonly IServicioRepClase_Api _ServicioRepClaseApi;
        private readonly IServicioMaestro_Api _ServicioMaestroApi;
        private readonly IServicioClase_Api _ServicioClaseApi;


        public RepClaseController(IServicioRepClase_Api servicioRepClase_Api, IServicioMaestro_Api servicioMaestro_Api, IServicioClase_Api servicioClase_Api)
        {
            string baseurl = "https://localhost:7265";
            _ServicioRepClaseApi = servicioRepClase_Api;
            _ServicioMaestroApi = servicioMaestro_Api;
            _ServicioClaseApi = servicioClase_Api;
        }

        public async Task<IActionResult> RepClase()
        {
            List<RepClase> Lista = await _ServicioRepClaseApi.Lista();

            var maestrosDisponibles = await _ServicioMaestroApi.ObtenerTodos();
            var clasesDisponibles = await _ServicioClaseApi.ObtenerTodos();

            // Asignar los nombres de maestro y clase a cada RepClase
            foreach (var RepClase in Lista)
            {
                // Buscar el maestro correspondiente en la lista de MaestrosDisponibles por su ID
                var maestro = maestrosDisponibles.FirstOrDefault(m => m.IdMaestro == RepClase.IdMaestro);
                if (maestro != null)
                {
                    RepClase.NombreMaestro = maestro.Nombre;
                }

                // Buscar la clase correspondiente en la lista de ClasesDisponibles por su ID
                var clase = clasesDisponibles.FirstOrDefault(c => c.idClase == RepClase.IdClase);
                if (clase != null)
                {
                    RepClase.NombreClase = clase.Nombre;
                }
            }


            return View(Lista);
        }

        public async Task<IActionResult> agregarRepClase(int IdRepClase)
        {
            RepClase modelo_RepClase = new RepClase();

            ViewBag.Accion = "Nuevo RepClase";
            if (IdRepClase != 0)
            {
                modelo_RepClase = await _ServicioRepClaseApi.Obtener(IdRepClase);
                ViewBag.Action = "Editar RepClase";
            }

            modelo_RepClase.MaestrosDisponibles = await _ServicioMaestroApi.ObtenerTodos();
            modelo_RepClase.ClasesDisponibles = await _ServicioClaseApi.ObtenerTodos();

            return View(modelo_RepClase);
        }


        [HttpPost]
        public async Task<IActionResult> GuardarCambios(RepClase ob_RepClase)
        {
            bool respuesta;

            if (ob_RepClase.IdRepClase == 0)
            {
                respuesta = await _ServicioRepClaseApi.Guardar(ob_RepClase);
            }
            else
            {
                respuesta = await _ServicioRepClaseApi.Editar(ob_RepClase);
            }

            if (respuesta)
                return RedirectToAction("RepClase");
            else
                return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> Eliminar(int IdRepClase)
        {
            var respuesta = await _ServicioRepClaseApi.Eliminar(IdRepClase);

            if (respuesta)
                return RedirectToAction("RepClase");
            else
                return NoContent();
        }

    }





}