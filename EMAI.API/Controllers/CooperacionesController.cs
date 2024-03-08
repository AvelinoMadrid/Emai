using EMAI.Comun.Models;
using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CooperacionesController : ControllerBase
    {
        private readonly ICooperacionesOperaciones _repository;

        public CooperacionesController(ICooperacionesOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CooperacionesModel>>> Get()
        {
            return await _repository.GetAllCooperaciones();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CooperacionesModel>> Gets(int id)
        {
            return await _repository.GetCooperacionesByID(id);
        }

        [HttpPost]
        public async Task Post([FromBody] InsertCooperacionModel value)
        {
            await _repository.InsertarCooperaciones(value);
        }

        [HttpDelete("{id}")]
        public async Task DeleteCooperacionesbyId(int id)
        {
            await _repository.DeleteCooperacionesbyId(id);
        }

        //Actualizar Horarios
        [HttpPut("[action]")]
        public async Task Put([FromBody] UpdateCooperacionesModel value)
        {
            await _repository.UpdateCooperaciones(value.IdCooperacion, value.Fecha, value.NoPedido, value.Proveedor,  value.Cantidad,value.Img);
        }




    }
}
