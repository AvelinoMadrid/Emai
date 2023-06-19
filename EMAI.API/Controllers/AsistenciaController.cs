using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;
using EMAI.Comun;
using EMAI.Comun.Models;


namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenciaController : ControllerBase
    {
        private readonly IAsistenciaOperaciones _repository;

        public AsistenciaController(IAsistenciaOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsistenciaModel>>> Get()
        {
            return await _repository.GetAllAsistencias();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsistenciaModel>> Get(int id)
        {
            var response = await _repository.GetAsistenciaByID(id);
            if (response == null) { return NotFound(); }
            return response;
        }

        [HttpPost]
        public async Task Post([FromBody] InsertAsistenciaModel value)
        {
            await _repository.InsertarAlumnoAsistencia(value);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.DeleteAsistenciabyID(id);
        }

        [HttpPut("[action]")]
        public async Task Put([FromBody] UpdateAsistenciaModel value)
        {
            await _repository.UpdateAsistencia(value.IdAsistencia, value.IdAlumno, value.IdClase, value.FechaAsistencia, value.Asistecia);
        }

    }
}
