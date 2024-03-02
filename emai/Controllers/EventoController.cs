using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using emai.Servicios;
using emai.Models;
//using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Twilio;

using emai.Servicios;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;



namespace emai.Controllers
{
    public class EventoController : Controller
    {
        private readonly IServicioEvento_Api _ServicioEvento_Api;
        private readonly IServicioAlumnos_Api _ServicioAlumnos_Api;
        private readonly string TwilioAccountSid;
        private readonly string TwilioAuthToken;
        private readonly string TwilioPhoneNumber;
        private readonly IConfiguration _configuration;

        public EventoController(IServicioEvento_Api servicioEvento_Api, IServicioAlumnos_Api alumnosServicio_Api)
        {
            string baseurl = "https://localhost:7265";
            _ServicioEvento_Api = servicioEvento_Api;
            _ServicioAlumnos_Api = alumnosServicio_Api;
            TwilioAccountSid = _configuration.GetSection("Twilio:AccountSid").Value;                    
            TwilioAuthToken = _configuration.GetSection("Twilio:AuthToken").Value;
            TwilioPhoneNumber = _configuration.GetSection("Twilio:PhoneNumber").Value;
        }

        public async Task<IActionResult> Evento()
        {
            List<Evento> Lista = await _ServicioEvento_Api.Lista();

            return View(Lista);
        }

        public async Task<IActionResult> agregarevento(int IdEvento)
        {
            Evento modelo_evento = new Evento();

            ViewBag.Accion = "Nuevo Evento";
            if (IdEvento != 0)
            {
                modelo_evento = await _ServicioEvento_Api.Obtener(IdEvento);
                ViewBag.Action = "Editar Evento";
            }

            return View(modelo_evento);
        }

        //[HttpPost]
        //public async Task<IActionResult> GuardarCambios(Evento ob_evento)
        //{
        //    bool respuesta;

        //    if (ob_evento.IdEvento == 0)
        //    {
        //        respuesta = await _ServicioEvento_Api.Guardar(ob_evento);

        //        if (respuesta)
        //        {
        //            // Recuperar la lista de alumnos de la clase asociada al evento
        //            var alumnos = ObtenerAlumnosPorClase(ob_evento.IdClase);

        //            // Enviar invitaciones a WhatsApp a cada alumno
        //            foreach (var alumno in alumnos)
        //            {
        //                EnviarInvitacionWhatsApp(alumno, ob_evento);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        respuesta = await _ServicioEvento_Api.Editar(ob_evento);
        //    }

        //    if (respuesta)
        //        return RedirectToAction("Evento");
        //    else
        //        return NoContent();
        //}

        [HttpGet]
        public async Task<IActionResult> Eliminar(int IdEvento)
        {
            var respuesta = await _ServicioEvento_Api.Eliminar(IdEvento);

            if (respuesta)
                return RedirectToAction("Evento");
            else
                return NoContent();
        }

        // Obtener alumnos por clase
        //private List<Alumnos> ObtenerAlumnosPorClase(int idClase)
        //{
        //    // Llama a tu servicio de API para obtener la lista de todos los alumnos.
        //    var todosLosAlumnos = _ServicioAlumnos_Api.Lista().Result; // Espera la respuesta de la API de forma síncrona.

        //    // Filtra los alumnos por la clase específica.
        //    var alumnosDeClase = todosLosAlumnos.Where(alumno => alumno.IdClase == idClase).ToList();

        //    return alumnosDeClase;
        //}

        // Enviar invitación por WhatsApp a un alumno
        private void EnviarInvitacionWhatsApp(Alumnos alumno, Evento evento)
        {
            // Inicializa la configuración de Twilio
            TwilioClient.Init(TwilioAccountSid, TwilioAuthToken);

            // El número de teléfono del alumno debe estar en formato internacional (por ejemplo, "+1234567890")
            var numeroDestino = new PhoneNumber(alumno.Celular);

            // Mensaje de WhatsApp
            var mensaje = MessageResource.Create(
                to: numeroDestino,
                from: new PhoneNumber(TwilioPhoneNumber), // Número de Twilio
                body: $"¡Hola {alumno.NombreCompleto}! Te invitamos al evento '{evento.NombreEvento}' el {evento.Fecha} a las {evento.NameHora}. Confirma tu asistencia. ¡Esperamos verte allí!"
            );

            // Maneja la respuesta de la creación del mensaje si lo deseas.
        }
    }
}
