using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using emai.Servicios;
using emai.Models;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;

namespace emai.Controllers
{
    public class PlanEstudiosController : Controller
    {
        private readonly IServicioPlanEstudios_Api _ServicioPlanEstudiosApi;
        private readonly IServicioClase_Api _ServicioClaseApi;
        private readonly IServicioHorarioVerano_Api _ServicioHorarioVeranoApi;
        private readonly IServicioHorario_Api _ServicioHorarioApi;

        public PlanEstudiosController(IServicioPlanEstudios_Api servicioPlanEstudios_Api, IServicioClase_Api servicioClase_Api, IServicioHorarioVerano_Api servicioHorarioVerano_Api, IServicioHorario_Api servicioHorarioApi)
        {
            string baseurl = "https://localhost:7265";
            _ServicioPlanEstudiosApi = servicioPlanEstudios_Api;
            _ServicioClaseApi = servicioClase_Api;
            _ServicioHorarioVeranoApi = servicioHorarioVerano_Api;
            _ServicioHorarioApi = servicioHorarioApi;
        }
        public async Task<IActionResult> MostrarClasesHorario()
        {
            var clasesDisponibles = await _ServicioClaseApi.ObtenerTodos(); 
            var HorariosDisponibles = await _ServicioHorarioApi.ObtenerTodos();
            var HorariosVeranoDisponibles = await _ServicioHorarioVeranoApi.ObtenerTodos();

            
            List<PlanEstudios> lista = new List<PlanEstudios>();
            List<PlanEstudios> listaClasesHorario = await _ServicioPlanEstudiosApi.Lista();

            foreach (var clase in clasesDisponibles)
            {
                var horarioNormal = HorariosDisponibles.FirstOrDefault(h => h.IdHorario == clase.idClase);
                var horarioVerano = HorariosVeranoDisponibles.FirstOrDefault(h => h.IdHorarioVerano == clase.idClase);

                if (horarioNormal != null && horarioVerano != null)
                {
                    var claseHorarioViewModel = new PlanEstudios
                    {
                        Nombre = clase.Nombre,
                        Dia = horarioNormal.Dia,
                        Horario = horarioNormal.HoraInicio.ToString(),
                        HorarioVerano = horarioVerano.HoraInicio.ToString(),
                        Costo = clase.Costo
                    };

                    listaClasesHorario.Add(claseHorarioViewModel);
                }
            }

            return View(listaClasesHorario);
        }

    }
}
