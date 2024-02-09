using EMAI.Comun.Models;
using EMAI.LND;
using EMAI.Servicios;
using Email.Utiilities.Static;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Microsoft.AspNetCore.Mvc;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleSheetController : ControllerBase
    {
        private readonly IGoogleSheetOperaciones _googleSheetOperaciones;
        public GoogleSheetController(IGoogleSheetOperaciones googleSheetOperaciones)
        {
            this._googleSheetOperaciones = googleSheetOperaciones;
        }

        //falta retorna la estructura de la respuesta y guardar ese archivo de entrada en appseting
        [HttpGet("{nameIndentityId}")]
        public async Task<ActionResult<List<dataSourceId>>> GetWorksheets(string nameIndentityId)
        {
            try
            {
                var result = await _googleSheetOperaciones.GetDataSorceTittle(nameIndentityId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Se presento no baja " + ex.Message);
            }
        }
        //retorna la lista de tabla de shheId 
        //retoan la lista de tabla de sheeId en update medio de row

    }
}