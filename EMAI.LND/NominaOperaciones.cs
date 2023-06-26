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
    public class NominaOperaciones : INominaOperaciones
    {
        public async Task<List<NominaModel>> GetAllNomina()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetAllNomina();
            return rsp;
        }

        public async Task<NominaModel> GetByIDNomina(int id)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetByIDNomina(id);
            return rsp;
        }

        public async Task<bool> InsertarNomina(InsertNominaModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarNomina(value);
            return rsp;
        }

        public async Task <bool> ActualizarNomina(int IdNomina, DateTime Fecha, string NoPedido, string Proveedor, string Descripcion, decimal Cantidad, decimal Subtotal, decimal Total)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.ActualizarNomina(IdNomina,Fecha,NoPedido,Proveedor,Descripcion,Cantidad,Subtotal, Total);    
            return rsp;
        }

        public async Task <bool> EliminarNomina(int id)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.EliminarNomina(id);
            return rsp;
        }

    }
}
