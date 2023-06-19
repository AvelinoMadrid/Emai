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

        public static IAsistenciaOperaciones ObtenerAsistenciaOperaciones()
        {
            return new AsistenciaOperaciones();
        }

        public static IClasesOperaciones ObtenerClasesOperaciones()
        {
            return new ClasesOperaciones(); 
        }

        public static IHorariosOperaciones ObtenerHorariosOperaciones()
        {
            return new HorariosOperaciones();
        }




        public static IMaestrosOperaciones ObtenerMaestrosOperaciones()
        {
            return new MaestrosOperaciones();
        }













    }
}
