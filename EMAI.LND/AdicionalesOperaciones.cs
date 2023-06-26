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
    public class AdicionalesOperaciones : IAdicionalesOperaciones
    {
        //Mostrar todo
        public async Task<List<AdicionalesModel>> GetAdicionales()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetAdicionales();
            return rsp;
        }

        //Mostrar por ID
        public async Task<AdicionalesIDModel> GetAdicionalesID(int IdAdicional)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetAdicionalesID(IdAdicional);
            return rsp;
        }

        //Insertar Adicional
        public async Task<bool> InsertarAdicional(AdicionalesInsertarModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarAdicional(value);
            return rsp;
        }

        //Actualizar Adicional
        public async Task<bool> ActualizarAdicional(int IdAdicional, int IdAlumno, int IdClase, int IdHorario, DateTime Fecha)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.ActualizarAdicional(IdAdicional, IdAlumno, IdClase,IdHorario,Fecha);
            return rsp;
        }

        //Eliminar Adicional
        public async Task<bool> EliminarAdicional(int IdAdicional)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.EliminarAdicional(IdAdicional);
            return rsp;
        }
    }
}
