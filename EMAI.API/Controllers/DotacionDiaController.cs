using EMAI.Comun.Models;
using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DotacionDiaController : ControllerBase
    {
        private readonly IDotacionDiaOperaciones _repository;

        public DotacionDiaController(IDotacionDiaOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DotacionDiaModel>>> Get()
        {
            return await _repository.GetAllDotacionDia();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DotacionDiaModel>> Get(int id)
        {
            var response = await _repository.GetDotacionDiaById(id);
            if (response == null) { return NotFound(); }
            return response;
        }

        [HttpPost("/api/DotacionDia/Insertar")]
        public async Task Post([FromBody] InsertDotacionDiaModel value)
        {
            await _repository.InsertarDotacionDia(value);
        }

        [HttpPut("[action]")]
        public async Task Put([FromBody] UpdateDotacionModel value)
        {
            await _repository.UpdateDotacionDia(value.IdDotacion, value.Fecha, value.NoPedido, value.Descripcion, value.Cantidad, value.Img);
        }

        // Eliminar datos 
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.DeleteDotacionDiabyID(id);
        }

    }
}
