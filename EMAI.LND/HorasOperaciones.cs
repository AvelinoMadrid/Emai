using EMAI.Comun.Models;
using EMAI.Datos;
using EMAI.Servicios;

namespace EMAI.LND
{
    public class HorasOperaciones : IHorasOperaciones
    {
        public async Task<List<HorasModel>> GetHoras()
        {
            using var db = AppRepositoryFactory.GetAppRepository(); 
            var rsp = await db.GetHoras();
            return rsp;
        }

        public async Task<bool> InsertarHoras(HorasInsertarModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarHoras(value);
            return rsp;
        }
    }
}
