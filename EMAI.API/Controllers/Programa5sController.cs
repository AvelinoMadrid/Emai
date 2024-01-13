using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;
using EMAI.Comun;
using EMAI.Comun.Models;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Programa5sController 
    {
        private readonly IPrograma5sOperaciones _repository;

        public Programa5sController(IPrograma5sOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Programa5sModel>>> Get()
        {
            return await _repository.GetPrograma5s();
        }

        //Buscar por ID
        [HttpGet("{Id}")]
        public async Task<ActionResult<Programa5sIdModel>> GetPrograma5sId(int Id)
        {
            return await _repository.GetPrograma5sId(Id);
        }

        //Insertar Programa5s

        [HttpPost("/api/Programa5s/Insertar")]
        public async Task Post([FromBody] Programa5sInsertarModel value)
        {
            await _repository.InsertarPrograma5s(value);
        }

        //Actualizar Programa5s
        [HttpPut("/api/Programa5s/Actualizar")]
        public async Task Put([FromBody] Programa5sActualizarModel value)
        {
            await _repository.ActualizarPrograma5s(value.Id, value.Area, value.Supervisor, value.FechaAntes, value.FechaInicio, value.Detalles);
        }

    }
}
