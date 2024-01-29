using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;
using EMAI.Comun;
using EMAI.Comun.Models;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Security.Cryptography;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController
    {
        private readonly IPagosOperaciones _repository;

        public PagosController(IPagosOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PagosModel>>> Get()
        {
            return await _repository.GetPagos();
        }

        //Buscar por ID
        [HttpGet("{IdPago}")]
        public async Task<ActionResult<PagosIDModel>> GetPagosID(int IdPago)
        {
            return await _repository.GetPagosID(IdPago);
        }

        //Insertar Gasto

        [HttpPost("/api/Pagos/Insertar")]
        public async Task Post([FromBody] PagosInsertarModel value)
        {
            await _repository.InsertarPagos(value);
        }

        ////Actualizar Gastos
        //[HttpPut("/api/Gasto/Actualizar")]
        //public async Task Put([FromBody] PagosActualizarModel value)
        //{
        //    await _repository.ActualizarPagos(value.IdPago, value.IdPromosiones, value.IdAdicionales, value.Fecha, value.Folio, value.FechaPago,
        //    value.SaldoPendiente, value.Mes, value.IdHorario, value.Dia, value.IdClase, value.IdRecepcionista, value.Costo, value.Autorizacion,
        //    value.Subtotal, value.Iva, value.Total);
        //}

        //Eliminar Gastos
        [HttpDelete("Eliminar/{IdPago}")]
        public async Task Delete(int IdPago)
        {
            await _repository.EliminarPago(IdPago);
        }
    }
}
