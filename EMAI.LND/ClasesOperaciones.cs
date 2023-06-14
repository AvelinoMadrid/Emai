using EMAI.Comun.Models;
using EMAI.Datos;
using EMAI.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.LND
{
    public class ClasesOperaciones : IClasesOperaciones
    {
        //MOSTRAR
        public async Task<List<ClasesModel>> GetClases()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetClases();
            return rsp;
        }

    }
}
