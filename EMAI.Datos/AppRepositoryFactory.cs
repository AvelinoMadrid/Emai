using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMAI.Servicios;

namespace EMAI.Datos
{

    public class AppRepositoryFactory
    {
        public static IAppRepository GetAppRepository(bool isUnitOfWork = false)
        {
            return new AppRepository(isUnitOfWork);
        }
    }
}
