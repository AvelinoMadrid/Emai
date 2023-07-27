using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EMAI.Comun.Models;

namespace EMAI.Servicios
{
    public interface  IEventosOperaciones
    {
        Task<List<EventosModel>> GetEventos();

        Task<EventosIDModel> GetEventosID(int IdEvento);

        Task<bool> InsertarEvento(EventoInsertarModel value);

        Task<bool> ActualizarEvento(int IdEvento, string NombreEvento, DateTime Fecha, DateTime Hora, int IdAlumno, int IdClase);

        Task<bool> EliminarEvento(int IdEvento);
    }
}
