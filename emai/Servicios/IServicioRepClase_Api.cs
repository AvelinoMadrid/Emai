using emai.Models;

namespace emai.Servicios
{
    public interface IServicioRepClase_Api
    {
        Task<List<RepClase>> Lista();

        Task<RepClase> Obtener(int IdRepClase);

        Task<bool> Guardar(RepClase RepClase);

        Task<bool> Editar(RepClase RepClase);

        Task<bool> Eliminar(int IdRepClase);

        Task<List<RepClase>> ObtenerTodos();
    }
}
