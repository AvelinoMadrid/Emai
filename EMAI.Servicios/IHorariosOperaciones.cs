using EMAI.Comun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Servicios
{
    public interface IHorariosOperaciones
    {
        Task<List<HorariosModel>> GetHorarios();
        Task<HorariosIDModel> GetHorariosID(int IdHorario);
        Task<bool> InsertarHorario(HorariosInsertarModel value);
        Task<bool> ActualizarHorario(int IdHorario,int IdMaestro, int IdClase, string Dia, DateTime Fecha, DateTime HoraInicio, DateTime HoraFin);
        Task<bool> EliminarHorario(int IdHorario);
    }
}
