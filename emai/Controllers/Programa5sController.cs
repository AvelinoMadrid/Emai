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
    public class Programa5sController : Controller
    {

        private readonly IServicioPrograma5s_Api _servicioPrograma5sApi;

        public Programa5sController(IServicioPrograma5s_Api servicioPrograma5s_Api)
        {
            string baseurl = "https://localhost:7265";
            _servicioPrograma5sApi = servicioPrograma5s_Api;

        }

        public async Task<IActionResult> TablaPrograma5s()
        {
            List<Programa5s> Lista = await _servicioPrograma5sApi.Lista();


            return View(Lista);
        }

        public async Task<IActionResult> Programa5s(int Id)
        {
            Programa5s modelo_programa5s = new Programa5s();

            ViewBag.Accion = "Nuevo Programa5s";
            if (Id != 0)
            {
                modelo_programa5s = await _servicioPrograma5sApi.Obtener(Id);
                ViewBag.Action = "Editar Usuario";
            }

            return View(modelo_programa5s);
        }


  


        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Programa5s ob_programa5s)
        {
            bool respuesta;

            if (ob_programa5s.Id == 0)
            {
                respuesta = await _servicioPrograma5sApi.Guardar(ob_programa5s);
            }
            else
            {
                respuesta = await _servicioPrograma5sApi.Editar(ob_programa5s);
            }

            if (respuesta)
                return RedirectToAction("TablaPrograma5s");
            else
                return NoContent();
        }








    }
}
