using EMAI.Comun.Models;
using EMAI.Datos;
using EMAI.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static EMAI.Comun.Models.RepClaseModel;


namespace EMAI.LND
{
    public class RepClaseOperaciones : IRepClaseOperaciones
    {
        //Mostrar todo
        public async Task<List<RepClaseModel>> GetRepClase()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetRepClase();
            return rsp;
        }

        //Buscar por ID
        public async Task<RepClaseIDModel> GetRepClaseID(int IdRepClase)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetRepClaseID(IdRepClase);
            return rsp;
        }


        //Insertar un RepClase
        public async Task<bool> InsertarRepClase(RepClaseInsertarModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarRepClase(value);
            return rsp;
        }

        //Actualizar RepClase

        public async Task<bool> ActualizarRepClase(int IdRepClase, int IdClase, int IdMaestro,/*int IdAlumno,*/ string DiaRep)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.ActualizarRepClase(IdRepClase, IdClase, IdMaestro,/*IdAlumno,*/ DiaRep);
            return rsp;
        }

        //Eliminar RepClase
        public async Task<bool> EliminarRepClase(int IdRepClase)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.EliminarRepClase(IdRepClase);
            return rsp;
        }
    }
}
