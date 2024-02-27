using EMAI.Comun.Models;
using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;
using static EMAI.Comun.Models.EventosIDModel;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController
    {
        private readonly IEventosOperaciones _repository;

        public EventosController(IEventosOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventosModel>>> Get()
        {
            return await _repository.GetEventos();
        }

        //Buscar por ID
        [HttpGet("{IdEvento}")]
        public async Task<ActionResult<EventosIDModel>> GetEventosID(int IdEvento)
        {
            return await _repository.GetEventosID(IdEvento);
        }

        //Insertar Gastos

        [HttpPost("/api/Evento/Insertar")]
        public async Task Post([FromBody] EventoInsertarModel value)
        {
            await _repository.InsertarEvento(value);
        }

        //Actualizar Gastos
        [HttpPut("/api/Evento/Actualizar")]
        public async Task Put([FromBody] EventosActualizarModel value)
        {
            await _repository.ActualizarEvento(value.IdEvento, value.NombreEvento, value.Fecha, value.IdHora, value.IdAlumno, value.IdClase);
        }

        //Eliminar Gastos
        [HttpDelete("Eliminar/{IdEvento}")]
        public async Task Delete(int IdEvento)
        {
            await _repository.EliminarEvento(IdEvento);
        }

    }
}
