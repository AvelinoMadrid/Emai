using EMAI.Comun.Models;
using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdicionalesController
    {
        private readonly IAdicionalesOperaciones _repository;

        public AdicionalesController(IAdicionalesOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdicionalesModel>>> Get()
        {
            return await _repository.GetAdicionales();
        }

        //Buscar por ID
        [HttpGet("{IdAdicional}")]
        public async Task<ActionResult<AdicionalesIDModel>> GetAdicionalesID(int IdAdicional)
        {
            return await _repository.GetAdicionalesID(IdAdicional);
        }

        //Insertar Adicional

        [HttpPost("/api/Adicional/Insertar")]
        public async Task Post([FromBody] AdicionalesInsertarModel value)
        {
            await _repository.InsertarAdicional(value);
        }

        //Actualizar Adicional
        [HttpPut("/api/Adicional/Actualizar")]
        public async Task Put([FromBody] AdicionalesActualizarModel value)
        {
            await _repository.ActualizarAdicional(value.IdAdicional, value.IdAlumno, value.IdClase, value.IdHorario,
                value.Fecha);
        }


        //Eliminar Adicional
        [HttpDelete("Eliminar/{IdAdicional}")]
        public async Task Delete(int IdAdicional)
        {
            await _repository.EliminarAdicional(IdAdicional);
        }
    }
}
