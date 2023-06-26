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
    public class GastosOperaciones : IGastosOperaciones
    {
        //Mostrar todo
        public async Task<List<GastosModel>> GetGastos()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetGastos();
            return rsp;
        }

        //Mostrar por ID
        public async Task<GastosIDModel> GetGastosID(int IdGasto)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetGastosID(IdGasto);
            return rsp;
        }

        //Insertar Gastos
        public async Task<bool> InsertarGastos(GastosInsertarModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarGastos(value);
            return rsp;
        }

        //Actualizar Usuario
        public async Task<bool> ActualizarGastos(int IdGasto, int IdCooperaciones, int IdDotacion, int IdGastosDia, int IdNomina, DateTime Fecha, string NoPedidoE_S,
          string Proveedor, string Descripcion, decimal Cantidad)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.ActualizarGastos(IdGasto,IdCooperaciones,IdDotacion,IdGastosDia,IdNomina,Fecha,NoPedidoE_S,
          Proveedor,Descripcion,Cantidad);
            return rsp;
        }

        //Eliminar Gasto
        public async Task<bool> EliminarGastos(int IdGasto)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.EliminarGastos(IdGasto);
            return rsp;
        }
    }
}
