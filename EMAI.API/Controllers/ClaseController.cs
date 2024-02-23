using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;
using EMAI.Comun;
using EMAI.Comun.Models;

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
                value.Dia, value.Dia2, value.Dia3,
                value.Costo, value.ClaseOpc, value.HorarioOpc);
        }

        //Eliminar Clase
        [HttpDelete("Eliminar/{IdClase}")]
        public async Task Delete(int IdClase)
        {
            await _repository.EliminarClase(IdClase);
        }









    }
}
