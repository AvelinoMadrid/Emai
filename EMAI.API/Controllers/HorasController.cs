using EMAI.Comun.Models;
using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;
using static EMAI.Comun.Models.EventosIDModel;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorasController 
    {
        private readonly IHorasOperaciones _repository;

        public HorasController(IHorasOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HorasModel>>> Get()
        {
            return await _repository.GetHoras();
        }
        [HttpPost("/api/Horas/Insertar")]
        public async Task Post([FromBody] HorasInsertarModel value)
        {
            await _repository.InsertarHoras(value);
        }

    }
}
