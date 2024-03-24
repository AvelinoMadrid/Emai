using EMAI.Comun.Models;
using EMAI.DTOS.Dtos.Request;
using EMAI.DTOS.Dtos.Response;
using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Programa5sController : Controller
    {
        private readonly IPrograma5sOperaciones _repository;

        public Programa5sController(IPrograma5sOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        //Insertar Programa5sv1

        [HttpPost("RegisterProgramaV1")]
        public async Task<IActionResult> RegisterPrograma([FromForm] Programas5Request request)
        {
            var response = await _repository.RegisterProgramV1(request);
            return Ok(response);
        }
        [HttpGet("GetAllPrograma5s")]
        public async Task<ActionResult<List<Programas5Response>>> ListarProgramaTodosV1()
        {
            var response = await _repository.GetAllProgramaV1();
            return Ok(response);
        }
        [HttpGet("GetAllPrograma5sById/{IdPrograma}")]
        public async Task<ActionResult<Programas5Response>> GetProgramaById(int IdPrograma)
        {
            var response = await _repository.GetPrograma5sById(IdPrograma);
            return Ok(response);
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
