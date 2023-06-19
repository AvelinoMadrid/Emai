using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;
using EMAI.Comun;
using EMAI.Comun.Models;
using System.Security.Cryptography;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorariosController
    {
        private readonly IHorariosOperaciones _repository;

        public HorariosController(IHorariosOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HorariosModel>>> Get()
        {
            return await _repository.GetHorarios();
        }

        //por ID
        [HttpGet("{IdHorario}")]
        public async Task<ActionResult<HorariosIDModel>> GetHorariosID(int IdHorario)
        {
            return await _repository.GetHorariosID(IdHorario);
        }

        //Insertar Horario

        [HttpPost("/api/Horario/Insertar")]
        public async Task Post([FromBody] HorariosInsertarModel value)
        {
            await _repository.InsertarHorario(value);
        }

        //Actualizar Horarios
        [HttpPut("/api/Horarios/Actualizar")]
        public async Task Put([FromBody] HorariosActualizarModel value)
        {
            await _repository.ActualizarHorario(value.IdHorario,value.IdAlumno, value.IdMaestro, value.IdClase, value.Dia, value.Fecha);
        }

        //Eliminar Horarios
        [HttpDelete("Eliminar/{IdHorario}")]
        public async Task Delete(int IdHorario)
        {
            await _repository.EliminarHorario(IdHorario);
        }
    }
}
