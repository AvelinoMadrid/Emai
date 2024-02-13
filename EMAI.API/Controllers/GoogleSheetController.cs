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

        [HttpGet]
        public async Task<ActionResult<bool>>BindingRepuestOfGoogleSheet(){

            var result = await _googleSheetOperaciones.ConnectGoogleSheet();

            return Ok(result);

        }

        [HttpGet("GoogleSheetListData")]
        public async Task<ActionResult<List<dataSourceId>>> GetWorksheets()
        {
            try
            {
                var result = await _googleSheetOperaciones.GetDataSorceTittle();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Se presento no baja " + ex.Message);
            }
        }
        [HttpGet("{HojaIdShhet}")]
        public async Task<ActionResult<List<GoogleSheetModel>>> GetDataHojaSheet(int HojaIdShhet)
        {
            var result = await _googleSheetOperaciones.ReadDataSheet(HojaIdShhet);
            return Ok(result);
        }
    
        //retorna la lista de tabla de shheId 
        //retoan la lista de tabla de sheeId en update medio de row

    }
}