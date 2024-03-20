using EMAI.Comun.Models;
using EMAI.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionMaestroController: Controller
    {
        private readonly IAsignacionMaestroOperaciones _repository;

       public AsignacionMaestroController(IAsignacionMaestroOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
       [HttpGet]
        public async Task<ActionResult<IEnumerable<AsigMaestroModel>>> Get()
        {
            return await _repository.GetAsigMaestro1();
        }

        // buscar ID 
        [HttpGet("{AsgnId}")]
        public async Task<ActionResult<AsigMaestroId>> GetAsigMaestrobyID(int AsgnId)
        {
            return await _repository.GetAsigMaestroId1(AsgnId);
        }

        /*INSERTA REGISTRO*/

        [HttpPost("/api/Maestro/Asignar")]
        public async Task Post([FromBody] AsigMaestro1Asignar value)
        {
            await _repository.AsignarMaestro(value);
        }

        //Eliminar AsignacionClase
        [HttpDelete("Eliminar/{AsgnId}")]
        public async Task Delete(int AsgnId)
        {
            await _repository.EliminarAsignacionMaestro(AsgnId);
        }

        /*Actualizar*/
        [HttpPut("Actualizar")]
        public async Task Put([FromBody] ActualizarAsigMaestro value)
        {
            await _repository.ActualizarAsigMaestro(value.AsgnId,value.IdMaestro,value.IdClase,value.IdHorario);
        }

    }
}
