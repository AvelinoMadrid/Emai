using emai.Models;

namespace emai.Servicios
{
    public interface IServicioAsigClase_Api
    {
        Task<List<AsigClase>> Lista();
        Task<AsigClase> Obtener(int AsgnId);
        Task<bool> Asignar(AsigClase AsigClase);
        Task<bool> Eliminar(int AsgnId);
    }
}
