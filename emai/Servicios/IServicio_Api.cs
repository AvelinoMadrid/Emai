using emai.Models;

namespace emai.Servicios

{
    public interface IServicio_Api
    {
        Task<List<Usuarios>> Lista();

        Task<Usuarios> Obtener(int idUsuario);

        Task<bool> Guardar(Usuarios Usuario);

        Task<bool> Editar(Usuarios Usuario);

        Task<bool> Eliminar(int idUsuario);

    }
}
