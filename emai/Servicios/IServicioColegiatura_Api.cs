using emai.Models;

namespace emai.Servicios
{
    public interface IServicioColegiatura_Api
    {
        Task<List<GastosColegiatura>> Lista();

        Task<GastosColegiatura> Obtener(int IdColegiatura);

        Task<bool> Guardar(GastosColegiatura Colegiatura);

        Task<bool> Editar(GastosColegiatura Colegiatura);

        Task<bool> Eliminar(int IdColegiatura);
    }
}
