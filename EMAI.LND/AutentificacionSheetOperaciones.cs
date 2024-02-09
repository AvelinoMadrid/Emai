using EMAI.Servicios;
using Google.Apis.Auth.OAuth2;

namespace EMAI.LND
{
    public class AutentificacionSheetOperaciones : IAutentificacionSheet
    {
        public async Task<UserCredential> Logiarse(string googleClientId, string secutySecrety, string[] scopes)
        {
            ClientSecrets secrets = new ClientSecrets
            {
                ClientId = googleClientId,
                ClientSecret = secutySecrety,
            };
            return await GoogleWebAuthorizationBroker.AuthorizeAsync(secrets, scopes, "user", System.Threading.CancellationToken.None);
        }

    } 

}
