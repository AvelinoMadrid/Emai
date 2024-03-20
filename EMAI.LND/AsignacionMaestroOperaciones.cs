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
    public class AsignacionMaestroOperaciones : IAsignacionMaestroOperaciones
    {
        /*MOSTRAR*/
        public async Task<List<AsigMaestroModel>> GetAsigMaestro1()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetAsigMaestro1();
            return rsp;
        }

        //Buscar por Id
        public async Task<AsigMaestroId> GetAsigMaestroId1(int AsgnId)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetAsigMaestroId(AsgnId);
            return rsp;
        }

        //asignar

        public async Task<bool> AsignarMaestro(AsigMaestro1Asignar value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.AsignarMaestro(value);
            return rsp;
        }


        //ELIMINAR
        public async Task<bool> EliminarAsignacionMaestro(int AsgnId)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.EliminarAsignacionMaestro(AsgnId);
            return rsp;
        }
        //actualizar
        public async Task<bool> ActualizarAsigMaestro(int AsgnId, int IdMaestro, int IdClase, int IdHorario)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.ActualizarAsigMaestro( AsgnId,IdMaestro,IdClase,IdHorario);
            return rsp;
        }

        
    }
}
