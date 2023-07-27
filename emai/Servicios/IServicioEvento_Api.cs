using emai.Models;

namespace emai.Servicios
{
    public interface IServicioEvento_Api
    {
        Task<List<Evento>> Lista();

        Task<Evento> Obtener(int IdEvento);

        Task<bool> Guardar(Evento evento);

        Task<bool> Editar(Evento evento);

        Task<bool> Eliminar(int IdEvento);
    }
}
