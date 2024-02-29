using emai.Models;

namespace emai.Servicios
{
    public interface IServicioPromosiones_Api
    {
        Task<List<Promosiones>> Lista();

        Task<Promosiones> Obtener(int IdPromociones);

        Task<bool> Guardar(Promosiones Promosiones);

        Task<bool> Editar(Promosiones Promosiones);

        Task<bool> Eliminar(int IdPromociones);

        Task<List<Promosiones>> ObtenerTodos();
    }
}
