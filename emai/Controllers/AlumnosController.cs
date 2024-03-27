using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using emai.Models;
//using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using emai.Servicios;
using Email.Utiilities.Static;
using emai.Servicios.Commons;
using System.Threading.Tasks;
using static System.Web.Razor.Parser.SyntaxConstants;
using System.Runtime.Intrinsics.X86;
using System;
using emai.Servicios.Dtos.Response;
using Humanizer;
using Microsoft.IdentityModel.Tokens;
using emai.Servicios.Dtos.Request;

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
            //Falta hacer el try catch ese devuelve un filo
            BaseResponseV1<AlumnoModel> alumnos = await _ServicioAlumnos_Api.ListarAllAlumnos();
            return View(alumnos);
        }
        public async Task<IActionResult> NuevoAlumno()
        {
            var folioGenerador = await GenerarFolioV1();
            Alumnos alumno = new Alumnos();
            alumno.GeneradorFolioV1 = folioGenerador;
            alumno.ListarClasesSelect = await _ServicioAlumnos_Api.ListarClasesSelect();
            alumno.ListSelectPromocion = await _ServicioAlumnos_Api.ListSelectPromocion();
            alumno.ListarMesesSelect = await _ServicioAlumnos_Api.ListarMesesSelect();
            alumno.ListarHorarioSelect = await _ServicioAlumnos_Api.ListarHorarioSelect();
            alumno.ListClasesUnique = await _ServicioAlumnos_Api.ListarClasesSelectUnique();
            return View("agregaralumnos", alumno);

        }
        public async Task<IActionResult> agregaralumnos(int IdAlumno)
        {
            BaseResponseV2<Alumnos> baseReponse = new BaseResponseV2<Alumnos>();

            Alumnos alumno = new Alumnos();

            ViewBag.Accion = "Nuevo Alumno";

            var folioGenerador = await GenerarFolioV1();

            alumno.GeneradorFolioV1 = folioGenerador;
            alumno.ListarClasesSelect = await _ServicioAlumnos_Api.ListarClasesSelect();
            alumno.ListSelectPromocion = await _ServicioAlumnos_Api.ListSelectPromocion();
            alumno.ListarMesesSelect = await _ServicioAlumnos_Api.ListarMesesSelect();
            alumno.ListarHorarioSelect = await _ServicioAlumnos_Api.ListarHorarioSelect();
            alumno.ListClasesUnique = await _ServicioAlumnos_Api.ListarClasesSelectUnique();


            return View("agregaralumnos", alumno);

        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambiosV1(Alumnos entity)
        {
            BaseResponseV2<bool> result=null;

            if (entity.IdAlumno == 0)
            {
                result = await _ServicioAlumnos_Api.InsertarAlumnoV1(entity);
            }

            if (result.IsSuccess && result.Data)
            {
                
                return RedirectToAction(nameof(Alumnos));
            }
            else
            { 
                return View("Alumnos");
            }
        }
        public async Task<IActionResult> EditarAlumno(int IdAlumno)
        {
            BaseResponseV2<EditarAlumnoRequest> baseReponse = new BaseResponseV2<EditarAlumnoRequest>();

            EditarAlumnoRequest alumnoData = new EditarAlumnoRequest();

            baseReponse = await _ServicioAlumnos_Api.ObtenerAlumnoById(IdAlumno);

            ViewBag.Action = "Editar Clase";
            //obtener la data del id;
            if (IdAlumno != 0)
            {
                baseReponse = await _ServicioAlumnos_Api.ObtenerAlumnoById(IdAlumno);
                alumnoData = baseReponse.Data;
                alumnoData.ListarClasesSelect= await _ServicioAlumnos_Api.ListarClasesSelect();
                alumnoData.ListClasesUnique= await _ServicioAlumnos_Api.ListarClasesSelectUnique();
                alumnoData.ListarHorarioSelect = await _ServicioAlumnos_Api.ListarHorarioSelect();
            }
            return View(alumnoData);
        }
        public async  Task<IActionResult> EditarAlumnoData(EditarAlumnoRequest requestData){
            
            BaseResponseV2<bool> result;

            result = await _ServicioAlumnos_Api.UpdateAlumnoById(requestData);

            if(result.Data ==true)
            {
                ViewBag.mensaje = result.Message;
                return RedirectToAction(nameof(Alumnos),new {mensaje= result.Message});
            }
            else
            {
                return View("Alumnos");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EliminarAlumnosV1(int IdAlumno)
        {
            BaseResponseV2<bool> alumnos = await _ServicioAlumnos_Api.EliminarAlumnoV1(IdAlumno);
            if (alumnos.Data == true)
            {
                return RedirectToAction("Alumnos");

            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet]
        public async Task<IActionResult> ReactivarAlumnosV1(int IdAlumno)
        {
            BaseResponseV2<bool> alumnos = await _ServicioAlumnos_Api.ReactivarAlumnoV1(IdAlumno);

            if (alumnos.Data == true)
            {
                return RedirectToAction("Alumnos");

            }
            else
            {
                return RedirectToAction("Alumnos");
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> ObtenerAlumnoById(int IdAlumno)
        //{
        //    BaseResponseV2<Alumnos> baseReponse = new BaseResponseV2<Alumnos>();
        //    Alumnos dataAlumno = new Alumnos();
        //    baseReponse = await _ServicioAlumnos_Api.ObtenerAlumnoById(IdAlumno);
        //    dataAlumno = baseReponse.Data;

        //    if (dataAlumno != null)
        //    {
        //        return RedirectToAction("agregaralumnos");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Alumnos");
        //    }
        //}

        [HttpGet]
        public async Task<IActionResult> SelectListClasesHorario(int IdClase)
        {
            BaseResponseV1<SelectLisHorario> listaSelect = await _ServicioAlumnos_Api.SelectListHorario(IdClase);

            if (listaSelect.IsSuccess)
            {
                return Json(new { success = true, data = listaSelect.Data });
            }
            else
            {
                return Json(new { success = false, message = "Hubo un error" });

            }
        }
        [HttpGet]
        public async Task<string> GenerarFolioV1()
        {
            try
            {
                var response = await _ServicioAlumnos_Api.GenerarFolio();

                if (response != null)
                {
                    return response;
                }
                else
                {
                    return ("Excuse me, No generador de Folio");

                }
            }
            catch (Exception ex)
            {
                return "Error en la solicitud de generar Folio";

            }

        }

        [HttpGet]
        public async Task<IActionResult> SelectListClasesHorarioV1Nombre(int IdClase)
        {
            BaseResponseV1<SelectLisHorario> listaSelect = await _ServicioAlumnos_Api.SelectListHorario(IdClase);

            if (listaSelect.IsSuccess)
            {
                var data = listaSelect.Data.Select(i => new { Dia = i.Dia });

                return Json(new { success = true, data });
            }
            else
            {
                return Json(new { success = false, message = "Hubo un error" });
            }
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
