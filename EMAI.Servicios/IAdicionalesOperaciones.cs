using EMAI.Comun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Servicios
{
    public interface IAdicionalesOperaciones
    {
        Task<List<AdicionalesModel>> GetAdicionales();
        Task<AdicionalesIDModel> GetAdicionalesID(int IdAdicional);
        Task<bool> InsertarAdicional(AdicionalesInsertarModel value);
        Task<bool> ActualizarAdicional(int IdAdicional, int IdAlumno, int IdClase, int IdHorario, DateTime Fecha);
        Task<bool> EliminarAdicional(int IdAdicional);
    }
}
