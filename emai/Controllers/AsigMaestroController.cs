using emai.Models;
using emai.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace emai.Controllers
{

    public class AsigMaestroController : Controller
    {
        private readonly IServicioAsigMaestro_Api _ServicioAsigMaestro_Api;
        private readonly IServicioMaestro_Api _ServicioMaestro_Api;
        private readonly IServicioClase_Api _ServicioClase_Api;
        private readonly IServicioHorario_Api _ServicioHorario_Api;

        public AsigMaestroController(IServicioAsigMaestro_Api servicioAsigMaestro_Api,IServicioMaestro_Api servicioMaestro_Api,IServicioClase_Api servicioClase_Api,IServicioHorario_Api servicioHorario_Api )
        {
            string baseurl = "https://localhost:7265";
            _ServicioAsigMaestro_Api = servicioAsigMaestro_Api;
            _ServicioMaestro_Api = servicioMaestro_Api;
            _ServicioClase_Api = servicioClase_Api;
            _ServicioHorario_Api = servicioHorario_Api;
        }

        

        /*Mostrar registros*/
        public async Task<IActionResult> AsigMaestro()
        {
             List<AsigMaestro> Lista = await _ServicioAsigMaestro_Api.ListaAsigMaestro();
            
             var maestrosDisponibles = await _ServicioMaestro_Api.ObtenerTodos();
             var clasesDisponibles = await _ServicioClase_Api.ObtenerTodos();
             var horariosDisponibles = await _ServicioHorario_Api.ObtenerTodos(); 

            foreach (var horario in Lista)
             {
                 // Buscar el maestro correspondiente en la lista de MaestrosDisponibles por su ID
                 var maestroD = maestrosDisponibles.FirstOrDefault(m => m.IdMaestro == horario.IdMaestro);
                 if (maestroD != null)
                 {
                     horario.NombreMaestro = maestroD.Nombre;
                 }

                 // Buscar la clase correspondiente en la lista de ClasesDisponibles por su ID
                 var claseD = clasesDisponibles.FirstOrDefault(c => c.idClase == horario.IdClase);
                 if (claseD != null)
                 {
                     horario.NombreClase = claseD.Nombre;
                 }
                // Buscar la clase correspondiente en la lista de HorariosDisponibles por su ID
                var horarios = horariosDisponibles.FirstOrDefault(h => h.IdHorario == horario.IdHorario);
                if (horarios != null)
                {
                    horario.Horario = horarios.Dia;
                   // horario.Fecha = horarios.Fecha;
                }
            }
             

            return View(Lista);
           
        }

        /*ASIGNAR MAESTRO*/
        public async Task<IActionResult> agregarasigMaestro(int AsgnId)
        {
            AsigMaestro modelo_asig = new AsigMaestro();

            ViewBag.Accion = "Nueva Asignacion";
            if (AsgnId != 0)
            {
                modelo_asig = await _ServicioAsigMaestro_Api.Obtener(AsgnId);
                ViewBag.Action = "Editar Asignacion";
            }

            modelo_asig.MaestrosDisponibles = await _ServicioMaestro_Api.ObtenerTodos();
            modelo_asig.ClasesDisponibles = await _ServicioClase_Api.ObtenerTodos();
            modelo_asig.HorariosDisponibles = await _ServicioHorario_Api.ObtenerTodos();

            return View(modelo_asig);
        }
        [HttpPost]
        public async Task<IActionResult> GuardarCambios(AsigMaestro ob_asigMaestro)
        {
            bool gas1;

            if (ob_asigMaestro.AsgnId == 0)
            {
                gas1 = await _ServicioAsigMaestro_Api.AsignarAsigMaestro(ob_asigMaestro);
            }
            else
            {
                gas1 = await _ServicioAsigMaestro_Api.ActualizarAsigMaestro(ob_asigMaestro);
            }

            if (gas1)
                return RedirectToAction("AsigMaestro");
            else
                return NoContent();
        }

        /*ELIMINAR REGISTRO*/
        public async Task<IActionResult> EliminarAsignacion(int AsgnId)
        {

            var respuesta = await _ServicioAsigMaestro_Api.EliminarAsignacion(AsgnId);

            if (respuesta)
                return RedirectToAction("AsigMaestro");
            else
                return NoContent();
        }

        /*EDITAR ASIGNACION DE USUARIO*/



    }
}
