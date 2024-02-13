using EMAI.Comun.Models;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace EMAI.Servicios
{
    public interface IGoogleSheetOperaciones
    {
        //opertaciones del documento 
        Task<bool> ConnectGoogleSheet();
        Task<(int rowCount, int columnCount)> GetRowAndColumnHojas(string sheetName);

        Task<List<dataSourceId>> GetDataSorceTittle(); //forma 1 aseincroina 
        Task<GoogleSheetModel> ReadDataSheet(int dataSheeId);







        //Spreadsheet GetSpreadSheet(string nameSpreadIdentity);
        //ValueRange GetSingleValue(string nameSpreadIdentity,string valueRange);
        //BatchGetValuesResponse GetMultiplesValues(string nameSpreadIdentity, string[]ranges);


    }
}
