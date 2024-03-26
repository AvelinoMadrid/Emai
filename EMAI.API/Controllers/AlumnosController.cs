using EMAI.Comun.Models;
using EMAI.DTOS.Dtos.Request;
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

        [HttpGet("GetListAlumnosTotal")]
        public async Task<ActionResult<List<AlumnoResponseV1>>> GetAllAlumosTotal()
        {
            var response = await _repository.GetListaAlumnoV1();
            return Ok(response);

        }
        [HttpPut("Update/{IdAlumno}")]
        public async Task<IActionResult> UpdateAlumno(int IdAlumno, AlumnoRequestV1 request)
        {
            var response = await _repository.EditarAlumnoV1(IdAlumno, request);
            return Ok(response);
        }

        [HttpGet("Folio/GenerarFolio")]
        public async Task<ActionResult<ListFolioResponse>> GenerarFolio()
        {
            var folio = await _repository.FolioGenerate();
            return Ok(folio);
        }
        [HttpGet("SelectListClasesHorarioV1/{IdClase}")]
        public async Task<ActionResult<List<SelectClasesHorarioResponse>>> SelectClasssHorario(int IdClase)
        {
            var response = await _repository.SelectListClaseHorarioV1(IdClase);
            return Ok(response);
        }

        [HttpPost("RegistarAlumnoV1")]
        public async Task<IActionResult> RegisterAlumno([FromBody] AlumnoRequest request)
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

        [HttpDelete("ReactivarAlumno/{IdAlumno}")]
        public async Task<IActionResult> ReactivarAlumno(int IdAlumno)
        {
            var response = await _repository.ReactivarByIdAlumnoV1(IdAlumno);
            return Ok(response);
        }

    }
}