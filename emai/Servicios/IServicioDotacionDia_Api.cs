using emai.Models;

namespace emai.Servicios
{
    public interface IServicioDotacionDia_Api
    {
        Task<List<DotacionDia>> Lista();

        Task<DotacionDia> Obtener(int IdDotacion);

        Task<bool> Guardar(DotacionDia Dotacion);

        Task<bool> Editar(DotacionDia Dotacion);

        Task<bool> Eliminar(int IdDotacion);
    }
}
