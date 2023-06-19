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

        [HttpPost]
        public async Task Post([FromBody] InsertAlumnoModel value)
        {
            await _repository.InsertarAlumno(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.DeleteByIdAlumno(id);
        }

        // ACTUALIZAR
        // PUT api/values/5
        [HttpPut("[action]")]
        public async Task Put([FromBody] AlumnosUpdateModel value)
        {
            await _repository.UpdateAlumnos(value.IdAlumno, value.Tag, value.NoDiaClases, value.FechaInicioClaseGratis,
            value.FechaFinClaseGratis, value.Nombre, value.ApellidoP, value.ApellidoM, value.Edad, value.FechaNacimiento,
            value.TelefonoCasa, value.Celular, value.Facebook, value.Email, value.Enfermedades, value.Discapacidad, value.InstrumentoBase, value.Dia,
            value.Hora, value.InstrumentoOpcional, value.DiaOpcional, value.HoraOpcional, value.CelularPapas, value.EmailPapas, value.RecogerPapas, value.CelularTR, value.NumEmergencia);
        }






    }
}
