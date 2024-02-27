using EMAI.Comun.Models;
using EMAI.Datos;
using EMAI.DTOS.Dtos.Base;
using EMAI.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.LND
{
    public class MesesOperaciones : IMesesOperaciones
    {
        public async Task<List<MesesModelV1>> ListSelectMeses()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var response = await db.GetSelectMeses();
            return response;
        }
    }
}
