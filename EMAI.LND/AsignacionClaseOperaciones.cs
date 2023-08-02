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
    public class AsignacionClaseOperaciones : IAsignacionClaseOperaciones
    {
        //MOSTRAR
        public async Task<List<AsigClaseModel>> GetAsigClase()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetAsigClase();
            return rsp;
        }

        //Buscar por Id
        public async Task<AsigClaseId> GetAsigClaseId(int AsgnId)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetAsigClaseId(AsgnId);
            return rsp;
        }

        //Asignar clase

        public async Task<bool> AsignarClase(AsigClaseAsignar value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.AsignarClase(value);
            return rsp;
        }

        //ELIMINAR
        public async Task<bool> EliminarAsignacion(int AsgnId)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.EliminarAsignacion(AsgnId);
            return rsp;
        }
    }
}
