using Google.Apis.Auth.OAuth2;

namespace EMAI.Servicios
{
    public interface IAutentificacionSheet
    {
        Task<UserCredential> Logiarse(string googleClientId, string secutySecrety, string[] scopes);
    }
}
