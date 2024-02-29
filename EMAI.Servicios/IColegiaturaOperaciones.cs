using EMAI.Comun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Servicios
{
    public interface IColegiaturaOperaciones
    {
        Task<List<ColegiaturaModel>> GetColegiatura();
        Task<ColegiaturaIDModel> GetColegiaturaID(int IdColegiatura);
        Task<bool> InsertarColegiatura(ColegiaturaInsertarModel value);
        Task<bool> ActualizarColegiatura(int IdColegiatura, DateTime Fecha,  string Descripcion, decimal Cantidad);
        Task<bool> EliminarColegiatura(int IdColegiatura);
    }
}
