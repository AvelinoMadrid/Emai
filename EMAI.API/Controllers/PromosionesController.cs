using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;
using EMAI.Comun;
using EMAI.Comun.Models;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromosionesController
    {
        private readonly IPromosionesOperaciones _repository;

        public PromosionesController(IPromosionesOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromosionesModel>>> Get()
        {
            return await _repository.GetPromosiones();
        }

        //Buscar por ID
        [HttpGet("{IdPromosiones}")]
        public async Task<ActionResult<PromosionesIDModel>> GetPromosionesID(int IdPromosiones)
        {
            return await _repository.GetPromosionesID(IdPromosiones);
        }


        //Insertar Promosiones

        [HttpPost("/api/Promosiones/Insertar")]
        public async Task Post([FromBody] PromosionesInsertarModel value)
        {
            await _repository.InsertarPromosiones(value);
        }

        //Actualizar Promosiones
        [HttpPut("/api/Promosiones/Actualizar")]
        public async Task Put([FromBody] PromosionesActualizarModel value)
        {
            await _repository.ActualizarPromosiones(value.IdPromosion, value.IdAlumno, value.Porcentaje, value.Fecha);
        }

        //Eliminar Promosiones
        [HttpDelete("Eliminar/{IdPromosion}")]
        public async Task Delete(int IdPromosion)
        {
            await _repository.EliminarPromosiones(IdPromosion);
        }
    }
}
