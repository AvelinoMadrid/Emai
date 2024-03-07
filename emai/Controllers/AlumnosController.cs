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

        //public async Task<IActionResult> ListarAllAlumnos()
        //{
        //     BaseResponseV1<AlumnoModel> alumnos  = await _ServicioAlumnos_Api.ListarAllAlumnos();
        //     return View(alumnos);
        //    ////los que hacemos en validar que diavlos viene 
        //    //if (alumnos.IsSuccess==true)
        //    //{
        //    //     alumnos = alum;
        //    //    return View(alumnos);
        //    //}
        //    //else
        //    //{
        //    //    ViewBag.errormessage = response.Message; //staticvariable.message_not_acceder;
        //    //    return View();//podemos visualizar un vista mostrardo la direccion del error
        //    //}

        //}
        [HttpGet]
        public async Task<IActionResult> Eliminar(int IdAlumno)
        {
            var respuesta = await _ServicioAlumnos_Api.EliminarAlu(IdAlumno);

            if (respuesta)
                return RedirectToAction("Alumnos");
            else
                return NoContent();
        }
        [HttpGet]
        public async Task<string> GenerarFolioV1()
        {
            try
            {
                var response = await _ServicioAlumnos_Api.GenerarFolio();
           
                if(response!=null)
                {
                    return response;
                }
                else
                {
                    return ("Excuse me, No generador de Folio");

                }
            }
            catch(Exception ex)
            {
                return "Error en la solicitud de generar Folio";

            }


            ////correcion de try castrch
            //var response = new FolioGenerado();
            //response = await _ServicioAlumnos_Api.GenerarFolio();

            //return response;

        }



        //public async Task<IActionResult> ListarAllAlumnos()
        //{
        //    BaseResponseV1<AlumnoModel> response = await _ServicioAlumnos_Api.ListarAllAlumnos();

        //    return View(response);
        //    ////los que hacemos en validar que diavlos viene 
        //    //if (response.IsSuccess == true)
        //    //  {
        //    //      var alumnos = response.Data;
        //    //      return View(alumnos);
        //    //  }
        //    //  else
        //    //  {
        //    //      ViewBag.ErrorMessage = response.Message; //StaticVariable.MESSAGE_NOT_ACCEDER;
        //    //      return View();//Podemos visualizar un vista mostrardo la direccion del error
        //    //  }

        //}





        //public async Task<IActionResult> ListarMeses()
        //{
        //    List<MesesModel> Lista = await _ServicioAlumnos_Api.ListarMesesV1();

        //    return Ok(Lista);
        //}


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
            alumno.ListarHorarioSelect= await _ServicioAlumnos_Api.ListarHorarioSelect();
            return View("agregaralumnos", alumno);
        }

        [HttpPost]
        public async Task<IActionResult> agregarNuevoAlumno(Alumnos entity)
        {

            BaseResponseV2<bool> result = await _ServicioAlumnos_Api.InsertarAlumnoV1(entity);

      
            if (result.IsSuccess && result.Data)
            {
                 
                return RedirectToAction("Alumnos");
            }
            else
            {
               
                return View("agregaralumnos", entity);
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


        // [HttpPost]
        //public async Task<IActionResult> GuardarCambios(Alumnos ob_Alumno)
        //{
        //    bool respuesta;

        //    if (ob_Alumno.IdAlumno == 0)
        //    {
        //        respuesta = await _ServicioAlumnos_Api.GuardarAlu(ob_Alumno);
        //    }
        //    else
        //    {
        //        respuesta = await _ServicioAlumnos_Api.EditarAlu(ob_Alumno);
        //    }

        //    if (respuesta)
        //        return RedirectToAction("Alumnos");
        //    else
        //        return NoContent();
        //}


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


    }
}
