using EMAI.Comun.Models;
using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NominaController : ControllerBase
    {
        private readonly INominaOperaciones _repository;

        public NominaController(INominaOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NominaModel>>> Get()
        {
            return await _repository.GetAllNomina();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NominaModel>> Gets(int id)
        {
            return await _repository.GetByIDNomina(id);
        }

        [HttpPost]
        public async Task Post([FromBody] InsertNominaModel value)
        {
            await _repository.InsertarNomina(value);
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.EliminarNomina(id);
        }




        [HttpPut("[action]")]
        public async Task Put([FromBody] UpdateNominaModel value)
        {
            await _repository.ActualizarNomina(value.IdNomina, value.Fecha, value.NoPedido, value.Proveedor,  value.Cantidad);
        }




    }
}
