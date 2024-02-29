using EMAI.Comun.Models;
using EMAI.DTOS.Dtos.Response;
using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("Folio/GenerarFolio")]
        public async Task<ActionResult<ListFolioResponse>> GenerarFolio()
        {
            var folio = await _repository.FolioGenerate();
            return Ok(folio);
        }
        [HttpGet("GetListAlumnosTotal")]
        public async Task<ActionResult<List<AlumnoResponseV1>>> GetAllAlumosTotal()
        {
            var response = await _repository.GetListaAlumnoV1();
            return Ok(response);

        }

        // buscar ID /api/Adicional/Insertar
        [HttpGet("{id}")]
        public async Task<ActionResult<AlumnosbyIDModel>> ObtenerAlumnosporID(int id)
        {
            return await _repository.ObtenerAlumnosporID(id);
        }

        //[HttpPost]
        //public async Task Post([FromBody] InsertAlumnoModel value)
        //{
        //    await _repository.InsertarAlumno(value);
        //}
        [HttpPost("RegistarAlumnoV1")]
        public async Task<IActionResult> RegisterAlumno([FromBody] InsertarAlumnoModelV1 request)
        {
            var response = await _repository.RegisterAlumno(request);
            return Ok(response);
        }
        [HttpGet("ListarById/{IdAlumno}")]
        public async Task<ActionResult<AlumnoResponseV1>> GetAlumnoById(int IdAlumno)
        {
           var response = await _repository.GetAlumnosByIdV1(IdAlumno);
           return Ok(response);
        }
        [HttpDelete("DeleteAlumno/{IdAlumno}")]
        public async Task<IActionResult> DeleteAlumno(int IdAlumno)
        {
            var response = await _repository.DeleteByIdAlumnoV1(IdAlumno);
            return Ok(response);
        }


        [HttpPost("api/Alumnos/InsertarNuevaparte")]
        public async Task Post([FromBody] AlumnosNuevo value)
        {
            await _repository.InsertarAlumnosParteI(value);
        }

        [HttpPost("api/Alumnos/InsertarPapas")]
        public async Task Post([FromBody] PapasNuevo value)
        {
            await _repository.InsertarPapas(value);
        }

        [HttpPost("api/Alumnos/InsertarEstudios")]
        public async Task Post([FromBody] EstudiosNuevo value)
        {
            await _repository.InsertarEstudios(value);
        }

        [HttpPost("api/Alumnos/InsertarConocimientosMusicales")]
        public async Task Post([FromBody] ConocimientosMusicales value)
        {
            await _repository.InsertarConocimientosMusicales(value);
        }

        [HttpPost("api/Alumnos/InsertarHoobys")]
        public async Task Post([FromBody] Hoobys value)
        {
            await _repository.InsertarHobbys(value);
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
            await _repository.UpdateAlumnos(value.IdAlumno, value.IdClase, value.Tag, value.NoDiaClases, value.FechaInicioClaseGratis,
            value.FechaFinClaseGratis, value.Nombre, value.ApellidoP, value.ApellidoM, value.Edad, value.FechaNacimiento,
            value.TelefonoCasa, value.Celular, value.Facebook, value.Email, value.Enfermedades, value.Discapacidad, value.InstrumentoBase, value.Dia,
            value.Hora, value.InstrumentoOpcional, value.DiaOpcional, value.HoraOpcional, value.CelularPapas, value.EmailPapas, value.RecogerPapas, value.CelularTR, value.NumEmergencia);
        }


        //nuevos requirimientos 



    }
}
