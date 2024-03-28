using EMAI.Comun.Models;
using EMAI.DTOS.Dtos.Response;
using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LibroController : ControllerBase
    {

        private readonly ILibrosOperaciones _repository;

        public LibroController(ILibrosOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet("/api/Libro")]
        public async Task<ActionResult<IEnumerable<LibrosModel>>> Get()
        {
            return await _repository.GetAllLibros();
        }


        // buscar ID 
        [HttpGet("/api/Libro/{idActivo}")]
        public async Task<ActionResult<LibrosModel>> GetLibrobyID(int idActivo)
        {
            return await _repository.GetLibrobyId(idActivo);
        }
        /***LIBROS INACTIVOS*/
        [HttpGet("/api/LibrosInactivo")]
        public async Task<ActionResult<List<LibrosModelInactivo>>> GetAllLibrosInactivos()
        {
            var response = await _repository.GetAllLibrosInactivos();
            return Ok(response);

        }

        [HttpGet("/api/LibroInactivo/{idInactivo}")]
        public async Task<ActionResult<List<LibrosModelInactivo>>> GetAllLibrosInactivosByID(int idInactivo)
        {
            var response = await _repository.GetLibrobyIdInactivos(idInactivo);
            return Ok(response);

        }

        /***************/
        /*INSERTAR*/
        [HttpPost]
        public async Task Post([FromBody] InsertLibrosModel value)
        {
            await _repository.InsertLibro(value);
        }

        [HttpPut("/api/Libros/Actualizar")]
        public async Task Put([FromBody] LibrosActualizarModel value)
        {
            await _repository.UpdateLibro(value.IdLibro, value.NombreLibro, value.DescripcionLibro, value.Costo, value.Estado);
        }
        /**********ACTIVAR LIBROS INACTIVOS****/

        [HttpPut("/api/Libros/Activar")]
        public async Task Put([FromBody] ActivadorModel value)
        {
            await _repository.ActivarLibro(value.IdLibro, value.Estado);
        }


    }
}
