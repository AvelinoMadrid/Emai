using emai.Models;

namespace emai.Servicios
{
    public interface IServicioAsigMaestro_Api
    {
        Task<List<AsigMaestro>> ListaAsigMaestro();
        Task<AsigMaestro> Obtener(int AsgnId);
        Task<bool> AsignarAsigMaestro(AsigMaestro AsigMaestro);
        Task<bool> EliminarAsignacion(int AsgnId);
        Task<bool> ActualizarAsigMaestro(AsigMaestro AsigMaestro);
    }
}
