using emai.Models;

namespace emai.Servicios
{
    public interface IServicioHorario_Api
    {
        Task<List<Horario>> Lista();

        Task<Horario> Obtener(int IdHorario);

        Task<bool> Guardar(Horario horario);

        Task<bool> Editar(Horario horario);

        Task<bool> Eliminar(int IdHorario);
    }
}
