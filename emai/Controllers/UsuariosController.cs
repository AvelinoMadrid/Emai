
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
    public class UsuariosController : Controller
    {

        private readonly IServicio_Api _servicioApi;

        public UsuariosController(IServicio_Api servicio_Api)
        {
            string baseurl = "https://localhost:7265";
            _servicioApi = servicio_Api;
        }

        public async Task<IActionResult> Usuario()
        {
            List<Usuarios> Lista = await _servicioApi.Lista();

            return View(Lista);
        }

        public async Task<IActionResult> agregarusuario1(int idUsuario)
        {
            Usuarios modelo_usuario = new Usuarios();

            ViewBag.Accion = "Nuevo Usuario";
            if (idUsuario != 0)
            {
                modelo_usuario = await _servicioApi.Obtener(idUsuario);
                ViewBag.Action = "Editar Usuario";
            }

            return View(modelo_usuario);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Usuarios ob_usuario)
        {
            bool respuesta;

            if(ob_usuario.idUsuario == 0)
            {
                respuesta = await _servicioApi.Guardar(ob_usuario);
            }
            else
            {
                respuesta = await _servicioApi.Editar(ob_usuario);
            }

            if (respuesta)
                return RedirectToAction("Usuario");
            else
                return NoContent();
        }



        [HttpGet]
        public async Task<IActionResult> Eliminar(int idUsuario)
        {
            var respuesta = await _servicioApi.Eliminar(idUsuario);

            if (respuesta)
                return RedirectToAction("Usuario");
            else
                return NoContent();
        }




        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        //public IActionResult Error1()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        //}



     






    }
}

