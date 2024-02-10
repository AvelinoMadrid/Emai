using EMAI.Comun.Models;
using EMAI.Servicios;
using Email.Utiilities.Static;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;

namespace EMAI.LND
{
    public class GoogleSheetOperaciones : IGoogleSheetOperaciones
    {
        private readonly IAutentificacionSheet _autentificacionSheet;

        string accederGoogle = StaticVariable.SHEETUSERID;
        string securitySecrety = StaticVariable.SECURITYCLAVE;
        string[] scopes = { SheetsService.Scope.Spreadsheets };
        

        public GoogleSheetOperaciones(IAutentificacionSheet autentificacionSheet)
        {
            this._autentificacionSheet = autentificacionSheet;
        }

        public async Task<List<dataSourceId>> GetDataSorceTittle(string nameSpreadIdentity)
        {

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

                //mandarlo en una capusila de repuesta 
                var request = service.Spreadsheets.Get(nameSpreadIdentity);
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

        public BatchGetValuesResponse GetMultiplesValues(string nameSpreadIdentity, string[] ranges)
        {
            throw new NotImplementedException();
        }

        public ValueRange GetSingleValue(string nameSpreadIdentity, string valueRange)
        {
            throw new NotImplementedException();
        }

        public Spreadsheet GetSpreadSheet(string nameSpreadIdentity)
        {
            throw new NotImplementedException();
        }
    }
}

