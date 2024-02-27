using EMAI.Comun.Models;
using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosDiaController
    {
        private readonly IGastosDiaOperaciones _repository;

        public GastosDiaController(IGastosDiaOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GastosDiaModel>>> Get()
        {
            return await _repository.GetGastosDia();
        }

        //Buscar por ID
        [HttpGet("{IdGastoDia}")]
        public async Task<ActionResult<GastosDiaIDModel>> GetGastosDiaID(int IdGastoDia)
        {
            return await _repository.GetGastosDiaID(IdGastoDia);
        }

        //Insertar un GastoDia

        [HttpPost("/api/GastoDia/Insertar")]
        public async Task Post([FromBody] GastosDiaInsertarModel value)
        {
            await _repository.InsertarGastosDia(value);
        }

        //Actualizar GastosDia
        [HttpPut("/api/GastosDia/Actualizar")]
        public async Task Put([FromBody] GastosDiaActualizarModel value)
        {
            await _repository.ActualizarGastosDia(value.IdGastoDia, value.Fecha, value.NoPedido, value.Proveedor, value.Descripcion,
            value.Cantidad, value.Subtotal, value.Total);
        }

        //Eliminar GastoDIa
        [HttpDelete("Eliminar/{IdGastoDia}")]
        public async Task Delete(int IdGastoDia)
        {
            await _repository.EliminarGastosDia(IdGastoDia);
        }
    }
}
