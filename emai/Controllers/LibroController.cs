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
    public class LibroController : Controller
    {
        private readonly IServicioLibro_Api _ServicioLibro_Api;

        public LibroController(IServicioLibro_Api servicioLibro_Api)
        {
            string baseurl = "https://localhost:7265";
            _ServicioLibro_Api = servicioLibro_Api;
        }

        public async Task<IActionResult> Libro()
        {
            List<Libro> Lista = await _ServicioLibro_Api.Lista();

            return View(Lista);
        }

        public async Task<IActionResult> LibroInactivo()
        {
            List<Libro> Lista = await _ServicioLibro_Api.ListaInactivo();

            return View(Lista);
        }

        public async Task<IActionResult> agregarlibro(int IdLibro)
        {
            Libro modelo_lib = new Libro();

            ViewBag.Accion = "Nuevo Libro";
            if (IdLibro != 0)
            {
                modelo_lib = await _ServicioLibro_Api.Obtener(IdLibro);
                ViewBag.Action = "Editar Libro";
            }

            return View(modelo_lib);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Libro ob_libroo)
        {
            bool lib1;

            if (ob_libroo.IdLibro == 0)
            {
                lib1 = await _ServicioLibro_Api.Guardar(ob_libroo);
            }
            else
            {
                lib1 = await _ServicioLibro_Api.Editar(ob_libroo);
            }

            if (lib1)
                return RedirectToAction("Libro");
            else
                return NoContent();
        }



        /*pendiente*/
        public async Task<IActionResult> ActivarLibro(int IdLibro, string Estado)
        {
            Libro model_Inactivo = new Libro();

            model_Inactivo = await _ServicioLibro_Api.ObtenerInactivo(IdLibro, Estado);
            ViewBag.Action = "Activar Libro";


            return View(model_Inactivo);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambiosInactivo(Libro libro_inactivo)
        {
            bool libroActivar;

            libroActivar = await _ServicioLibro_Api.ActivarLibro(libro_inactivo);


            if (libroActivar)
                return RedirectToAction("Libro");
            else
                return NoContent();
        }


    }
}
