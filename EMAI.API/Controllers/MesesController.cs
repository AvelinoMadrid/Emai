using EMAI.Comun.Models;
using EMAI.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesesController : ControllerBase
    {
        private readonly IMesesOperaciones _context;

        public MesesController(IMesesOperaciones context)
        {
            this._context = context;
        }
        [HttpGet("SelectMeses")]
        public async Task<ActionResult<List<MesesModelV1>>> GetMesesV1()
        {
            var response = await _context.ListSelectMeses();
            return Ok(response);
        }

    }
}
