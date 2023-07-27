using emai.Models;

namespace emai.Servicios
{
    public interface IServicioMaestro_Api
    {
        Task<List<Maestro>> Lista();

        Task<Maestro> Obtener(int IdMaestro);

        Task<bool> Guardar(Maestro Maestro);

        Task<bool> Editar(Maestro Maestro);

        Task<bool> Eliminar(int IdMaestro);

        Task<List<Maestro>> ObtenerTodos();
    }
}
