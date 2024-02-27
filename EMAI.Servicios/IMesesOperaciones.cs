using EMAI.Comun.Models;
using EMAI.DTOS.Dtos.Base;
using EMAI.DTOS.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Servicios
{
    public interface IMesesOperaciones
    {
        Task<List<MesesModelV1>> ListSelectMeses();
    }
}
