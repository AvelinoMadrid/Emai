using emai.Models;

namespace emai.Servicios
{
    public interface IServicioGastosDia_Api
    {
        Task<List<GastosDia>> Lista();
        Task<GastosDia> Obtener(int IdGastoDia);
        Task<bool> Guardar(GastosDia GastosDia);
        Task<bool> Editar(GastosDia GastosDia);
        Task<bool> Eliminar(int IdGastoDia);
    }
}
