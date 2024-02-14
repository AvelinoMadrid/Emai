using EMAI.Comun.Models;
using EMAI.Servicios;
using Email.Utiilities.Static;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using System.Text;

namespace EMAI.LND
{
    public class GoogleSheetOperaciones : IGoogleSheetOperaciones
    {
        public async Task<bool> ConnectGoogleSheet()
        {
            //acceso solo lectura debemos cambiarlo
            string[] scopes = { SheetsService.Scope.Spreadsheets};
            try
            {
                UserCredential credencial;

                using (var stream = new FileStream("DataAccess.json", FileMode.Open, FileAccess.ReadWrite))
                {
                    string creadPath = "accessTokens.json";

                    credencial = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(creadPath, true)).Result;
                }

                var service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
                {
                    HttpClientInitializer = credencial,
                    ApplicationName = StaticVariable.nameApplication
                });
                var request = service.Spreadsheets.Get("1FdU9bBgC0QQeFN20d7C0ac0-8IQp0zTNheHBXt2cWJ8");
                var response = await request.ExecuteAsync();
                
                var result = response != null || response.Sheets != null || response.Sheets.Any() ? true : false;
                return result;
            }

            catch (Exception ex)
            { 
                throw new Exception("No se Puede Vincular A Google Sheet" + ex.Message);
            }

        }

        private static SheetsService GetService()
        {
            string[] scopes = { SheetsService.Scope.Spreadsheets}; 
            try
            {
                UserCredential credencial;

                using (var stream = new FileStream("DataAccess.json", FileMode.Open, FileAccess.ReadWrite))
                {
                    string creadPath = "accessTokens.json";

                    credencial = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(creadPath, true)).Result;
                }
                // Create Google Sheets API service.
                var service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
                {
                    HttpClientInitializer = credencial,
                    ApplicationName = StaticVariable.nameApplication
                });
                return service;
            }

            catch (Exception ex)
            {
                //falara la estructura de error igual la de arriba
               // throw new Exception("No se Puede Vincular A Google Sheet" + ex.Message);
                return null; 
            }
        }
        public async Task<(int rowCount, int columnCount)>GetRowAndColumnHojas(string sheetName)
        {
            try
            {
                //var dataSheet = await GetDataSorceTittle();
                var request = GetService().Spreadsheets.Get("1FdU9bBgC0QQeFN20d7C0ac0-8IQp0zTNheHBXt2cWJ8");
                var response = await request.ExecuteAsync();
                var sheetData = response.Sheets.FirstOrDefault(s => s.Properties.Title == sheetName);

                if (sheetData != null)
                {
                    int rowCount = sheetData.Properties.GridProperties.RowCount != null ? sheetData.Properties.GridProperties.RowCount.Value : 0;
                    int ColumnCount = sheetData.Properties.GridProperties.RowCount != null ? sheetData.Properties.GridProperties.ColumnCount.Value : 0;

                    return (rowCount, ColumnCount);
                }
                else
                {
                    return (0, 0);
                }
            }
            catch (Exception ex)
            {
                return (0, 0);
            }
        }
        public async Task<List<dataSourceId>> GetDataSorceTittle()
        {
            try
            {
                //mandarlo en una capusila de repuesta 
                var request = GetService().Spreadsheets.Get("1FdU9bBgC0QQeFN20d7C0ac0-8IQp0zTNheHBXt2cWJ8");
                var response = await request.ExecuteAsync();

                var data = new List<dataSourceId>();

                foreach (var sheet in response.Sheets)
                {
                    data.Add(new dataSourceId
                    {
                        SheetId = sheet.Properties.SheetId,
                        IdName = sheet.Properties.Title

                    });
                }

                return data;
            }
            catch (Exception ex)
            {
                //falara la estructura de error 
                throw new Exception("No se realizara" + ex.Message);
            }
        }
        public async Task<GoogleSheetModel> ReadDataSheet(int dataSheeId)
        {  
            try
            {
                //verificar si existe la bendita hoja
                var retornDataSheetNew = await GetDataSorceTittle();
                var result = retornDataSheetNew.FirstOrDefault(m => m.SheetId == dataSheeId);
                if (result != null)
                {
                    string nameHoja = result?.IdName;//obtenemos el nombre
                    var resultData = await GetRowAndColumnHojas(nameHoja);//Aqui tengo filas y columnas
                    
                    var request = GetService().Spreadsheets.Values.Get("1FdU9bBgC0QQeFN20d7C0ac0-8IQp0zTNheHBXt2cWJ8", $"{nameHoja}!A1:{GetColumnName(resultData.columnCount)}");

                    request.MajorDimension = SpreadsheetsResource.ValuesResource.GetRequest.MajorDimensionEnum.DIMENSIONUNSPECIFIED;
                    request.ValueRenderOption = SpreadsheetsResource.ValuesResource.GetRequest.ValueRenderOptionEnum.FORMATTEDVALUE;
                    request.DateTimeRenderOption = SpreadsheetsResource.ValuesResource.GetRequest.DateTimeRenderOptionEnum.SERIALNUMBER;


                    var response = await request.ExecuteAsync();
                    var data = response.Values;

                    if (data!=null && data.Count > 0) {

                        var instanciaModel = new GoogleSheetModel
                        {
                            CountRow = data.Count,
                            CountColumn= resultData.columnCount,
                            DataSheetHoja = new List<Dictionary<int, List<string>>>()
                        };

                        for (int i = 0; i < data.Count; i++)
                        {
                            var rowData = new Dictionary<int, List<string>>();
                            rowData[i + 1] = new List<string>(); 

                            for (int j = 0; j < data[i].Count; j++)
                            {
                                rowData[i + 1].Add(Convert.ToString(data[i][j]));
                            }
                            instanciaModel.DataSheetHoja.Add(rowData);
                        }
                        return instanciaModel;
                    }
                    else
                    {
                        //una vacia 
                        return new GoogleSheetModel();
                    }
                }
                else
                {
                    throw new Exception("Retornamos la data que va crear");
                }      
      
            }

            catch (Exception ex)
            {
                //falara la estructura de error 
                throw new Exception("No se realizara" + ex.Message);
            }
        }
        private static string GetColumnName(int columnCount)
        {
            //instancia 
            StringBuilder columnName = new StringBuilder();

            while(columnCount > 0)
            {
                int startColumn = (columnCount - 1)%26;
                columnName.Insert(0,(char)('A'+ startColumn));
                columnCount = (columnCount-1)/26;
            }
            return columnName.ToString();
        }
       public async Task<Object> UpdateDataSheet(int dataSheetId, IList<IList<Object>> values)
        {
            //BatchUpdate checar esta funcione de 
            return await UpdateDataSheet(dataSheetId, values);
        }
    }
}

