using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EMAI.Comun.Models;

namespace EMAI.Servicios
{
    public interface IAsignacionClaseOperaciones
    {
        Task<List<AsigClaseModel>> GetAsigClase();

        Task<AsigClaseId> GetAsigClaseId(int AsgnId);

        Task<bool> AsignarClase(AsigClaseAsignar value);

        Task<bool> EliminarAsignacion(int AsgnId);
    }
}
