using emai.Models;

namespace emai.Servicios
{
    public interface IServicioHorarioVerano_Api
    {
        Task<List<HorarioVerano>> Lista();

        Task<HorarioVerano> Obtener(int IdHorarioVerano);

        Task<bool> Guardar(HorarioVerano horarioVerano);

        Task<bool> Editar(HorarioVerano horarioVerano);

        Task<bool> Eliminar(int IdHorarioVerano);
    }
}
