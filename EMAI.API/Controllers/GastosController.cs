using EMAI.Comun.Models;
using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController
    {
        private readonly IGastosOperaciones _repository;

        public GastosController(IGastosOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GastosModel>>> Get()
        {
            return await _repository.GetGastos();
        }

        //Buscar por ID
        [HttpGet("{IdGasto}")]
        public async Task<ActionResult<GastosIDModel>> GetGastosID(int IdGasto)
        {
            return await _repository.GetGastosID(IdGasto);
        }

        //Insertar Gastos

        [HttpPost("/api/Gastos/Insertar")]
        public async Task Post([FromBody] GastosInsertarModel value)
        {
            await _repository.InsertarGastos(value);
        }

        //Actualizar Gastos
        [HttpPut("/api/Gastos/Actualizar")]
        public async Task Put([FromBody] GastosActualizarModel value)
        {
            await _repository.ActualizarGastos(value.IdGasto, value.IdCooperaciones, value.IdDotacion, value.IdGastosDia, value.IdNomina, value.Fecha, value.NoPedidoE_S,
          value.Proveedor, value.Descripcion, value.Cantidad);
        }

        //Eliminar Gastos
        [HttpDelete("Eliminar/{IdGasto}")]
        public async Task Delete(int IdGasto)
        {
            await _repository.EliminarGastos(IdGasto);
        }
    }
}
