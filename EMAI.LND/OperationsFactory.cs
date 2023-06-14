using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMAI.Servicios;

namespace EMAI.LND
{
    public  class OperationsFactory
    {

        public static IAlumnosOperaciones ObtenerAlumnosOperaciones()
        {
            return new AlumnosOperaciones();
        }

        public static IClasesOperaciones ObtenerClasesOperaciones()
        {
            return new ClasesOperaciones(); 
        }











    }
}
