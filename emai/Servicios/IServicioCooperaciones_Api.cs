using emai.Models;

namespace emai.Servicios
{
    public interface IServicioCooperaciones_Api
    {
        Task<List<Cooperaciones>> Lista();

        Task<Cooperaciones> Obtener(int IdCooperaciones);

        Task<bool> Guardar(Cooperaciones Cooperaciones);

        Task<bool> Editar(Cooperaciones Cooperaciones);

        Task<bool> Eliminar(int IdCooperaciones);
    }
}
