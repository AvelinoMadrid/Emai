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
    public class Programa5sOperaciones : IPrograma5sOperaciones
    {
        //Mostrar todo
        public async Task<List<Programa5sModel>> GetPrograma5s()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetPrograma5s();
            return rsp;
        }

        //Mostrar por ID
        public async Task<Programa5sIdModel> GetPrograma5sId(int Id)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetPrograma5sId(Id);
            return rsp;
        }

        //Insertar un Programa5s
        public async Task<bool> InsertarPrograma5s(Programa5sInsertarModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarPrograma5s(value);
            return rsp;
        }

        //Actualizar un Programa 5s
        public async Task<bool> ActualizarPrograma5s(int Id, string Area, string Supervisor, DateTime FechaAntes, DateTime FechaInicio, string Detalles)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.ActualizarPrograma5s(Id, Area, Supervisor, FechaAntes, FechaInicio, Detalles);
            return rsp;
        }
    }
}
