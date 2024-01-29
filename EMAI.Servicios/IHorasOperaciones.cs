using EMAI.Comun.Models;

namespace EMAI.Servicios
{
    public interface IHorasOperaciones
    {
        Task<List<HorasModel>> GetHoras();
        Task<bool> InsertarHoras(HorasInsertarModel value);

    }
}
