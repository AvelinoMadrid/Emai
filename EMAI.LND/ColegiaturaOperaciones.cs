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
    public class ColegiaturaOperaciones : IColegiaturaOperaciones
    {
        //Mostrar todo
        public async Task<List<ColegiaturaModel>> GetColegiatura()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetColegiatura();
            return rsp;
        }

        //Mostrar por ID
        public async Task<ColegiaturaIDModel> GetColegiaturaID(int IdColegiatura)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetColegiaturaID(IdColegiatura);
            return rsp;
        }

        //Insertar una Colegiatura
        public async Task<bool> InsertarColegiatura(ColegiaturaInsertarModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarColegiatura(value);
            return rsp;
        }

        //Actualizar Colegiatura
        public async Task<bool> ActualizarColegiatura(int IdColegiatura, DateTime Fecha, string NoPedido, string Descripcion, decimal Cantidad, decimal Subtotal, decimal Total)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.ActualizarColegiatura(IdColegiatura,Fecha,NoPedido,Descripcion,Cantidad,Subtotal,Total);
            return rsp;
        }

        //Eliminar Colegiatura
        public async Task<bool> EliminarColegiatura(int IdColegiatura)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.EliminarColegiatura(IdColegiatura);
            return rsp;
        }
    }
}
