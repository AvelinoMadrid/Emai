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
    public class CooperacionesOperaciones : ICooperacionesOperaciones
    {

        public async Task<List<CooperacionesModel>> GetAllCooperaciones()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetAllCooperaciones();
            return rsp;
        }

        //Buscar por ID
        public async Task<CooperacionesModel> GetCooperacionesByID(int id)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetCooperacionesByID(id);
            return rsp;
        }

        public async Task<bool> InsertarCooperaciones(InsertCooperacionModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarCooperaciones(value);
            return rsp;
        }

        public async Task<bool> DeleteCooperacionesbyId(int id)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.DeleteCooperacionesbyId(id);
            return rsp;
        }

        public async Task<bool> UpdateCooperaciones (int id, DateTime Fecha, string NoPedido, string Proveedor,  decimal cantidad)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.UpdateCooperaciones(id,Fecha,NoPedido,Proveedor,cantidad);
            return rsp;
                
        }



    }
}
