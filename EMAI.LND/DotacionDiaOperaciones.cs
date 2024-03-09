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
    public class DotacionDiaOperaciones : IDotacionDiaOperaciones
    {

        public async Task<List<DotacionDiaModel>> GetAllDotacionDia()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetAllDotacionDia();
            return rsp;
                
        }

        public async Task<DotacionDiaModel> GetDotacionDiaById(int id)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetDotacionDiaById(id);
            return rsp;
        }

        public async Task<bool> InsertarDotacionDia(InsertDotacionDiaModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarDotacionDia(value);
            return rsp;
        }

        public async Task<bool> UpdateDotacionDia(int id, DateTime fecha, string NoPedido, string Descripcion, decimal cantidad, string img)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.UpdateDotacionDia(id,fecha,NoPedido,Descripcion,cantidad,img);
            return rsp;
        }

        public async Task<bool> DeleteDotacionDiabyID(int id)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.DeleteDotacionDiabyID(id);
            return rsp;
        }
    }
}
