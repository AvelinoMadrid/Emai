using EMAI.Comun.Models;
using EMAI.Datos;
using EMAI.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.LND
{
    public class GastosDiaOperaciones : IGastosDiaOperaciones
    {
        //Mostrar todo
        public async Task<List<GastosDiaModel>> GetGastosDia()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetGastosDia();
            return rsp;
        }

        //Mostrar por ID
        public async Task<GastosDiaIDModel> GetGastosDiaID(int IdGastoDia)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetGastosDiaID(IdGastoDia);
            return rsp;
        }

        //Insertar GastoDia
        public async Task<bool> InsertarGastosDia(GastosDiaInsertarModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarGastosDia(value);
            return rsp;
        }

        //Actualizar GastoDia
        public async Task<bool> ActualizarGastosDia(int IdGastoDia, DateTime Fecha, string NoPedido, string Proveedor,
            decimal Cantidad, string img)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.ActualizarGastosDia(IdGastoDia, Fecha, NoPedido, Proveedor,
            Cantidad, img);
            return rsp;
        }

        //Eliminar GastoDia
        public async Task<bool> EliminarGastosDia(int IdGastoDia)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.EliminarGastosDia(IdGastoDia);
            return rsp;
        }
    }
}
