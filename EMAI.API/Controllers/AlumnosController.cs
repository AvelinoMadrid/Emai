using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;
using EMAI.Comun;
using EMAI.Comun.Models;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AlumnosController : ControllerBase
    {

        private readonly IAlumnosOperaciones _repository;

        public AlumnosController(IAlumnosOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlumnosModel>>> Get()
        {
            return await _repository.GetAlumnos();
        }


        // buscar ID 
        [HttpGet("{id}")]
        public async Task <ActionResult<AlumnosbyIDModel>> GetAlumnosbyID(int id)
        {
            return await _repository.GetAlumnosbyID(id);
        }




    }
}
