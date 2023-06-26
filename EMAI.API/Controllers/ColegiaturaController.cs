using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;
using EMAI.Comun;
using EMAI.Comun.Models;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColegiaturaController
    {
        private readonly IColegiaturaOperaciones _repository;

        public ColegiaturaController(IColegiaturaOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColegiaturaModel>>> Get()
        {
            return await _repository.GetColegiatura();
        }

        //Buscar por ID
        [HttpGet("{IdColegiatura}")]
        public async Task<ActionResult<ColegiaturaIDModel>> GetColegiaturaID(int IdColegiatura)
        {
            return await _repository.GetColegiaturaID(IdColegiatura);
        }

        //Insertar Colegiatura

        [HttpPost("/api/Colegiatura/Insertar")]
        public async Task Post([FromBody] ColegiaturaInsertarModel value)
        {
            await _repository.InsertarColegiatura(value);
        }

        //Actualizar Colegiatura
        [HttpPut("/api/Colegiatura/Actualizar")]
        public async Task Put([FromBody] ColegiaturaActualizarModel value)
        {
            await _repository.ActualizarColegiatura(value.IdColegiatura, value.Fecha, value.NoPedido, value.Descripcion,
                value.Cantidad, value.Subtotal, value.Total);
        }


        //Eliminar Colegiatura
        [HttpDelete("Eliminar/{IdColegiatura}")]
        public async Task Delete(int IdColegiatura)
        {
            await _repository.EliminarColegiatura(IdColegiatura);
        }
    }
}
