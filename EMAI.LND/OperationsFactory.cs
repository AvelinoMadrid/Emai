using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using EMAI.Servicios;

namespace EMAI.LND
{
    public  class OperationsFactory
    {

        //public static IAlumnosOperaciones ObtenerAlumnosOperaciones()
        //{
        //    return new AlumnosOperaciones();
        //}

        public static IAdicionalesOperaciones ObtenerAdicionalesOperaciones()
        {
            return new AdicionalesOperaciones();    
        }

        public static IAsistenciaOperaciones ObtenerAsistenciaOperaciones()
        {
            return new AsistenciaOperaciones();
        }

        public static IClasesOperaciones ObtenerClasesOperaciones()
        {
            return new ClasesOperaciones(); 
        }

        public static IColegiaturaOperaciones ObtenerColegiaturaOperaciones()
        {
            return new ColegiaturaOperaciones();
        }

        public static ICooperacionesOperaciones ObtenerCooperacionesOperaciones()
        {
            return new CooperacionesOperaciones();
        }

        public static IDotacionDiaOperaciones ObtenerDotacionDiaOperaciones()
        {
            return new DotacionDiaOperaciones();
        }

        public static IGastosOperaciones ObtenerGastosOperaciones()
        {
            return new GastosOperaciones();
        }

        public static IGastosDiaOperaciones ObtenerGastosDiaOperaciones()
        {
            return new GastosDiaOperaciones();
        }

        public static IPagosOperaciones ObtenerPagosOperaciones()
        {
            return new PagosOperaciones();  
        }

        public static IHorariosOperaciones ObtenerHorariosOperaciones()
        {
            return new HorariosOperaciones();
        }

        public static IMaestrosOperaciones ObtenerMaestrosOperaciones()
        {
            return new MaestrosOperaciones();
        }

        public static INominaOperaciones ObtenerNominaOperaciones()
        {
            return new NominaOperaciones();
        }

        public static IUsuariosOperaciones ObtenerUsuariosOperaciones()
        {
            return new UsuariosOperaciones();
        }

        public static ILibrosOperaciones ObtenerLibrosOperaciones()
        {
            return new LibrosOperaciones();
        }

        public static IHorariosVeranoOperaciones ObtenerHorariosVeranoOperaciones()
        {
            return new HorariosVeranoOperaciones();
        }

        public static IEventosOperaciones ObtenerEventosOperaciones()
        {
            return new EventosOperaciones();
        }
        public static IHorasOperaciones ObtenerHorasOperaciones()
        {
            return new HorasOperaciones();
        }

        public static IAsignacionClaseOperaciones ObtenerAsignacionClaseOperaciones()
        {
            return new AsignacionClaseOperaciones();
        }

        public static IAsignacionMaestroOperaciones ObtenerAsignacionMaestroOperaciones()
        {
            return new AsignacionMaestroOperaciones();
        }

        public static IPrograma5sOperaciones ObtenerPrograma5sOperaciones()
        {
            return new Programa5sOperaciones();
        }
        public static IGoogleSheetOperaciones ObtenerGoogleSheetOperaciones()
        {

            return new GoogleSheetOperaciones();
        }
        public static IRepClaseOperaciones ObtenerRepClaseOperaciones()
        {
            return new RepClaseOperaciones();
        }

    }
}
