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
    public class PromosionesOperaciones : IPromosionesOperaciones
    {
        //Mostrar todo
        public async Task<List<PromosionesModel>> GetPromosiones()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetPromosiones();
            return rsp;
        }

        //Mostrar por ID
        public async Task<PromosionesIDModel> GetPromosionesID(int IdPromosiones)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetPromosionesID(IdPromosiones);
            return rsp;
        }

        //Insertar un Promosiones
        public async Task<bool> InsertarPromosiones(PromosionesInsertarModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarPromosiones(value);
            return rsp;
        }

        //Actualizar Promosiones
        public async Task<bool> ActualizarPromosiones(int IdPromosion, int IdAlumno, int Porcentaje, DateTime Fecha)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.ActualizarPromosiones(IdPromosion, IdAlumno, Porcentaje, Fecha);
            return rsp;
        }

        //Eliminar Promosiones
        public async Task<bool> EliminarPromosiones(int IdPromosion)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.EliminarPromosiones(IdPromosion);
            return rsp;
        }
    }
}
