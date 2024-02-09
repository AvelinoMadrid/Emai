using EMAI.Comun.Models;
using Google.Apis.Sheets.v4.Data;

namespace EMAI.Servicios
{
    public interface IGoogleSheetOperaciones
    {
        //opertaciones del documento 
        Task<List<dataSourceId>> GetDataSorceTittle(string nameSpreadIdentity); //forma 1 aseincroina 
        Spreadsheet GetSpreadSheet(string nameSpreadIdentity);
        ValueRange GetSingleValue(string nameSpreadIdentity,string valueRange);
        BatchGetValuesResponse GetMultiplesValues(string nameSpreadIdentity, string[]ranges);


    }
}
