using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;
using EMAI.Comun;
using EMAI.Comun.Models;
using System.Security.Cryptography;
using static EMAI.Comun.Models.RepClaseModel;



namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepClaseController
    {
        private readonly IRepClaseOperaciones _repository;

        public RepClaseController(IRepClaseOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepClaseModel>>> Get()
        {
            return await _repository.GetRepClase();
        }

        //por ID
        [HttpGet("{IdRepClase}")]
        public async Task<ActionResult<RepClaseIDModel>> GetRepClaseID(int IdRepClase)
        {
            return await _repository.GetRepClaseID(IdRepClase);
        }

        //Insertar RepClase

        [HttpPost("/api/RepClase/Insertar")]
        public async Task Post([FromBody] RepClaseInsertarModel value)
        {
            await _repository.InsertarRepClase(value);
        }

        //Actualizar RepClase
        [HttpPut("/api/RepClase/Actualizar")]
        public async Task Put([FromBody] RepClaseActualizarModel value)
        {
            await _repository.ActualizarRepClase(value.IdRepClase, value.IdClase, value.IdMaestro, value.IdAlumno, value.DiaRep);
        }

        //Eliminar RepClase
        [HttpDelete("Eliminar/{IdRepClase}")]
        public async Task Delete(int IdRepClase)
        {
            await _repository.EliminarRepClase(IdRepClase);
        }
    }
}
