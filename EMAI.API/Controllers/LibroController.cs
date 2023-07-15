using EMAI.Comun.Models;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibrosModel>>> Get()
        {
            return await _repository.GetAllLibros();
        }

        // buscar ID 
        [HttpGet("{id}")]
        public async Task<ActionResult<LibrosModel>> GetLibrobyID(int id)
        {
            return await _repository.GetLibrobyId(id);
        }

        [HttpPost]
        public async Task Post([FromBody] InsertLibrosModel value)
        {
            await _repository.InsertLibro(value);
        }

        [HttpPut("/api/Libros/ActualizarCosto")]
        public async Task Put([FromBody] LibrosUpModel value)
        {
            await _repository.UpdateLibro(value.IdLibro, value.Costo);
        }


        [HttpPut("/api/Libros/Desactivar")]
        public async Task Puts([FromBody] DesactivadorModel value)
        {
            await _repository.StatusDesactivadoLibro(value.IdLibro);
        }

        [HttpPut("/api/Libros/Activar")]
        public async Task Putss([FromBody] DesactivadorModel value)
        {
            await _repository.StatusActivadorLibro(value.IdLibro);
        }

    }
}
