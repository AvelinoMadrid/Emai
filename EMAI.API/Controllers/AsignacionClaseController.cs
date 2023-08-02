using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;
using EMAI.Comun;
using EMAI.Comun.Models;


namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionClaseController : Controller
    {
        private readonly IAsignacionClaseOperaciones _repository;

        public AsignacionClaseController(IAsignacionClaseOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsigClaseModel>>> Get()
        {
            return await _repository.GetAsigClase();
        }

        // buscar ID 
        [HttpGet("{AsgnId}")]
        public async Task<ActionResult<AsigClaseId>> GetAlumnosbyID(int AsgnId)
        {
            return await _repository.GetAsigClaseId(AsgnId);
        }

        //Asignar clase 

        [HttpPost("/api/Clases/Asignar")]
        public async Task Post([FromBody] AsigClaseAsignar value)
        {
            await _repository.AsignarClase(value);
        }

        //Eliminar AsignacionClase
        [HttpDelete("Eliminar/{AsgnId}")]
        public async Task Delete(int AsgnId)
        {
            await _repository.EliminarAsignacion(AsgnId);
        }
    }
}
