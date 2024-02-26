using EMAI.Comun.Models;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace EMAI.Servicios
{
    public interface IGoogleSheetOperaciones
    {
        Task<bool> ConnectGoogleSheet();
        Task<(int rowCount, int columnCount)> GetRowAndColumnHojas(string sheetName);
        Task<List<dataSourceId>> GetDataSorceTittle(); //forma 1 aseincroina 
        Task<GoogleSheetModel> ReadDataSheet(int dataSheeId);
        Task<Object> UpdateDataSheet(int dataSheetId, IList<IList<Object>> values);


        //Spreadsheet GetSpreadSheet(string nameSpreadIdentity);
        //ValueRange GetSingleValue(string nameSpreadIdentity,string valueRange);
        //BatchGetValuesResponse GetMultiplesValues(string nameSpreadIdentity, string[]ranges);


    }
}
