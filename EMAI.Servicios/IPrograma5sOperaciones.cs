using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EMAI.Comun.Models;

namespace EMAI.Servicios
{
    public interface IPrograma5sOperaciones
    {
        Task<List<Programa5sModel>> GetPrograma5s();

        Task<Programa5sIdModel> GetPrograma5sId(int Id);

        Task<bool> InsertarPrograma5s(Programa5sInsertarModel value);

        Task<bool> ActualizarPrograma5s(int Id, string Area, string Supervisor, DateTime FechaAntes, DateTime FechaInicio, string Detalles);
    }
}
