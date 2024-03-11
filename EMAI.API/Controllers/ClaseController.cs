using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;
using EMAI.Comun;
using EMAI.Comun.Models;
using EMAI.DTOS.Dtos.Response;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaseController : ControllerBase
    {
        private readonly IClasesOperaciones _repository;

        public ClaseController(IClasesOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClasesModel>>> Get()
        {
            return await _repository.GetClases();
        }
        [HttpGet("ListClassUnique")]
        public async Task<ActionResult<List<SelectClasesUnique>>> ListarClasesUnique()
        {
            var response = await _repository.GetSelectClasesUnique();
            return Ok(response);
        }
       
        // buscar ID 
        [HttpGet("{IdClase}")]
        public async Task<ActionResult<ClasesIdModel>> GetAlumnosbyID(int IdClase)
        {
            return await _repository.GetClasesId(IdClase);
        }

        // Obtener nombre clases 
        [HttpGet("/api/Clases/ObtenerNombres")]
        public async Task<ActionResult<IEnumerable<ListaClases>>> GetNombreClases()
        {
            return await _repository.GetNombreClases();
        }



        //Insertar clase 

        [HttpPost("/api/Clases/Insertar")]
        public async Task Post([FromBody] ClasesModelInsertar value)
        {
            await _repository.InsertarClase(value);
        }

        //Actualizar clase
        [HttpPut("/api/Clases/Actualizar")]
        public async Task Put([FromBody] ClasesModelActualizar value)
        {
            await _repository.ActualizarClase(value.IdClase, value.Nombre, value.CNormal, value.CVerano,
                value.Dia, value.Dia2, value.Dia3, value.Costo);
        }

        //Eliminar Clase
        [HttpDelete("Eliminar/{IdClase}")]
        public async Task Delete(int IdClase)
        {
            await _repository.EliminarClase(IdClase);
        }









    }
}
