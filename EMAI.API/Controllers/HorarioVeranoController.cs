using EMAI.Comun.Models;
using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace EMAI.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class HorarioVeranoController : ControllerBase
    {
        private readonly IHorariosVeranoOperaciones _repository;

        public HorarioVeranoController(IHorariosVeranoOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HorariosVeranoModel>>> Get()
        {
            return await _repository.GetAllHorariosVerano();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HorariosVeranoModel>> Get(int id)
        {
            var response = await _repository.GetHorariosVeranoById(id);
            if (response == null) { return NotFound(); }
            return response;
        }

        [HttpPost]
        public async Task Post([FromBody] HorariosVeranoInsertModel value)
        {
            await _repository.InsertHorarioVerano(value);
        }

        [HttpPut]
        public async Task Put([FromBody] HorariosVeranoUpModel value)
        {
            await _repository.UpdateHorarioVerano(value.IdHorarioVerano, value.Fecha);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.DeleteHorarioVerano(id);
        }


    }
}
