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
    public class PagosOperaciones : IPagosOperaciones
    {
        //Mostrar todo
        public async Task<List<PagosModel>> GetPagos()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetPagos();
            return rsp;
        }

        //Mostrar por ID
        public async Task<PagosIDModel> GetPagosID(int IdPago)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetPagosID(IdPago);
            return rsp;
        }

        //Insertar un Gasto
        public async Task<bool> InsertarPagos(PagosInsertarModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarPagos(value);
            return rsp;
        }

        //Actualizar Gasto
         public async Task<bool> ActualizarPagos(int IdPago, int IdPromosiones, int IdAdicionales, DateTime Fecha, string Folio, DateTime FechaPago,
            decimal SaldoPendiente, string Mes, int IdHorario, string Dia, int IdClase, int IdRecepcionista, decimal Costo, string Autorizacion,
            decimal Subtotal, decimal Iva, decimal Total)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.ActualizarPagos(IdPago, IdPromosiones, IdAdicionales, Fecha, Folio, FechaPago,
            SaldoPendiente, Mes, IdHorario, Dia, IdClase, IdRecepcionista, Costo, Autorizacion,
            Subtotal, Iva, Total);
            return rsp;
        }

        //Eliminar Gasto
        public async Task<bool> EliminarPago(int IdPago)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.EliminarPago(IdPago);
            return rsp;
        }
    }
}
