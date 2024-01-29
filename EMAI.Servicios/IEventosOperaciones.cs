using EMAI.Comun.Models;
using static EMAI.Comun.Models.EventosIDModel;

namespace EMAI.Servicios
{
    public interface  IEventosOperaciones
    {
        Task<List<EventosModel>> GetEventos(); 

        Task<EventosIDModel> GetEventosID(int IdEvento);

        Task<bool> InsertarEvento(EventoInsertarModel value);

        Task<bool> ActualizarEvento(int IdEvento, string NombreEvento, string Fecha, int IdHora, int IdAlumno, int IdClase);

        Task<bool> EliminarEvento(int IdEvento);
    }
}
