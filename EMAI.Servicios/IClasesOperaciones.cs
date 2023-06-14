using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EMAI.Comun.Models;

namespace EMAI.Servicios
{
    public interface IClasesOperaciones
    {
        //Obtener todos los datos
        Task<List<ClasesModel>> GetClases();
    }
}
