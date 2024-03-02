

using emai.Models;

namespace emai.Servicios
{
    public interface IServicioPrograma5s_Api
    {
        Task<List<Programa5s>> Lista();

        Task<Programa5s> Obtener(int Id);

        Task<bool> Guardar(Programa5s programa5s);

        Task<bool> Editar(Programa5s programa5s);

        //Task<bool> Eliminar(int Id);

        //Task<List<Programa5s>> ObtenerTodos();
    }
}