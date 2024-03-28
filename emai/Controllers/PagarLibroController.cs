using emai.Models;
using emai.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace emai.Controllers
{
    public class PagarLibroController : Controller
    {
        // GET: PagarLibroController
        public ActionResult Index()
        {
            return View();
        }

        // POST: PagarLibroController/Create
    
        public async Task<IActionResult> PagarLibro()
        {
           // List<Libro> Lista = await _ServicioLibro_Api.ListaInactivo();

            return View();
        }
        /*Agregar pagar libro*/
        public async Task<IActionResult> Pagar(int IdLibro)
        {
            /*
            Libro modelo_lib = new Libro();

            ViewBag.Accion = "Nuevo Libro";
            if (IdLibro != 0)
            {
              //  modelo_lib = await _ServicioLibro_Api.Obtener(IdLibro);
                ViewBag.Action = "Editar Libro";
            }

            return View(modelo_lib);
            */
            return View();
        }

        // GET: PagarLibroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // GET: PagarLibroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
