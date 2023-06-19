using EMAI.Comun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Servicios
{
    public interface IAsistenciaOperaciones
    {
        Task<List<AsistenciaModel>> GetAllAsistencias();
        Task<AsistenciaModel> GetAsistenciaByID(int id);
        Task<bool> InsertarAlumnoAsistencia(InsertAsistenciaModel value);

        Task<bool> DeleteAsistenciabyID(int id);

        Task<bool> UpdateAsistencia(int id,int IdAlumno,int IdClase,DateTime Fecha, bool Asistencia);
    }
}
